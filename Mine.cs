using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMine
{
    /// <summary>
    /// 整个雷区
    /// </summary>
    public class Mine
    {
        public Cell[][] Cells { get; set; }
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public int MineCount { get; set; }
        public MineState State { get; set; }
        public int DigCount { get; set; }

        /// <summary>
        /// 初始化雷区
        /// </summary>
        /// <param name="row">行数</param>
        /// <param name="col">列数</param>
        /// <param name="mineCount">雷数</param>
        public Mine(int row, int col, int mineCount)
        {
            RowCount = row;
            ColCount = col;
            DigCount = 0;
            MineCount = mineCount;
            Cells = new Cell[row][];
            for (int i=0; i < row; i++)
            {
                Cells[i] = new Cell[col];
                for (int j = 0; j < col; j++)
                {
                    Cells[i][j] = new Cell() { HasMine = false, State = (int)CellState.Empty };
                }
            }
            State = MineState.NoMine;
        }

        /// <summary>
        /// 布雷
        /// </summary>
        private void PutMine(int rowIndex, int colIndex)
        {
            Random Ran = new Random();
            int mineCountNow = 0;
            int row, col;
            Cell cell;
            while (mineCountNow < MineCount)
            {
                row = Ran.Next(RowCount);
                col = Ran.Next(ColCount);
                cell = Cells[row][col];
                if ( (row!=rowIndex || col!=colIndex) && !cell.HasMine)
                {
                    cell.HasMine = true;
                    mineCountNow++;
                }
            }
        }
        
        /// <summary>
        /// 挖格子
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="colIndex">列索引</param>
        public void DigCell(int rowIndex, int colIndex)
        {
            if (State == MineState.Dead || State == MineState.Win)
            {
                return;
            }
            if (State == MineState.NoMine)
            {
                PutMine(rowIndex,colIndex);
                State = MineState.Playable;
            }
            Cell cell = Cells[rowIndex][colIndex];
            if (cell.State != (int)CellState.Empty) return;
            if (cell.HasMine)
            {
                cell.State = (int)CellState.Mine;
                State = MineState.Dead;
                return;
            }
            DigCount++;
            cell.State = MineCountRound(rowIndex, colIndex);
            if(cell.State == 0)
            {
                AutoDig(rowIndex, colIndex);
            }
            if (DigCount >= RowCount * ColCount - MineCount)
            {
                State = MineState.Win;
            }
        }

        /// <summary>
        /// 自动打开周围的方块
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        public void AutoDig(int rowIndex, int colIndex)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (Digable(rowIndex + i, colIndex + j)) DigCell(rowIndex + i, colIndex + j);
                }
            }
        }

        /// <summary>
        /// 检测某方格周围的雷数
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public int MineCountRound(int rowIndex, int colIndex)
        {
            int count = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (Digable(rowIndex + i, colIndex + j)) count += Cells[rowIndex + i][colIndex + j].HasMine ? 1 : 0;
                }
            }
            return count;
        }

        /// <summary>
        /// 索引是否可用
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public bool Digable(int rowIndex, int colIndex)
        {
            return (rowIndex >= 0 && rowIndex < RowCount) && (colIndex >= 0 && colIndex < ColCount);
        }

        /// <summary>
        /// 插旗标记
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        public void SetFlag(int rowIndex, int colIndex)
        {
            if (!Digable(rowIndex, colIndex)) return;
            Cell cell = Cells[rowIndex][colIndex];
            if (cell.State == (int)CellState.Empty)
                cell.State = (int)CellState.Flag;
            else if (cell.State == (int)CellState.Flag)
                cell.State = (int)CellState.Empty;
        }
    }

    /// <summary>
    /// 雷区状态
    /// </summary>
    public enum MineState
    {
        NoMine = 0,
        Playable = 1,
        Dead = 2,
        Win =  3
    }
}
