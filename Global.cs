﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMine
{
    public static class Global
    {
        public static Font NumFont { get; set; }
        public static Pen pen { get; set; }
        public static SolidBrush brush { get; set; }
        private static Color color;
        public static Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Properties.Settings.Default.Color = color;
                Properties.Settings.Default.Save();
                pen = new Pen(color);
                brush = new SolidBrush(color);
            }
        }

        static Global()
        {
            color = Properties.Settings.Default.Color;
            NumFont = new Font("Arial", 12);
            pen = new Pen(color);
            brush = new  SolidBrush(color);
        }


    }
}
