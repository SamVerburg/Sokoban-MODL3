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
        public Puzzle ReadTextFile(int puzzleNr)
        {
            Tile[,] tileArray = null;
            Forklift forkLift = null;
            List<Tile> Destinations = new List<Tile>();

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

            int y = 0;

            System.IO.StreamReader file2 =
                new System.IO.StreamReader(DirectoryGoUp(System.AppDomain.CurrentDomain.BaseDirectory, 3) + @"\Puzzles\doolhof" + puzzleNr + ".txt");
            //INSERTING VALUES FROM TEXT FILE INTO TILE ARRAY
            while ((line = file2.ReadLine()) != null)
            {
                for (int x = 0; x < line.Length; x++)
                {
                    switch (line[x])
                    {
                        case '#':
                            tileArray[y, x] = new Wall();
                            break;
                        case 'x':
                            tileArray[y, x] = new Destination();
                            Destinations.Add(tileArray[y, x]);
                            break;
                        case '.':
                            tileArray[y, x] = new Floor(false);
                            break;
                        case 'o':
                            tileArray[y, x] = new Floor(true);
                            break;
                        case '@':
                            tileArray[y, x] = new Floor(false);
                            forkLift = new Forklift(y, x);
                            break;
                    }
                }
                y++;
            }
            
            return new Puzzle(tileArray, forkLift, Destinations);
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
