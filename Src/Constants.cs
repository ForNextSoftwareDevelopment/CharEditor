﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharEditor
{
    class Constants
    {
        public static int NUM_CHARS          = 256;
        public static int NUM_CHARS_EXTENDED =  64;
        public static int CHAR_WIDTH         =   8;
        public static int CHAR_HEIGHT        =   8;

        public static Color[] Colors =
        {
            Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF), Color.FromArgb(0xFF, 0x88, 0x00, 0x00), Color.FromArgb(0xFF, 0xAA, 0xFF, 0xEE),
            Color.FromArgb(0xFF, 0xCC, 0x44, 0xCC), Color.FromArgb(0xFF, 0x00, 0xCC, 0x55), Color.FromArgb(0xFF, 0x00, 0x00, 0xAA), Color.FromArgb(0xFF, 0xEE, 0xEE, 0x77),
            Color.FromArgb(0xFF, 0xDD, 0x88, 0x55), Color.FromArgb(0xFF, 0x66, 0x44, 0x00), Color.FromArgb(0xFF, 0xFF, 0x77, 0x77), Color.FromArgb(0xFF, 0x33, 0x33, 0x33),
            Color.FromArgb(0xFF, 0x77, 0x77, 0x77), Color.FromArgb(0xFF, 0xAA, 0xFF, 0x66), Color.FromArgb(0xFF, 0x00, 0x88, 0xFF), Color.FromArgb(0xFF, 0xBB, 0xBB, 0xBB)
        };
    }
}
