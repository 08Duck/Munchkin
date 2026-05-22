namespace Munchkin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            game.StartGame();
            Console.ReadLine();
        }
    }
}
