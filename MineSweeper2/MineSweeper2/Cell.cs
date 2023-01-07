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
        Cell? cell;
        public bool IsMine { get; private set; }
        public bool IsOpen { get; set; }
        public bool HaveMineNeigh { get; private set; }
        public Cell(in Field field, int x, int y)
        {
            IsOpen = false;
            this.field = field;
            X = x;
            Y = y;
            IsMine = random.Next(1, 10) == 1;
        }
        public void OpenCell()
        {
            if (IsMine)
            {
                //сделаю проиграш
            }
            RecursedF();
        }
        public void RecursedF()
        {
            if (!IsOpen)
            {
                IsOpen = true;
                Render();
                HaveItMineN();
                //if (!HaveMineNeigh)
                //{
                    for(int dx = -1; dx <= 1; dx++)
                    {
                        for(int dy = -1; dy <= 1; dy++)
                        {
                            cell = ReturnCell(X + dx, Y + dy);
                        if (!(HaveMineNeigh && cell.HaveMineNeigh))
                        {
                            try
                            {
                                cell.RecursedF();
                            }
                            catch { }
                        }
                        }
                    }
                //}
            }
        }
        public void HaveItMineN()
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx != 0 || dy != 0)
                    {
                        cell = ReturnCell(X + dx, Y + dy);
                        if (cell!=null && cell.IsMine)
                        {
                            HaveMineNeigh = true;
                        }
                    }
                }
            }
        }
        Cell? ReturnCell(int x, int y)
        {
            if (field.DoesCordExist(x, y))
            {
                return field.GetCellInf(x, y);
            }
            return null;
        }
        int NeighborMineCount()
        {
            int MineNAmmount = 0;
            for(int dx = -1; dx <= 1; dx++)
            {
                for(int dy = -1; dy <= 1; dy++)
                {
                    if(dx != 0 || dy != 0)
                    {
                        ReturnCell(X + dx, Y + dy);
                        if (cell != null && cell.IsMine)
                        {
                            MineNAmmount++;
                        }
                    }
                }
            }
            //if (MineNAmmount != 0)
            //{
            //    HaveMineNeigh = true;
            //}
            return MineNAmmount;
        }
        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            if (IsOpen)
            {
                if (IsMine)
                {
                    Console.Write('#');
                }
                else
                {
                int N = NeighborMineCount();
                    if (N == 0)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(N);
                    }
                }
            }
            else
            {
                Console.Write('\u2588');
            }
        }
    }
}
