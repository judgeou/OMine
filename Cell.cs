using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMine
{
    /// <summary>
    /// 代表雷区中的格子
    /// </summary>
    public class Cell
    {
        public bool HasMine { get; set; }
        public int State { get; set; }
    }

    enum CellState
    {
        Empty = 9,
        Flag = 10,
        Mine = 11
    }
}
