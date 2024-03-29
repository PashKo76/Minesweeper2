﻿using System;
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
        Random random;
        internal int WinCellAmount { get; private set; }
        internal int HowMuchCellIsOpen = 0;
        internal bool DidILose = false;
        public Field(int Width, int Height)
        {
            random = new Random();
            Initialization(Width, Height);
        }
        public Field(int Width, int Height, int Seed)
        {
            random = new Random(Seed);
            Initialization(Width, Height);
        }
        void Initialization(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            cells = new Cell[Width, Height];
            WinCellAmount = Width * Height;
            Build();
        }
        void Build()
        {
            Walk((x, y) =>
            {
                if (random.Next(0, 9) == 0)
                {
                    cells[x, y] = new Cell(this, x, y, true);
                    WinCellAmount--;
                }
                else
                {
                    cells[x, y] = new Cell(this, x, y, false);
                }
            });
        }
        public Cell? GetCellInf(int x, int y)
        {
            if (DoesCordExist(x, y))
            {
                return cells[x, y];
            }
            return null;
        }
        public bool DoesCordExist(int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0) return false;
            return true;
        }
        internal void OpenCell(int X, int Y)
        {
            if(!DoesCordExist(X, Y))
            {
                throw new Exception("Нормальные кординаты где?");
            }
            if (cells[X, Y].IsMine)
            {
                DidILose = true;
                return;
            }
            cells[X, Y].Recursed();
        }
        internal void Debug()
        {
            Walk((x, y) => cells[x, y].IsOpen = true);
            Render();
        }
        internal void Render()
        {
            Walk((x, y) => cells[x, y].Render());
            for(int x = 0; x < Width; x++)
            {
                Console.SetCursorPosition(x, Height);
                Console.Write(x);
            }
            for(int y = 0; y < Height; y++)
            {
                Console.SetCursorPosition(Width, y);
                Console.Write(y);
            }
        }
        void Walk(Walker walker)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    walker(x, y);
                }
            }
        }
    }
}
