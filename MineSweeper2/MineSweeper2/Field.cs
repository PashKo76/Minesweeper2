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
        int IndentY;
        int IndentX;

        Cell[,] cells;
        public bool Lose { get; set; }
        public Field(int Width, int Height)
        {
            Lose = false;
            this.Width = Width;
            this.Height = Height;
            cells = new Cell[Width, Height];
            Build();
            CalculateIndent();
        }
        void CalculateIndent()
        {
            for (int ky = 3; ky > 0; ky--)
            {
                if (Height > Exponentiation(10, ky - 1))
                {
                    IndentY = ky;
                    break;
                }
            }
            for (int kx = 3; kx > 0; kx--)
            {
                if (Width > Exponentiation(10, kx - 1))
                {
                    IndentX = kx;
                    break;
                }
            }
        }
        int Exponentiation(int Operand1, int Operand2)
        {
            int Result = 1;
            if (Operand2 == 0) return 1;
            for(int t = 0; t < Operand2; t++)
            {
                Result *= Operand1;
            }
            return Result;

        }
        public void RenderInterface()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write('#');
            for (int x = 0; x < Width; x++)
            {
                Console.SetCursorPosition(IndentY + x * IndentX, 0);
                Console.Write(x);
            }
            for (int y = 0; y < Height; y++)
            {
                Console.SetCursorPosition(0, y + 1);
                Console.Write(y);
            }
        }
        void UpdateCell()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cells[x, y].AmIVisible();
                }
            }
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
                    Console.SetCursorPosition(IndentY + x * IndentX, y + 1);
                    cells[x, y].Render();
                }
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
