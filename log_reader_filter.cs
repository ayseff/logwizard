using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LogWizard
{
    class log_reader_filter
    {
        private class line {
            public int pos_in_log;

            public enum info_type { time, date, level, msg, class_, file, max }
            public int[] idx_in_line = new int[ (int)info_type.max];
        }
        List<line> lines = new List<line>();
        private string incomplete = "";

        private const int TEXT_BLOCK = 1024 * 128;
        private const string LINE_SEP = "\r\n";

        private log_reader reader = null;
        private string log_syntax = "";

        public log_reader_filter() {
        }


        void refresh() {
            read_to_end();
        }

        // one filter per tab!!!
        // need to remember last position!!!!!!!!!!!! - so that i can have several filters per a given reader

        public void set_reader(log_reader reader) {
            if ( this.reader == reader)
                return;
            this.reader = reader;
            lines.Clear();
            if ( reader != null) {
                reader.pos = 0;
                read_to_end();
            }
        }

        public int log_line_count { get { return 0; } }
        public bool matches(int line_idx, List<log_view.filter> filters, ref Color bg, ref Color fg) {
            return false;
        }


        private void read_to_end() {
            if ( reader == null)
                return;
            while ( reader.has_more_text()) {
                int pos_in_log = reader.pos - incomplete.Length;
                string block = incomplete + reader.read_next_text(TEXT_BLOCK);
                string[] cur_lines = block.Split(new string[] { LINE_SEP }, StringSplitOptions.None);
                // we always consider the last line as being incomplete
                if ( cur_lines.Length > 0)
                    incomplete = cur_lines[ cur_lines.Length - 1];
                if ( lines.Count > 0 && cur_lines.Length > 0) {
                    // we re-parse the last line (which was previously incomplete)
                    lines[ lines.Count - 1] = parse_line( cur_lines[0], pos_in_log);
                    pos_in_log += cur_lines[0].Length + LINE_SEP.Length;
                }

                for ( int i = 1; i < cur_lines.Length; ++i) {
                    lines.Add( parse_line( cur_lines[i], pos_in_log));
                    pos_in_log += cur_lines[0].Length + LINE_SEP.Length;
                }
            }

        }

        private line parse_line(string l, int pos_in_log) {
            line new_ = new line { pos_in_log = pos_in_log };
            return new_;
        }

    }
}
