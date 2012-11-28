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
        private int rowCount;
        private int colCount;
        private int cellSize;
        private int mineCount;
        private Graphics gic;
        public Form1()
        {
            InitializeComponent();
        }

        private void start()
        {
            if (dm != null)
                dm.Dispose();
            rowCount = 200;
            colCount = 400;
            cellSize = 20;
            mineCount = 40;
            panel1.Size = new System.Drawing.Size(colCount * cellSize + 1 ,rowCount * cellSize + 1);
            mine = new Mine(rowCount, colCount, mineCount);
            dm = new DrawMine(mine.Cells, cellSize);
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start();
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
                if(ModifierKeys == Keys.Control)
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
    }
}
