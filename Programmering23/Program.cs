
using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
       
        Random random = new Random();

       
        List<int> abilityScores = new List<int>();

        
        for (int i = 0; i < 6; i++)
        {
            int[] rolls = new int[4];

          
            for (int j = 0; j < 4; j++)
            {
                rolls[j] = random.Next(1, 7); 
            }

          
            Array.Sort(rolls);
            Array.Reverse(rolls);

        
            int sum = rolls.Take(3).Sum();

         
            abilityScores.Add(sum);

            
            Console.WriteLine("You roll " + rolls[0] + ", " + rolls[1] + ", " + rolls[2] + ", " + rolls[3] + ". The ability score is " + sum + ".");
        }

 
        abilityScores.Sort();
        abilityScores.Reverse();

    
        Console.WriteLine("\nYour available ability scores are " + string.Join(", ", abilityScores));

    }
}
