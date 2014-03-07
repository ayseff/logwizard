using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogWizard
{
    class debug_log_reader : log_reader
    {
        public override string read_next_text(int len) {
            return "";
        }
        public override bool has_more_text() { return false; }
        public override int pos { 
            get { return 0; } 
            set {}
        }
    }
}
