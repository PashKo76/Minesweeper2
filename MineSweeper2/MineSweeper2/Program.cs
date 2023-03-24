namespace MineSweeper2
{
    delegate void Walker(int X, int Y);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(32, 16);
            Console.SetBufferSize(32, 16);
            Field field = new Field(10, 10);
            (int X, int Y) IntInput;
            int Count = 0;
            while ((field.WinCellAmount > field.HowMuchCellIsOpen) && !field.DidILose)
            {
                Console.Clear();
                field.Render();
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Enter Cordinate (X, Y, Open)");
                string? Input = Console.ReadLine();
                try
                {
                    IntInput = Control.Input(Input);
                }
                catch
                {
                    Console.WriteLine("Error, try again!");
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
            field.Render();
            Thread.Sleep(1000);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            if (field.DidILose)
            {
                Console.WriteLine("You Lose!");
            }
            else
            {
                Console.WriteLine("Congratulation!");
                Console.WriteLine($"you won in {Count} moves!");
            }
            Console.WriteLine("the game will end in 2 seconds");
            Thread.Sleep(2000);
        }
    }
}