using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper2
{
    internal class Field
    {
        int Width;
        int Height;
        Cell[,] cells;
        public Field(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            cells = new Cell[Width, Height];
            Build();
        }
        public void OpenCell(int X, int Y)
        {
            cells[X, Y].OpenCell();
        }
        void Build()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cells[x, y] = new Cell(this, x, y);
                }
            }
            //for (int x = 0; x < Width; x++)
            //{
            //    for (int y = 0; y < Height; y++)
            //    {
            //        cells[x, y].HaveItMineN();
            //    }
            //}
        }
        public Cell? GetCellInf(int x, int y)
        {
            if (DoesCordExist(x, y))
            {
                return cells[x, y];
            }
            return null;
        }
        public void Render()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    cells[x, y].Render();
                }
                //Console.WriteLine();
            }
        }
        public bool DoesCordExist(int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0) return false;
            return true;
        }
    }
}
