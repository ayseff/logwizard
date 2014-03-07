using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace LogWizard
{
    /** similar to Java properties files 
     */
    public class settings_file
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Dictionary<string, string> data = new Dictionary<string, string>();
        private string file_name;
        private bool dirty_ = false;

        public bool dirty { get { return dirty_; }}

        // if true, we log each time we modify something - for debugging only
        bool log_each_set = false;

        public settings_file(string file_name) {
            this.file_name = file_name;
            if ( !File.Exists(file_name))
                // not found, that is fine - we can have a settings file that we're currently creating
                return; 
            try {
                string last_name = "";
                foreach (var row in File.ReadAllLines(file_name)) {
                    string line = row;
                    if ( line.Length > 1)
                        if ( line[0] == '\t') {
                            // special case - line that starts with '\t'
                            // it will be appended to the previous name
                            // so that we can have a property contain several concatenated "lines"
                            line = line.Trim();
                            if ( line.Length > 2)
                                if ( line.StartsWith("\"") && line.EndsWith("\"")) {
                                    line = line.Substring(1, line.Length - 2);
                                    data[last_name] += line;
                                    continue;
                                }

                        }
                    line = line.Trim();
                    if ( line.Length < 1)
                        continue;
                    if ( line[0] == '#')
                        continue; // comment
                    if ( !line.Contains('=')) {
                        logger.Error("invalid line " + line + " on " + file_name);
                        continue;
                    }

                    string name = line.Split('=')[0].Trim();
                    string value = string.Join("=",line.Split('=').Skip(1).ToArray()).Trim();
                    // any special value (containing starting or ending spaces), surround it with quotes
                    if ( value.Length > 2)
                        if ( value[0] == '"' && value[value.Length-1] == '"') 
                            value = value.Substring(1, value.Length-2);
                    // boolean -> integer
                    if ( value.ToLower() == "false")
                        value = "0";
                    if ( value.ToLower() == "true")
                        value = "1";
                    // ... this is not very nice, but we want to avoid '\\\\r' being turned into '\r'
                    //     (in two iterations - first \\\\r -> \\r, second \\r -> \r
                    //      we need '\\\\r' to be turned into '\\r')
                    value = value.Replace("\\\\", "//\\//\\//");
                    value = value.Replace("\\n", "\n");
                    value = value.Replace("\\r", "\r");
                    value = value.Replace("//\\//\\//", "\\");
                    if ( !data.ContainsKey(name))
                        data.Add(name,"");
                    data[name] = value;
                    last_name = name;
                }
            } catch(Exception e) {
                logger.Error("Could not read " + file_name + " : " + e.Message);
            }

            // log_each_set = int.Parse( get("log_each_set", "0")) != 0;
            // for now, log everything
            log_each_set = true;
        }

        public string get(string text, string default_ = "") {
            if ( data.ContainsKey(text))
                return data[text];
            else
                return default_;
        }

        public void set(string text, string val) {
            if ( !data.ContainsKey(text))
                data.Add( text, "");

            // john.torjo, 17 jan 2014 - always escape Enter
            val = val.Replace("\\","\\\\").Replace("\n", "\\n").Replace("\r", "\\r");

            if ( data[text] != val) {
                data[text] = val;
                dirty_ = true;
                if ( log_each_set)
                    logger.Debug("[sett] " + text + "=" + val);
            }
        }

        public void save() {
            if ( !dirty_)
                return;
            dirty_ = false;
            string contents = "";
            foreach( KeyValuePair<string,string> kv in data) {
                string value = kv.Value;
                if ( value != kv.Value.Trim())
                    value = '"' + value + '"';
                contents += kv.Key + "=" + value + "\r\n";
            }
            try {
                File.WriteAllText(file_name, contents);
            } catch (Exception e) {
                logger.Error("Could not write " + file_name + " : " + e.Message);
            }
            logger.Debug("[sett] Saved settings to " + file_name);
        }
    }
}
