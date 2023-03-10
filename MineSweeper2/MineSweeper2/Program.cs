namespace MineSweeper2
{
    delegate void Walker(int X, int Y);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(32, 16);
            Console.SetWindowSize(32, 16);
            Field field = new Field(10, 10, 1);
            Console.WriteLine("Нажмите Любую Клавишу");
            if(Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                field.Debug();
            }
            (int X, int Y) IntInput;
            int Count = 0;
            while ((field.WinCellAmount > field.HowMuchCellIsOpen) && !field.DidILose)
            {
                Console.Clear();
                field.Render();
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Введите (X, Y, Open)");
                string? Input = Console.ReadLine();
                try
                {
                    IntInput = Control.Input(Input);
                }
                catch
                {
                    Console.WriteLine("А нормально не мог ввести?");
                    Thread.Sleep(1000);
                    continue;
                }
                if (!field.DoesCordExist(IntInput.X, IntInput.Y))
                {
                    continue;
                }
                field.OpenCell(IntInput.X, IntInput.Y);
                Count++;
            }
            Thread.Sleep(1000);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            if (field.DidILose)
            {
                Console.WriteLine("Вы проиграли!");
            }
            else
            {
                Console.WriteLine("Мои поздравления!");
                Console.WriteLine($"Вы виграли за {Count} ходов!");
            }
            Console.WriteLine("Игра Закончится за 2 секунды");
            Thread.Sleep(2000);
        }
    }
}