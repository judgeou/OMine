using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMine
{
    public partial class Form1 : Form
    {
        private DrawMine dm;
        private Mine mine;
        private int rowCount = 9;
        private int colCount = 9;
        private int cellSize = 20;
        private int mineCount = 10;
        private int widthAdd = 40;
        private int heightAdd = 90;
        private Graphics gic;
        public Form1()
        {
            InitializeComponent();
            start();
        }

        private void start()
        {
            if (dm != null)
                dm.Dispose();
            this.Size = new System.Drawing.Size(colCount * cellSize + widthAdd, rowCount * cellSize + heightAdd);
            panel1.Width += 1;
            mine = new Mine(rowCount, colCount, mineCount);
            dm = new DrawMine(mine.Cells, cellSize);
            refresh();
        }

        private void refresh()
        {
            if (dm != null)
            {
                gic = panel1.CreateGraphics();
                gic.DrawImage(dm.Pic, 0, 0);
                gic.Dispose();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            int rowIndex;
            int colIndex;
            rowIndex = mea.Y / cellSize;
            colIndex = mea.X / cellSize;
            if (mea.Button == System.Windows.Forms.MouseButtons.Left)
            {
                var state = mine.Cells[rowIndex][colIndex].State;
                if (state >= 1 && state <= 8)
                    mine.AutoDig(rowIndex, colIndex);
                else
                    mine.DigCell(rowIndex, colIndex);
            }
            else if (mea.Button == System.Windows.Forms.MouseButtons.Right)
                mine.SetFlag(rowIndex, colIndex);
            dm.Update();
            refresh();
            if (mine.State == MineState.Dead)
                MessageBox.Show("你输了");
            else if(mine.State == MineState.Win)
                MessageBox.Show("你赢了");
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            refresh();
        }

        private void 开局ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start();
        }

        private void 初级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 9;
            colCount = 9;
            mineCount = 10;
            start();
        }

        private void 中级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 16;
            colCount = 16;
            mineCount = 40;
            start();
        }

        private void 高级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rowCount = 16;
            colCount = 30;
            mineCount = 99;
            start();
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            Global.Color = cd.Color;
            dm.Update();
            refresh();
        }
    }
}
