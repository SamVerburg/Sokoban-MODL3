using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class FileReader
    {
        public FileReader()
        {
            ReadTextFile(1);
            Console.ReadLine();
        }

        public Puzzle ReadTextFile(int puzzleNr)
        {
            Tile[,] tileArray = null;
            Forklift forkLift = null;

            string line = "";
            int counter = 0;
            int longestLine = 0;
            System.IO.StreamReader file =
                new System.IO.StreamReader(DirectoryGoUp(System.AppDomain.CurrentDomain.BaseDirectory, 3) + @"\Puzzles\doolhof" + puzzleNr + ".txt");
            //DETERMINING WHAT SIZES THE TILEARRAY HAS TO HAVE
            while ((line = file.ReadLine()) != null)
            {
                counter++;
                if (longestLine < line.Length)
                {
                    longestLine = line.Length;
                }
            }

            tileArray = new Tile[counter, longestLine];

            counter = 0;

            System.IO.StreamReader file2 =
                new System.IO.StreamReader(DirectoryGoUp(System.AppDomain.CurrentDomain.BaseDirectory, 3) + @"\Puzzles\doolhof" + puzzleNr + ".txt");
            //INSERTING VALUES FROM TEXT FILE INTO TILE ARRAY
            while ((line = file2.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '#':
                            tileArray[counter, i] = new Wall();
                            break;
                        case 'x':
                            tileArray[counter, i] = new Destination();
                            break;
                        case '.':
                            tileArray[counter, i] = new Floor(false);
                            break;
                        case 'o':
                            tileArray[counter, i] = new Floor(true);
                            break;
                        case '@':
                            forkLift = new Forklift(counter, i);
                            break;
                    }
                }
                counter++;
            }

            //PRINTING CURRENT PUZZLE
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    if (tileArray[x, y] != null)
                    {
                        Console.Write(tileArray[x, y].ToString());
                    }
                    else
                    {
                        if (forkLift.LocX == x && forkLift.LocY == y)
                        {
                            Console.Write("@");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                }
                Console.WriteLine();
            }
            return new Puzzle(tileArray, forkLift);
        }

        //GOING UP A DIRECTORY (MIGHT BE DONE BETTER SOMEHOW BUT I COULDNT FIGURE IT OUT :()
        private string DirectoryGoUp(string path, int levelCount)
        {
            if (string.IsNullOrEmpty(path) || levelCount < 1)
                return path;

            string upperLevel = System.IO.Path.GetDirectoryName(path);

            if (--levelCount > 0)
                return DirectoryGoUp(upperLevel, levelCount);

            return upperLevel;
        }
    }
}
