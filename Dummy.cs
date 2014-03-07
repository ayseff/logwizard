using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogWizard
{
    public partial class Dummy : Form
    {
        public Dummy()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            // the point of this is that we don't close when the first Form is closed
            new LogWizard().Show();
        }
    }
}
