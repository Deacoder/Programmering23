using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> heroes = new List<string>() { "Mizuki", "Ragnar", "Madara", "Rimuru" };
        SimulateCombat(heroes, "orc", DiceRoll(2, 8, 6), 10);
        SimulateCombat(heroes, "Azer", DiceRoll(6, 8, 12), 10);
        SimulateCombat(heroes, "Troll", DiceRoll(8, 10, 40), 10);
    }

    static void SimulateCombat(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)
    {
        Random random = new Random();

        Console.WriteLine("Fighters " + string.Join(", ", characterNames) + " descend into the dungeon.");

        Console.WriteLine("A " + monsterName + " with " + monsterHP + " HP appears!");

        while (monsterHP > 0 && characterNames.Count > 0)
        {
            Console.WriteLine("Characters' turn:");
            foreach (string hero in characterNames)
            {
                int Dmg = DiceRoll(2, 6);
                monsterHP -= Dmg;

                if (monsterHP <= 0)
                {
                    monsterHP = 0;
                }
                Console.WriteLine(hero + " hits the " + monsterName + " for " + Dmg + " damage. " + monsterName + " has " + monsterHP);

                if (monsterHP <= 0)
                {
                    break;
                }
            }

            if (monsterHP <= 0)
            {
                break;
            }

            Console.WriteLine("\n" + monsterName + "'s turn:");
            string RH = characterNames[random.Next(characterNames.Count)];
            Console.WriteLine(monsterName + " uses petrifying gaze on " + RH + ".");

            int roll = DiceRoll(1, 20, 3);
            if (roll >= savingThrowDC)
            {
                Console.WriteLine("The roll is " + roll + ". " + RH + " is saved!");
            }
            else
            {
                Console.WriteLine("The roll is " + roll + ". " + RH + " got turned into stone!");
                characterNames.Remove(RH);

                if (characterNames.Count == 0)
                {
                    Console.WriteLine("\nGame over: All heroes have turned into stone. The " + monsterName + " wins.");
                    return;
                }
            }

            Console.WriteLine("\nCurrent status:");
            Console.WriteLine(monsterName + "'s health: " + monsterHP);
            Console.WriteLine("Heroes:");
            foreach (string hero in characterNames)
            {
                Console.WriteLine(hero);
            }

            Console.WriteLine("\n---------------------------------------\n");
        }

        Console.WriteLine("The " + monsterName + " collapses, and the heroes celebrate their victory!");
    }

    static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
    {
        Random random = new Random();
        int result = 0;

        for (int i = 0; i < numberOfRolls; i++)
        {
            result += random.Next(1, diceSides + 1);
        }

        result += fixedBonus;

        return result;
    }
}