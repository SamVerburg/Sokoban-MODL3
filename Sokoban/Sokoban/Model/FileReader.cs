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
            Tile first = null;
            Tile[,] tileArray = null;
            Forklift forklift = null;
            Employee employee = null;
            List<Chest> chests = new List<Chest>();

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
                            break;
                        case '.':
                            tileArray[y, x] = new Floor();
                            break;
                        case 'o':
                            tileArray[y, x] = new Floor();
                            Chest c = new Chest(tileArray[y, x]);
                            tileArray[y, x].MovableObject = c;
                            chests.Add(c);
                            break;
                        case '@':
                            tileArray[y, x] = new Floor();
                            tileArray[y, x].MovableObject = new Forklift(tileArray[y, x]);
                            forklift = (Forklift)tileArray[y, x].MovableObject;
                            break;
                        case ' ':
                            tileArray[y, x] = new Empty();
                            break;
                        case '~':
                            tileArray[y, x] = new Pit();
                            break;
                        case '$':
                            tileArray[y, x] = new Floor();
                            tileArray[y, x].MovableObject = new Employee(tileArray[y, x]);
                            employee = (Employee)tileArray[y, x].MovableObject;
                            break;
                    }
                }
                y++;
            }

            first = tileArray[0, 0];
            int width = tileArray.GetLength(1) - 1;
            int height = tileArray.GetLength(0) - 1;
            for (int x2 = 0; x2 <= width; x2++)
            {
                for (int y2 = 0; y2 <= height; y2++)
                {
                    Tile currentTile = tileArray[y2, x2];
                    if (x2 + 1 <= width)
                    {
                        currentTile.Right = tileArray[y2, x2 + 1];
                    }
                    if (x2 - 1 >= 0)
                    {
                        currentTile.Left = tileArray[y2, x2 - 1];
                    }
                    if (y2 + 1 <= height)
                    {
                        currentTile.Down = tileArray[y2 + 1, x2];
                    }
                    if (y2 - 1 >= 0)
                    {
                        currentTile.Up = tileArray[y2 - 1, x2];
                    }
                }
            }
            return new Puzzle(first,forklift,employee,chests);
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
