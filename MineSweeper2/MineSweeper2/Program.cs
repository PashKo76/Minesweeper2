namespace MineSweeper2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field(90,21);
            field.RenderInterface();
            field.Render();
            

        }
    }
}