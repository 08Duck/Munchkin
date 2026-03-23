using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin
{
    abstract class DoorCard : Card
    {
        public DoorCard(string name, string desc) : base(name, desc) { }
    }


    class Monster : DoorCard
    {
        public int Strength { get; set; }

        public Monster(string name, int strength) : base(name, "Monster")
        {
            Strength = strength;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($" Power: {Strength}");
        }
    }

    class Curse : DoorCard
    {
        public int EffectValue { get; set; }

        public Curse(string name, int value)
            : base(name, "Curse")
        {
            EffectValue = value;
        }
    }

    class RaceCard : DoorCard
    {
        public string RaceType { get; set; }

        public RaceCard(string name, string raceType)
            : base(name, "Race")
        {
            RaceType = raceType;
        }
    }

    class ClassCard : DoorCard
    {
        public string ClassType { get; set; }

        public ClassCard(string name, string classType)
            : base(name, "Class")
        {
            ClassType = classType;
        }
    }

}

