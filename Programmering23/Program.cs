
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
       
        Random random = new Random();
        List<int> abilityScores = new List<int>();


        List<int> rolls;
        int rollone;
        int rolltwo;
        int rollthree;
        int rollfour;


        int totalrolls;

        for (int i = 0; i < 6; i++)
        {
            rolls = new List<int>();

            rollone = random.Next(1, 7);
            rolltwo = random.Next(1, 7);
            rollthree = random.Next(1, 7);
            rollfour = random.Next(1, 7);

            rolls.Add(rollone);
            rolls.Add(rolltwo);
            rolls.Add(rollthree);
            rolls.Add(rollfour);

            rolls.Sort();

            totalrolls = rolls[1] + rolls[2] + rolls[3];

            Console.WriteLine("Your available ability scores are " + String.Join (", ", rolls) +" total rolls " + totalrolls);
            abilityScores.Add(totalrolls);

        }

    }
}
