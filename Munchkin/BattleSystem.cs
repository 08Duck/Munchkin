using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    class BattleSystem
    {
        // Returns true if player wins and false if player loses
        public static bool Fight(Player player, Monster monster)
        {
            Console.WriteLine("\n=== BATTLE ===");

            // Calculate power for monster and player
            int playerPower = player.GetPower();
            int monsterPower = monster.GetPower();

            // Display power for monster and player
            Console.WriteLine($"Player Power: {playerPower}");
            Console.WriteLine($"Monster Power: {monsterPower}");

            // If player wins or ties
            if (playerPower >= monsterPower)
            {
                Console.WriteLine($"{player.Name} wins!");

                player.Level += monster.RewardLevels;

                return true;
            }
            // If player loses
            else
            {
                Console.WriteLine($"{player.Name} loses!");

                if (player.Level > 1)
                {
                    player.Level--;
                }

                return false;
            }
        }
    }
}
