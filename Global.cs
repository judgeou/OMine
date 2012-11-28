using System;
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
        public static Color color { get; set; }

        static Global()
        {
            color = Color.Blue;
            NumFont = new Font("Arial", 12);
            pen = new Pen(color);
            brush = new  SolidBrush(color);
        }
    }
}
