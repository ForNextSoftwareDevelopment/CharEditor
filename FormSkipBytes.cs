using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CharEditor
{
    public partial class FormSkipBytes : Form
    {
        public int skipBytes
        {
            get
            {
                return Convert.ToInt32(numBytes.Value);
            }

        }

        public FormSkipBytes()
        {
            InitializeComponent();
        }
    }
}
