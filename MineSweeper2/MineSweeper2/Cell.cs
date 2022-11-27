using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper2
{
    internal class Cell
    {
        Random random = new Random();
        int X;
        int Y;
        Field field;
        bool IsMine = false;
        public Cell(in Field field, int x, int y)
        {
            this.field = field;
            X = x;
            Y = y;
            IsMine = random.Next(1, 10) == 1;
        }
        public int NeighborMineCount()
        {

            return 2;
        }
        public void Render()
        {
            Console.Write(IsMine? '1' : ' ');
        }
    }
}
