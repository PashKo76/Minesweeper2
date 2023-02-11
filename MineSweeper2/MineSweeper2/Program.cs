namespace MineSweeper2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(32, 16);
            Console.SetWindowSize(32, 16);
            Field field = new Field(10, 10);
            Console.WriteLine("Нажмите Любую Клавишу");
            if(Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                field.Debug();
            }
            (int X, int Y) IntInput;
            while (true)
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
            }
            //Какая нибудь логика для вывода результата
            Console.ReadKey();
        }
    }
}