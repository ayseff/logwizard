using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogWizard
{
    abstract class log_reader
    {
        // reads text at position - and updates position
        public abstract string read_next_text(int len) ;
        // returns true if there's more text to read (given the position in the log)
        public abstract bool has_more_text();

        // the position in the log
        public abstract int pos { get; set; }

    }
}
