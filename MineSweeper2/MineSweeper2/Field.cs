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
        void Build()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cells[x, y] = new Cell(this, x, y);
                }
            }
        }
        public Cell GetCellInf(int x, int y)
        {
            return cells[x, y];
        }
        public void Render()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    cells[x, y].Render();
                }
                Console.WriteLine();
            }
        }
        public bool DoesCordExist(int x, int y)
        {
            bool bX;
            bool bY;
            if (x >= Width) bX = false;
            else if (x < 0) bX = false;
            else bX = true;
            if (y >= Height) bY = false;
            else if (y < 0) bY = false;
            else bY = true;
            return bX && bY;
        }
    }
}
