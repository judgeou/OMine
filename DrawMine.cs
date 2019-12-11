using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMine
{
    /// <summary>
    /// 负责根据雷区数组来绘图
    /// </summary>
    class DrawMine : IDisposable
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

        /// <summary>
        /// 重新创建bitmap
        /// </summary>
        public void CreateNewMap()
        {
            gic.Dispose();
            Pic.Dispose();
            Pic = new Bitmap(cells[0].Length * Size + 1, cells.Length * Size + 1);
            gic = Graphics.FromImage(Pic);
        }

        /// <summary>
        /// 更新Bitmap
        /// </summary>
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
                        if (cell.State == 0)
                            gic.DrawString("~", Global.NumFont, Global.brush, j * Size, i * Size);
                        else
                            gic.DrawString(cell.State.ToString(), Global.NumFont, Global.brush, j * Size, i * Size);
                    }
                    else if (cell.State == (int)CellState.Flag)
                    {
                        TextRenderer.DrawText(gic, "🚩", Global.NumFont, new Point(j * Size, i * Size), Global.Color);
                    }
                    else if (cell.State == (int)CellState.Mine)
                    {
                        TextRenderer.DrawText(gic, "💣", Global.NumFont, new Point(j * Size, i * Size), Global.Color);
                    }
                }
            }
        }

        public void Dispose()
        {
            gic.Dispose();
            Pic.Dispose();   
        }
    }
}
