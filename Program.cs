using System;
using System.Threading;

namespace Ovning_Julgran
{
    class Program
    {


        static int treeSize;
        static void Main(string[] args)
        {
            // Ask user to enter a number to determine size of tree.
            Console.Write("Hur många rader hög ska granen vara? ");
            string userInput = Console.ReadLine();
            while (!Int32.TryParse(userInput, out treeSize))
            {
                Console.WriteLine("Använd endast siffror, försök igen:");
                userInput = Console.ReadLine();
            }
            // Make an array containing odd numbers in the amount chosen by user.
            int[] tree = new int[treeSize];
            int counter = 1;
            for (int i = 0; i < treeSize; i++)
            {
                tree[i] = counter;
                counter += 2;
            }

            Console.WriteLine();
            // Print the star.
            if (treeSize > 15)
            {
                StarPrint(tree[treeSize - 1]); // tree[treeSize - 1] gets the width of the largest part of the tree
            }
            // Print the tree
            PrintTree(tree);
            PrintTrunk(tree[treeSize - 1]);

            Console.ReadKey();
        }

        static void PrintTree(int[] tree)
        {
            // Variables for controlling that there is distance between balls.
            int ballCounter = 0;
            bool tooMany = false;
            var rnd = new Random();
            int resize = 0;
            for (int i = 0; i < treeSize; i++)
            {
                // Adjust size of tree after set amount of rows
                if (i == Math.Round(((decimal)treeSize / 20) * 3) && treeSize > 15 ||
                    i == Math.Round(((decimal)treeSize / 20) * 7) && treeSize > 10 ||
                    i == Math.Round(((decimal)treeSize / 20) * 12) && treeSize > 4)
                {
                    resize += 4;
                }

                for (int j = 0; j < (tree[treeSize - 1] - (tree[i] - resize)) / 2; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < (tree[i] - resize); k++)
                {
                    // Randomize ball placement on the tree.
                    int ball = rnd.Next(4);
                    if (ball == 3 && tooMany == false)
                    {
                        BallPrint();
                        // Set boolean to true to avoid entering if-statement next round.
                        tooMany = true;
                        // Reset counter.
                        ballCounter = 0;
                    }
                    else
                    {
                        TreePrint();
                        ballCounter++;
                    }
                    // When ball has not been placed for 4 rounds, enter random-loop again.
                    if (ballCounter == 4)
                    {
                        tooMany = false;
                    }
                }

                // Go to next row.
                Console.Write("\n");
            }
        }

        // Method for printing ball with random color.
        static void BallPrint()
        {
            Random rnd = new Random();
            // Randomize 3 different colors.
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

        // Method for printing part of tree.
        static void TreePrint()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("*");
        }

        // Method for printing a star to sit atop the tree.
        static void StarPrint(int size)
        {
            // Using size to determine the center of the tree.
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

        // Method for printing tree trunk
        static void PrintTrunk(int size)
        {
            // Using size to determine the center of the tree.
            Console.ForegroundColor = ConsoleColor.DarkRed;
            char[] trunkDetails = ['/', 'W', 'X', '\\', 'Z'];
            var rnd = new Random();
            int trunkSize;
            switch (treeSize)
            {
                case < 11:
                    trunkSize = 3;
                    break;
                case > 10 and < 18:
                    trunkSize = 5;
                    break;
                case > 17:
                    trunkSize = 7;
                    break;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < (size - trunkSize) / 2; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < trunkSize; k++)
                {
                    if (k == 0)
                    {
                        Console.Write("|");
                    }
                    else if (k < trunkSize - 1)
                    {
                        Console.Write(trunkDetails[rnd.Next(0, 5)]);
                    }
                    else
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
