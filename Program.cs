using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int numWins = 0;
            int numLosses = 0;
            Random rnd = new Random();

            // sheep: 1, pig: 2, tractor: 3, cow: 4, dog: 5, empty: 6
            int[] spaces = { 6, 6, 1, 2, 3, 4, 5, 2, 4, 5, 1, 3, 6, 4, 2, 6, 6, 6, 3, 6, 3, 5, 1, 4, 5, 2, 3, 6, 1, 4, 6, 6, 3, 2, 1, 5, 6, 1, 4, 2 };
            int[] extras = { 3, 7, 21, 34, 38 };

            for (int i=0; i < 10000; i++)
            {
                int chicksOut = 40;
                int chicksIn = 0;
                int space = 0;
                

                while (space < 40)
                {
                    int move = rnd.Next(6);
                    if (move == 0)
                    {
                    //Console.WriteLine("Fox");
                        if (chicksIn > 0)
                        {
                            chicksIn -= 1;
                            chicksOut += 1;
                        }
                        continue;
                    }
                    int count = 0;
                    do
                    {
                        space++;
                        count++;

                        if (space >= 40)
                        {
                            break;
                        }
                    } 
                    while (spaces[space] != move);

                    if (chicksOut - count >= 0)
                    {
                        chicksOut -= count;
                        chicksIn += count;
                    }
                    else
                    {
                        chicksOut = 0;
                        chicksIn = 40;
                    }

                    if (extras.Contains(space) && chicksOut > 0)
                    {
                        chicksOut -= 1;
                        chicksIn += 1;
                    }

                /*Console.Write("Current Space: ");
                Console.WriteLine(space);
                Console.Write("Number of chicks in the coop: ");
                Console.WriteLine(chicksIn);
                Console.Write("Number of chicks out of the coop: ");
                Console.WriteLine(chicksOut);*/

                

                }
                if (chicksOut + chicksIn != 40)
                {
                    Console.WriteLine("Invalid Result");
                }
                else if (chicksOut == 0)
                {
                    //Console.WriteLine("Winner!");
                    numWins += 1;
                }
                else
                {
                    //Console.WriteLine("Loser");
                    numLosses += 1;
                }

            }
            Console.WriteLine("Number of Wins: " + numWins);
            Console.WriteLine("Number of Losses: " + numLosses);
            Console.WriteLine("press enter to exit");
            string aString = Console.ReadLine();
            Console.WriteLine("You typed: " + aString);
        }
    }
}
