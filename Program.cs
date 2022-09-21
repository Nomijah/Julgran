using System;

namespace Ovning_Julgran
{
    class Program
    {
        // Method for printing ball with random color
        static void BallPrint()
        {
            Random rnd = new Random();
            // Randomize 3 different colors
            int clr = rnd.Next(3);
            if (clr == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("o");
            }
            else if (clr == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("o");
            }
            else if (clr == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("o");
            }
        }
        // Method for printing part of tree
        static void TreePrint()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("*");
        }
        // Method for printing a star to sit atop the tree
        static void StarPrint(int size)
        {
            // Using size to determine the center of the tree
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int j = 0; j < (size - 1) / 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("*");
            Console.WriteLine();
            for (int j = 0; j < (size - 3) / 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("***");
            Console.WriteLine();
            for (int j = 0; j < (size - 9) / 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("*********");
            Console.WriteLine();
            for (int j = 0; j < (size - 5) / 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("*****");
            Console.WriteLine();
            for (int j = 0; j < (size - 3) / 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("***");
            Console.WriteLine();
            for (int j = 0; j < (size - 5) / 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("** **");
            Console.WriteLine();
            for (int j = 0; j < (size - 7) / 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("** I **");
            Console.WriteLine();
            for (int j = 0; j < (size - 9) / 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("*   I   *");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            // Ask user to enter a number to determine size of tree
            Console.Write("Hur många rader hög ska granen vara? ");
            string userInput = Console.ReadLine();
            int userNumber;
            while (!Int32.TryParse(userInput, out userNumber))
            {
                Console.WriteLine("Använd endast siffror, försök igen:");
                userInput = Console.ReadLine();
            }
            // Make an array containing odd numbers in the amount chosen by user
            int[] tree = new int[userNumber];
            int counter = 1;
            for (int i = 0; i < userNumber; i++)
            {
                tree[i] = counter;
                counter += 2;
            }
            // Print out the star
            StarPrint(tree[userNumber - 1]);
            // Create rnd nmb generator
            Random rnd = new Random();
            // Variables for controlling that there is distance between balls
            int ballCounter = 0;
            bool tooMany = false;

            for (int i = 0; i < userNumber; i++)
            {
                if (i < 4)
                {
                    for (int j = 0; j < (tree[userNumber - 1] - tree[i]) / 2; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < tree[i]; k++)
                    {
                        // Randomize ball placement on the tree
                        int ball = rnd.Next(4);
                        if (ball == 3 && tooMany == false)
                        {
                            BallPrint();
                            // Set boolean to true to avoid entering if-statement next round
                            tooMany = true;
                            // Reset counter
                            ballCounter = 0;
                        }
                        else
                        {
                            TreePrint();
                            ballCounter++;
                        }
                        // When ball has not been placed for 4 rounds, enter random-loop again
                        if (ballCounter == 4)
                        {
                            tooMany = false;
                        }
                    }
                }
                // Adjust size of tree after 4 rounds
                else if (i >= 4 && i < 9)
                {
                    for (int j = 0; j < (tree[userNumber - 1] - (tree[i] - 4)) / 2; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < (tree[i] - 4); k++)
                    {
                        int ball = rnd.Next(4);
                        if (ball == 3 && tooMany == false)
                        {
                            BallPrint();
                            tooMany = true;
                            ballCounter = 0;
                        }
                        else
                        {
                            TreePrint();
                            ballCounter++;
                        }
                        if (ballCounter == 4)
                        {
                            tooMany = false;
                        }
                    }
                }
                // Adjust size of tree again
                else if (i >= 9 && i < 17)
                {
                    for (int j = 0; j < (tree[userNumber - 1] - (tree[i] - 8)) / 2; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < (tree[i] - 8); k++)
                    {
                        int ball = rnd.Next(4);
                        if (ball == 3 && tooMany == false)
                        {
                            BallPrint();
                            tooMany = true;
                            ballCounter = 0;
                        }
                        else
                        {
                            TreePrint();
                            ballCounter++;
                        }
                        if (ballCounter == 4)
                        {
                            tooMany = false;
                        }
                    }
                }
                // Adjust size of tree one last time
                else if (i >= 17)
                {
                    for (int j = 0; j < (tree[userNumber - 1] - (tree[i] - 12)) / 2; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < (tree[i] - 12); k++)
                    {
                        int ball = rnd.Next(4);
                        if (ball == 3 && tooMany == false)
                        {
                            BallPrint();
                            tooMany = true;
                            ballCounter = 0;
                        }
                        else
                        {
                            TreePrint();
                            ballCounter++;
                        }
                        if (ballCounter == 4)
                        {
                            tooMany = false;
                        }
                    }
                }
                // Go to next row
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
