using System.Reflection.Emit;

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");
        Console.Write("Choose an option> ");

        var userInput = Console.ReadLine();

        var lines = File.ReadAllLines("input.csv");

        if (userInput == "1") // list the pre-existing characters
        {
            foreach (var line in lines)
            {
                var cols = line.Split(",");
                var name = cols[0];
                var charClass = cols[1];
                var lvl = cols[2];
                var hp = cols[3];
                var equipment = cols[4].Split("|");

                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Class: {charClass}");
                Console.WriteLine($"Level: {lvl}");
                Console.WriteLine($"HP: {hp}");

                Console.WriteLine("Character Equipment:");
                foreach (var equip in equipment)
                {
                    Console.WriteLine($"\t{equip}");
                }
                Console.WriteLine("------------------\n");
            }
        }
        else if (userInput == "2") // Add a character to the list
        {
            Console.Write("\nEnter your character's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your character's class: ");
            string characterClass = Console.ReadLine();

            Console.Write("Enter your character's level: ");
            int level = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's health points: ");
            int hp = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's equipment (separate items with a '|'): ");
            string equipment = Console.ReadLine();

            var newChartacter = $"{name},{characterClass},{level},{hp},{equipment}";

            using (StreamWriter writer = new StreamWriter("input.csv", true))
            {
                writer.WriteLine(newChartacter);
            }
        }
        else if (userInput == "3") // Update an existing character
        {
            List<string> tempFile = new List<string>(); // this list will store all of the lines of the csv file

            Console.WriteLine("\nList of Characters: ");

            foreach (var line in lines) // foreach loop lists the names of all the characters
            {
                var cols = line.Split(",");
                var name = cols[0];

                Console.WriteLine($"\t{name}");
            }

            Console.Write("\nType in the name of the character you want to update> "); // user selects which character they want to update
            userInput = Console.ReadLine();

            foreach (var line in lines)
            {
                var cols = line.Split(",");
                var name = cols[0];
                var charClass = cols[1];
                var lvl = cols[2];
                var hp = cols[3];
                var equipment = cols[4];

                if (name == userInput) // if the name matches the one the user entered, then the new information gets added
                {
                    Console.Write("\nUpdate your character's name: ");
                    name = Console.ReadLine();

                    Console.Write("Update your character's class: ");
                    charClass = Console.ReadLine();

                    Console.Write("Update your character's level: ");
                    lvl = Console.ReadLine();

                    Console.Write("Update your character's health points: ");
                    hp = Console.ReadLine();

                    Console.Write("Update your character's equipment (separate items with a '|'): ");
                    equipment = Console.ReadLine();

                    tempFile.Add($"{name},{charClass},{lvl},{hp},{equipment}");
                }
                else
                {
                    tempFile.Add($"{name},{charClass},{lvl},{hp},{equipment}");
                }
            }

            File.WriteAllText("input.csv", string.Empty); // delete all previous data in preparation to add updated data

            using (StreamWriter writer = new StreamWriter("input.csv", true))
            {
                foreach (var fileLine in tempFile)
                {
                    writer.WriteLine($"{fileLine}");
                }
            }
        }
        else // if the user enters something other than 1, 2, or 3, then the program quits
        {
            Console.WriteLine("Unreconized option selected");
        }
    }
}