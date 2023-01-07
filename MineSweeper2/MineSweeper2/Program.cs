namespace MineSweeper2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(10,10);
            field.Render();
            field.OpenCell(1, 1);
            Console.SetCursorPosition(0, 11);
        }
    }
}