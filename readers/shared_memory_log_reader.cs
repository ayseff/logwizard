using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogWizard
{
    class shared_memory_log_reader : log_reader
    {
        // keep all the log in memory
        StringBuilder full_log = new StringBuilder();

        public shared_memory_log_reader() {
            name = "";
        }
        public string name { get; private set; }

        public void set_memory_name(string name) {
            this.name = name;
        }


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
