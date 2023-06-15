using System;
using System.Collections.Generic;

namespace ConsoleApp18
{
    internal class Program
    {


        
        static void SimulateCombat(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)

        {
            var random = new Random();
            var monsterHp = 0;
            var consave = 0;
            bool winning = false;
            

            for (int i = 0; i < 8; i++)
            {
                monsterHp += random.Next(1, 9);
            }
            monsterHp += 16;
            Console.WriteLine($"A basilisk with {monsterHp} hitpoints appears.");
            Console.WriteLine("");

            while (monsterHp > 0)

                
            {
                foreach (var name in characterNames)
                {
                    int total = 0;
                    for (int i = 0; i < 1; i++)
                    {
                        total += random.Next(1, 5);
                    }

                    monsterHp -= total;

                    if (monsterHp < 1)
                    {
                        monsterHp = 0;
                        Console.Write(name);
                        Console.WriteLine($" hits the basilisk for {total} damage. The basilisk has {monsterHp} HP left");
                        Console.WriteLine("");
                        Console.WriteLine($"The mighty warriors stab the beast to death.");
                        Console.WriteLine("");
                        winning = true;
                        break;
                    }
                    if (monsterHp > 0)
                    {
                        Console.Write(name);
                        Console.WriteLine($" hits the basilisk for {total} damage. The basilisk has {monsterHp} HP left");
                        Console.WriteLine("");
                    }



                }

                if (!winning)

                    
                {
                    
                    var victim = characterNames[random.Next(characterNames.Count)];
                    Console.Write($"The basilisk uses petrifying gaze on: " + $"{victim}");
                    Console.WriteLine("");

                    consave = random.Next(1, 21) + 3;

                    if (consave < 12)
                    {
                        Console.WriteLine($"{victim} rolls a total of {consave} and fails to be saved. {victim} is turned into stone.");
                        Console.WriteLine("");
                        characterNames.Remove(victim);
                    }

                    else
                    {
                        Console.WriteLine($"{victim} rolls a total of {consave} and succeeds. {victim} shruggs it off like a champ.");
                        Console.WriteLine("");
                    }

                    if (characterNames.Count == 0)
                    {
                        Console.WriteLine($"The party has failed and the basilisk continues to turn unsuspecting adventurers to stone.");
                        break;

                    }


                }




            }



        }

        static void Main(string[] args)
        {
            var characterNames = new List<string> { "Buck", "Brick", "Chuck", "Larry" };

            Console.Write($"Fighters ");
            Console.Write(string.Join(", ", characterNames));
            Console.WriteLine($" descend into the dungeon.");
            Console.WriteLine("");

            SimulateCombat();



        }
    }
}
