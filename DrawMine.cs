using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMine
{
    class DrawMine
    {
        private Cell[][] cells;
        public Bitmap Pic { get; set; }
        public int Size { get; set; }
        public Graphics gic { get; set; }

        public DrawMine(Cell[][] cells,int size)
        {
            this.cells = cells;
            this.Size = size;
            Pic = new Bitmap(cells[0].Length*size+1,cells.Length*size+1);
            gic = Graphics.FromImage(Pic);
            Update();
        }

        public void Update()
        {
            Cell cell;
            gic.Clear(Color.White);
            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    cell = cells[i][j];
                    gic.DrawRectangle(Global.pen, j * Size, i * Size, Size, Size);
                    if (cell.State > -1 && cell.State < 9)
                    {
                        gic.DrawString(cell.State.ToString(), Global.NumFont, Global.brush, j * Size, i * Size);
                    }
                    if (cell.State==(int)CellState.Flag)
                    {
                        gic.DrawString("#".ToString(), Global.NumFont, Global.brush, j * Size, i * Size);
                    }
                }
            }
        }
    }
}
