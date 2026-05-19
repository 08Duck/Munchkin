using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    // Base class for all Door Cards
    abstract class DoorCard : Card
    {
        public DoorCard(string name, string desc)
            : base(name, desc)
        {

        }
    }

    // Monster cards 
    class MonsterCard : DoorCard
    {
        // Monster stored inside card
        public Monster Enemy { get; set; }

        public MonsterCard(Monster enemy)
            : base(enemy.Name, "Monster")
        {
            Enemy = enemy;
        }

        // Displays monster card
        public override void Display()
        {
            base.Display();

            Console.WriteLine("=== MONSTER INFO ===");
            Console.WriteLine($"Name: {Enemy.Name}");
            Console.WriteLine($"Level: {Enemy.Level}");
            Console.WriteLine($"Reward Levels: {Enemy.RewardLevels}\n");
        }
    }

    // Curse cards
    class Curse : DoorCard
    {
        // positive or negative effect
        public int EffectValue { get; set; }

        public Curse(string name, int value)
            : base(name, "Curse")
        {
            EffectValue = value;
        }

        // Displays curse
        public override void Display()
        {
            base.Display();

            Console.WriteLine($"Curse Value: {EffectValue}");
        }
    }

    // Race cards
    class RaceCard : DoorCard
    {
        // Stores race type
        public string RaceType { get; set; }

        public RaceCard(string name, string raceType)
            : base(name, "Race")
        {
            RaceType = raceType;
        }

        // Displays race
        public override void Display()
        {
            base.Display();

            Console.WriteLine($"Race: {RaceType}");
        }
    }

    // Class cards
    class ClassCard : DoorCard
    {
        // Stores class types
        public string ClassType { get; set; }

        public ClassCard(string name, string classType)
            : base(name, "Class")
        {
            ClassType = classType;
        }

        // Displays class
        public override void Display()
        {
            base.Display();

            Console.WriteLine($"Class: {ClassType}");
        }
    }
}

