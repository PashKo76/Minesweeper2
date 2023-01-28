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
        public Cell(in Field field, int x, int y)
        {
            IsOpen = false;
            this.field = field;
            X = x;
            Y = y;
            IsMine = random.Next(1, 10) == 1;
        }
        internal void Recursed()
        {
            if (IsOpen)
            {
                return;
            }
            IsOpen = true;
            Render(); // почему? Сделаю рендер "Динамическим", один раз отрисуб поле в начале, а потом буду перекрашивать клетки
            if (GetMineN())
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx != 0 || dy != 0)
                        {
                            cell = ReturnCell(X + dx, Y + dy);
                            if (cell != null && !cell.IsMine && !cell.GetMineN())
                            {
                                cell.Recursed();
                            }
                        }
                    }
                }
                return;
            }
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx != 0 || dy != 0)
                    {
                        cell = ReturnCell(X + dx, Y + dy);
                        if (cell != null)
                        {
                            cell.Recursed();
                        }
                    }
                }
            }
        }
        internal bool GetMineN()
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
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        int MineCount()
        {
            int result = 0;
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx != 0 || dy != 0)
                    {
                        cell = ReturnCell(X + dx, Y + dy);
                        if (cell != null && cell.IsMine)
                        {
                            result++;
                        }
                    }
                }
            }
            return result;
        }
        Cell? ReturnCell(int x, int y)
        {
            if (field.DoesCordExist(x, y))
            {
                return field.GetCellInf(x, y);
            }
            return null;
        }
        internal void Render()
        {
            Console.SetCursorPosition(X, Y);
            if (!IsOpen)
            {
                Console.Write('\u2588');
                return;
            }
            if (IsMine)
            {
                Console.Write('#');
                return;
            }
            int mineCount = MineCount();
            if (mineCount > 0)
            {
                Console.Write(mineCount);
                return;
            }
            Console.Write(' ');
        }
    }
}
