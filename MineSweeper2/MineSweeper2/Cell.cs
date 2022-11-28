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
        Cell cell;
        public bool IsMine { get; }
        public bool IsOpen { get; set; }
        public bool HaveMineNeigh { get; set; }
        public Cell(in Field field, int x, int y)
        {
            this.field = field;
            X = x;
            Y = y;
            IsMine = random.Next(1, 10) == 1;
        }
        int NeighborMineCount()
        {
            int MineNAmmount = 0;
            for(int dx = -1; dx <= 1; dx++)
            {
                for(int dy = -1; dy <= 1; dy++)
                {
                    if (field.DoesCordExist(X + dx, Y + dy))
                    {
                        cell = field.GetCellInf(X + dx, Y + dy);
                        if (cell.IsMine)
                        {
                            MineNAmmount++;
                        }
                    }
                }
            }
            if (MineNAmmount != 0)
            {
                HaveMineNeigh = true;
            }
            return MineNAmmount;
        }
        public void Render()
        {
            if (IsMine)
            {
                Console.Write('#');
            }
            else
            {
                if (NeighborMineCount() == 0)
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(NeighborMineCount());
                }
            }
        }
    }
}
