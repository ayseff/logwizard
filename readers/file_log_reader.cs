using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace LogWizard
{
    class file_log_reader : log_reader
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public readonly string file;

        FileStream fs = null;
        // for now, make it simple - read everything 
        string full_log = "";

        public file_log_reader(string file) {
            this.file = file;
            try {
                fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            } catch { fs = null; }
            pos = 0;
            read_all_file();
        }

        public override string read_next_text(int len) {
            if ( pos > full_log.Length - 1)
                pos = full_log.Length - 1;
            if ( pos + len > full_log.Length)
                len = full_log.Length - pos;
            return full_log.Substring(pos, len);
        }

        public override bool has_more_text() { return pos < full_log.Length - 1; }
        public override int pos { get; set; }

        private void read_all_file() {
            logger.Debug("reading file " + file);
            try {
                int len = (int)new FileInfo(file).Length;
                fs.Seek(0, SeekOrigin.Begin);
            
                // read a few lines from the beginning
                byte[] readBuffer = new byte[len];
                int bytes = fs.Read(readBuffer, 0, len);
                full_log = System.Text.Encoding.Default.GetString(readBuffer, 0, bytes);
            } catch {
            }
        }

        public string try_to_find_log_syntax() {
            try {
                fs.Seek(0, SeekOrigin.Begin);
            
                // read a few lines from the beginning
                byte[] readBuffer = new byte[4096];
                int bytes = fs.Read(readBuffer, 0, 4096);
                string now = System.Text.Encoding.Default.GetString(readBuffer, 0, bytes);
                string[] lines = now.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                fs.Seek(0, SeekOrigin.Begin);
                return try_to_find_log_syntax(lines);
            } catch {
                return "";
            }
        }

        private static bool is_ds(char c) {
            return Char.IsDigit(c) || Char.IsWhiteSpace(c);
        }

        // tries to find if we have a time/date here - if yes, returns pos, otherwise -1
        private int time_or_date_pos(string line, char separator) {
            // we're looking for this config:
            // ddSddSdd - d = digit, S = separator
            List<int> positions = new List<int>();
            int pos = -1;
            while ( line.IndexOf(separator, pos+1) > 0) {
                pos = line.IndexOf(separator, pos+1);
                positions.Add(pos);
            }

            for ( int i = 0; i < positions.Count - 1; ++i) 
                if ( positions[i] + 3 == positions[i+1]) 
                    if ( positions[i] >= 2 && positions[i] + 5 < line.Length) {
                        int at = positions[i];
                        bool ok = is_ds( line[at-2]) && is_ds( line[at-1]) && is_ds( line[at+1]) && is_ds( line[at+2]) && is_ds( line[at+4]) && is_ds( line[at+5]);
                        if ( ok)
                            return at - 2;
                    }
            return -1;
        }

        // returns true if the first list is consistently bigger than the second or consistently less
        // note that -1 values don't count
        //
        // returns: 0 - inconstency, -1 = less, 1 = bigger
        private static int is_consistently_sorted(List<int> a, List<int> b) {
            Debug.Assert(a.Count == b.Count);
            double less = 0, invalid = 0, bigger = 0;
            for ( int i = 0; i < a.Count; ++i) {
                if ( a[i] < 0 || b[i] < 0) ++invalid;
                else if ( a[i] < b[i]) ++less;
                else ++bigger;
            }

            if ( invalid == a.Count)
                // one of the arrays contains only invalid values - that means we don't have that pattern in the log
                // for instane, we don't have times in the log lines
                return a[0] == -1 ? -1 : 1;

            bool valid_less = less / (bigger + less) > .7;
            bool valid_bigger = bigger / (bigger + less) > .7;

            if ( valid_less) return -1;
            else if ( valid_bigger) return 1;
            else return 0;
        }

        private bool is_consistently_present(List<int> list) {
            int present = 0;
            foreach ( int i in list)
                if ( i >= 0) 
                    ++present;
            // make sure it's more than 70%
            return present >= (double)list.Count * .7;
        }

        private string try_to_find_log_syntax(string[] lines) {
            if ( lines.Length < 5)
                return "";

            string syntax = "";
            // see if we have $(file) first
            int pos1 = lines[0].IndexOf("\\"), pos2 = lines[0].IndexOf("\\");
            if ( pos1 < 20 && pos2 < 20)
                syntax += "$(file) ";

            List<int> times = new List<int>(), dates = new List<int>(), levels = new List<int>();
            foreach ( string line in lines) {
                times.Add( time_or_date_pos(line, ':'));
                
                int by_minus = time_or_date_pos(line, '-');
                int by_div = time_or_date_pos(line, '/');
                dates.Add(by_minus > 0 ? by_minus : by_div);

                int info = line.IndexOf(" INFO ");
                int err = line.IndexOf(" ERROR ");
                int fatal = line.IndexOf(" FATAL ");
                int dbg = line.IndexOf(" DEBUG ");
                int warn = line.IndexOf(" WARN ");
                if ( info > 0) levels.Add(info);
                else if ( err > 0) levels.Add(err);
                else if ( fatal > 0) levels.Add(fatal);
                else if ( dbg > 0) levels.Add(dbg);
                else if ( warn > 0) levels.Add(warn);
            }

            bool ok = is_consistently_sorted(times,dates) != 0 && is_consistently_sorted(times,levels) != 0 && is_consistently_sorted(dates,levels) != 0;
            if ( !ok)
                return "";
            List< Tuple<string,List<int>> > sorted = new List<Tuple<string,List<int>>>();
            if ( is_consistently_present(times))
                sorted.Add( new Tuple<string,List<int>>("$(time)", times));
            if ( is_consistently_present(dates))
                sorted.Add( new Tuple<string,List<int>>("$(date)", dates));
            if ( is_consistently_present(levels))
                sorted.Add( new Tuple<string,List<int>>("$(level)", levels));
            sorted.Sort( (x,y) => is_consistently_sorted(x.Item2,y.Item2) );

            foreach ( Tuple<string,List<int>> sli in sorted) 
                syntax += sli.Item1 + " ";
            // time, date, level, message
            syntax += "$(msg)";
            return syntax;
        }
    }
}
