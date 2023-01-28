namespace MineSweeper2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(25, 15);
            Console.SetWindowSize(25, 15);
            Field field = new Field(10,10);
            while (true)
            {
                Console.Clear();
                field.Render();
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Введите (X, Y, Open)");
                string? Input = Console.ReadLine();
                (int X, int Y) IntInput;
                try
                {
                    IntInput = Control.Input(Input);
                }
                catch
                {
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