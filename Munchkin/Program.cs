namespace Munchkin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creates a new player called William
            Player player = new Player("William");

            // Creates example items
            Weapon sword = new Weapon("Big sword", 3);
            Armor armor = new Armor("Chestplate", 2);

            // Adds items to hand
            player.AddCardToHand(sword);
            player.AddCardToHand(armor);

            // Equips items from hand
            player.EquipItem(sword);
            player.EquipItem(armor);

            // Example of a monster
            Monster goblin = new Monster("Goblin", 2, 1);

            // Place the monster inside of MonsterCard
            MonsterCard monsterCard = new MonsterCard(goblin);

            player.DisplayStats();
            monsterCard.Display();

            // Start battle between player and monster
            BattleSystem.Fight(player, goblin);

            Console.WriteLine("\nAfter battle: ");

            // Player stats after battle
            player.DisplayStats();
            Console.ReadLine();
        }
    }
}
