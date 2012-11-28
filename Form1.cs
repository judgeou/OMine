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
            gic = panel1.CreateGraphics();
        }

        private void start()
        {
            rowCount = 40;
            colCount = 40;
            cellSize = 20;
            mineCount = 10;
            panel1.Height = rowCount * cellSize + 1;
            panel1.Width = colCount * cellSize + 1;
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
            if (dm != null && gic != null)
            {
                gic.DrawImage(dm.Pic, 0, 0);
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;
            int rowIndex;
            int colIndex;
            rowIndex = mea.Y / cellSize;
            colIndex = mea.X / cellSize;
            mine.DigCell(rowIndex, colIndex);
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
