using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper2
{
    internal class Control
    {
        static internal (int,int) Input(string? Input)
        {
            if(Input == null)
            {
                throw new Exception("Введите что-то");
            }
            string[] strings = Input.Split(' ');
            if(strings.Length > 3)
            {
                throw new Exception("Ограниченный Ввод");
            }
            int X = int.Parse(strings[0]);
            int Y = int.Parse(strings[1]);
            string Output = strings[2];
            if(Output != "Open")
            {
                throw new Exception("Команда Open где?");
            }
            return (X, Y);
        }
    }
}
