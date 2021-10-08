using System;
using System.Collections.Generic;
using System.Text;
using Enums;

namespace KakuroStepByStepSolver
{
    class Board
    {
        int x_size; // horizontal length (<->)
        int y_size; // vertizal length
        Tile[,] tiles;

        public Board(int x, int y, string[,] fileTiles)
        {
            x_size = x;
            y_size = y;

            this.tiles = new Tile[fileTiles.GetLength(0), fileTiles.GetLength(1)];

            for (int i = 0; i < fileTiles.GetLength(0); i++)
            {
                for (int j = 0; j < fileTiles.GetLength(1); j++)
                {
                    TileType type;
                    //could optimise this... somehow... maybe Blank and Tile under 1 if and then split there?
                    if (fileTiles[i,j].Contains("-"))
                    {
                        type = TileType.Blank;
                        this.tiles[i, j] = new Tile(type);
                    }
                    else if (fileTiles[i, j].Contains("/"))
                    {
                        type = TileType.Clue;

                        string[] clues = fileTiles[i, j].Split("/");

                        int ClueB = int.Parse(clues[0]);
                        int ClueR = int.Parse(clues[1]);

                        this.tiles[i, j] = new Tile(type,ClueB,ClueR);
                    }
                    else
                    {
                        type = TileType.Tile;
                        int xlength = getXLength(i, j, fileTiles);
                        int ylength = getYLength(i, j, fileTiles);
                        int ClueB = getBotClue(i, j, fileTiles);
                        int ClueR = getRightClue(i, j, fileTiles);
                        this.tiles[i, j] = new Tile(type, xlength, ylength, ClueB, ClueR);
                    }

                    

                }
            }
        }

        public string printBoard()
        {
            string str = "";
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    str += tiles[i, j] + " ";
                }
                str += "\n";
            }

            return str;
        }

        public string printAllTileInfo()
        {
            string str = "";
            str += "Tile info:" +  "\t" + "type" + "\t" + "value" + "\t" + "lengthX" + "\t" + "lengthY" + "\t" + "clueBot" + "\t" + "clueRight" + "\t" + "marks \n";
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    str += "Tile_loc " + i + " " + j + ": \t" + tiles[i,j].getAllTileInfo() + "\n";
                }
            }

            return str;
        }
        private int getXLength(int x, int y, string[,] fileTiles) 
        {
            int ans = 1;
            int x_right = x;
            int x_left = x;

            while (fileTiles[x_right,y] == " ") 
            {
                if (x_right+1 >= x_size)
                    break;

                x_right++;
                ans++;
            }

            while (fileTiles[x_left, y] == " ")
            {
                if (x_left - 1 <= 0)
                    break;

                x_left--;
                ans++;
            }

            return ans;
        }

        private int getYLength(int x, int y, string[,] fileTiles)
        {
            int ans = 1;
            int y_top = x;
            int y_bot = x;

            while (fileTiles[x, y_top] == " ")
            {
                if (y_top + 1 >= y_size)
                    break;

                y_top++;
                ans++;
            }

            while (fileTiles[x, y_bot] == " ")
            {
                if (y_bot - 1 <= 0)
                    break;

                y_bot--;
                ans++;
            }

            return ans;
        }

        private int getBotClue(int x, int y, string[,] fileTiles)
        {
            int ans = -1;
            int x_curr = x;
            
            for (int i = x; i >= 0; i--)
            {
                if (fileTiles[i,y].Contains("/"))
                {
                    ans = Int16.Parse(fileTiles[i, y].Split("/")[0]);
                    return ans;
                }
            }
            return -1;
        }

        private int getRightClue(int x, int y, string[,] fileTiles)
        {
            int ans = -1;
            int y_curr = x;

            for (int i = y; i >= 0; i--)
            {
                if (fileTiles[x, i].Contains("/"))
                {
                    ans = Int16.Parse(fileTiles[x, i].Split("/")[1]);
                    return ans;
                }
            }
            return -1;
        }

        public int getXSize() { return x_size; }
        public int getYSize() { return y_size; }
        public Tile getTile(int i, int j) { return tiles[i, j]; }
    }
}
