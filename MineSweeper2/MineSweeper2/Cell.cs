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
            for(int t = 0; t < 8; t++)
            {
                float A = (float)t * MathF.PI / 4;
                int X = (int)MathF.Round(MathF.Cos(A))+this.X;
                int Y = (int)MathF.Round(MathF.Sin(A))+this.Y;
                if(field.IsCellMine(X, Y))
                {
                    MineNAmmount++;
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
            //if (IsOpen)
            //{
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
            //}
            //else
            //{
            //    Console.Write('\u2588');
            //}
            //Console.Write(IsMine? '\u2588' : $"{NeighborMineCount()}");
        }
    }
}
