using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    class Monster : Character
    {
        // Levels rewarded for the player if defeated
        public int RewardLevels { get; set; }

        // Presets the name, level and reward
        public Monster(string name, int level, int rewards)
            : base(name, level)
        {
            RewardLevels = rewards;
        }

        // Displays the stats of the monster
        public override void DisplayStats()
        {
            Console.WriteLine("=== MONSTER ===");
            Console.WriteLine($"{Name}");
            Console.WriteLine($"Level: {Level}");
        }
    }
}
