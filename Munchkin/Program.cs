using System.Diagnostics;

namespace Munchkin
{
    internal class Program
    {
        // Starts the GameManager
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            game.StartGame();
            Console.ReadLine();
        }
    }
}
