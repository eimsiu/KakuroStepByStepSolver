using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KakuroStepByStepSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "C:\\Users\\eima\\source\\repos\\KakuroStepByStepSolver\\3_3 puzzle.txt";

            var lineCount = File.ReadLines(filename).Count();
            System.Console.WriteLine("x count: " + lineCount);
            int lengthCount = File.ReadLines(filename).First().Split(",").Length;
            System.Console.WriteLine("y count: " + lengthCount);

            string[,] fileTiles = new string[lineCount, lengthCount];


            int counter = 0;
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);

                string[] splitLine = line.Split(",");
                
                for (int i = 0; i < splitLine.Count(); i++)
                {
                    fileTiles[counter, i] = splitLine[i];
                }

                counter++;
            }

            file.Close();
            //System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen. 
            System.Console.WriteLine();
            System.Console.WriteLine();

            //for (int i = 0; i < fileTiles.GetLength(0); i++)
            //{
            //    for (int j = 0; j < fileTiles.GetLength(1); j++)
            //    {
            //        System.Console.Write(fileTiles[i, j] + " ");
            //    }
            //    System.Console.WriteLine();
            //}

            Board board = new Board(lineCount, lengthCount, fileTiles);
            Solver solver = new Solver(board);

            System.Console.WriteLine(board.printBoard());
            System.Console.WriteLine(board.printAllTileInfo());

            solver.WriteMarkups();
            System.Console.WriteLine("All markups written");
            System.Console.WriteLine(board.printAllTileInfo());







            
            /*
             * Fancy way of getting partitions with error proof
            string value;
            if (unique_partitions[2].TryGetValue(3, out value))
            {
                Console.WriteLine("Fetched value: {0}", value);
            }
            else
            {
                Console.WriteLine("No such key");
            }

            if (unique_partitions[2].TryGetValue(6, out value))
            {
                Console.WriteLine("Fetched value: {0}", value);
            }
            else
            {
                Console.WriteLine("No such key");
            }
            */
        }

    }
}
