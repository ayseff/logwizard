using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogWizard
{
    public partial class log_view : UserControl
    {
        private log_reader reader;

        public class filter_item {
            public enum part_type { date, time, level, message, file, class_ }
            public enum comparison_type { equal, not_equal, starts_with, does_not_start_with, contains, does_not_contain }
            public part_type part;
            public comparison_type comparison;
            public string text = "";
            public static Color transparent = Color.FromArgb(0,0,0,0);
            public Color fg = transparent, bg = transparent;

            // tries to parse a line - if it fails, it will return null
            public static filter_item parse(string line) {
                line = line.Trim();
                if ( !line.StartsWith("$"))
                    return null;

                line = line.Replace("!=", " != ");
                line = line.Replace("=", " = ");
                line = line.Replace("++", " ++ ");
                line = line.Replace("--", " -- ");
                line = line.Replace("+", " + ");
                line = line.Replace("-", " - ");
                line = line.Replace("=>", " => ");

                if ( line.Contains("=>")) 
                    line = line.Replace(",", " , ");

                string[] words = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                // Syntax:
                // $(ColumnName) Comparison Text
                // OR
                // $(ColumnName) Comparison Text =>  ForeColor [,BackColor]
                if ( words.Length != 3 && words.Length != 5 && words.Length != 6) 
                    return null;
                filter_item fi = new filter_item();
                switch ( words[1]) {
                    case "!": fi.comparison = comparison_type.not_equal; break;
                    case "=": fi.comparison = comparison_type.equal; break;
                    case "+": fi.comparison = comparison_type.starts_with; break;
                    case "-": fi.comparison = comparison_type.does_not_contain; break;
                    case "++": fi.comparison = comparison_type.contains; break;
                    case "--": fi.comparison = comparison_type.does_not_contain; break;
                    default:
                        return null;
                }

                switch ( words[0]) {
                    case "$(date)": fi.part = part_type.date; break;
                    case "$(time)": fi.part = part_type.time; break;
                    case "$(level)": fi.part = part_type.level; break;
                    case "$(file)": fi.part = part_type.file; break;
                    case "$(msg)": fi.part = part_type.message; break;
                    case "$(class)": fi.part = part_type.class_; break;
                    default:
                        return null;
                }

                fi.text = words[2];
                if ( words.Length == 3)
                    return fi;

                if ( words.Length == 5 || words.Length == 6)
                    if ( words[3] != "=>")
                        return null;

                // parse colors
                string fg_col = words[4].Substring(1);
                if ( fg_col.Length != 6)
                    return null;

                string r = fg_col.Substring(0,2);
                string g = fg_col.Substring(2,2);
                string b = fg_col.Substring(4,2);
                int ri = Convert.ToInt16(r, 16);
                int gi = Convert.ToInt16(g, 16);
                int bi = Convert.ToInt16(b, 16);
                fi.fg = Color.FromArgb(ri, gi, bi);

                if ( words.Length == 6) {
                    string bg_col = words[5].Substring(1);
                    if ( bg_col.Length != 6)
                        return null;

                    r = bg_col.Substring(0,2);
                    g = bg_col.Substring(2,2);
                    b = bg_col.Substring(4,2);
                    ri = Convert.ToInt16(r, 16);
                    gi = Convert.ToInt16(g, 16);
                    bi = Convert.ToInt16(b, 16);
                    fi.bg = Color.FromArgb(ri, gi, bi);
                }

                return fi;
            }

        }

        public class addition {
            public static addition parse(string line) {
                line = line.Trim();
                if ( line.Length < 1 || (line[0] != '-' && line[0] != '+'))
                    return null;

                addition a = new addition();
                line = line.Substring(1);
                if ( line.EndsWith("ms")) {
                    a.type = number_type.millisecs;
                    line = line.Substring(0, line.Length - 2);
                }

                if ( int.TryParse(line, out a.number))
                    return a;

                return null;
            }

            public enum add_type { before, after }
            public enum number_type { messages, millisecs }

            add_type add = add_type.after;
            number_type type = number_type.messages;
            int number = 0;
        }

        public class filter {
            public List<filter_item> items = new List<filter_item>();
            public List<addition> additions = new List<addition>();
        }
        private List<filter> filters = new List<filter>();
        private LogWizard parent;

        public log_view(LogWizard parent, string name)
        {
            InitializeComponent();
            this.parent = parent;
            viewName.Text = name;
        }


        private void filterName_TextChanged(object sender, EventArgs e)
        {
            parent.on_view_name_changed(this, viewName.Text);
        }

        internal void set_reader(log_reader reader) {
            this.reader = reader;
        }

        public void set_filters(List<filter> filters) {
            // i need to see how big things changed!!!
            this.filters = filters;
        }

        public void show_name(bool show) {
            bool shown = list.Top - 10 > labelName.Top;
            if ( shown == show)
                return;
//            viewName.Visible = show;
  //          labelName.Visible = show;
            int height = viewName.Height + 5;
            list.Top = !show ? list.Top - height : list.Top + height;
            list.Height = !show ? list.Height + height : list.Height - height;
        }

        public void refresh() {
        }
    }
}
