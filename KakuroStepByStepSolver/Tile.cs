using System;
using System.Collections.Generic;
using System.Text;
using Enums;

namespace Enums
{
    /*
    * TileType are to keep track if we can write to tile
    * File will contain the following:
    * "-" - Blank
    * 14/3 - botClue is 14, Right clue is 3; Other instance if only 1 clue is available "13/0" or "0/14" (Clue)
    * " " - Tile
    */
    public enum TileType
    {
        Blank,
        Clue,
        Tile
    }
}

namespace KakuroStepByStepSolver
{
    class Tile
    {

        TileType type;
        int[] marks = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int value;
        int clueBot;
        int clueRight;
        int lengthX;
        int lengthY;

        //constructor for blank tile
        public Tile(TileType type)
        {
            this.type = type;
        }
        //constructor for clue tile
        public Tile(TileType type, int clueB, int clueR)
        {
            this.type = type;
            this.clueBot = clueB;
            this.clueRight = clueR;
        }
        //constructor for writable tile (tile) (idk is for avoiding duplicate constructor)
        public Tile(TileType type, int lengthX, int lengthY, int ClueB, int ClueR)
        {
            this.type = type;
            this.lengthX = lengthX;
            this.lengthY = lengthY;
            this.clueBot = ClueB;
            this.clueRight = ClueR;
        }

        public void AddMarks(int[] numbers)
        {
            marks = new int[] { 0,0,0,0,0,0,0,0,0};
            for (int i = 0; i < numbers.Length; i++)
            {
                marks[i] = numbers[i];
            }
        }

        public void WriteValue(int value)
        {
            this.value = value;
        }

        public void WriteClues(int botClue, int rightClue)
        {
            this.clueBot = botClue;
            this.clueRight = rightClue;
        }

        public int GetValue() { return value; }
        public int[] GetMarks() { return marks; }
        public int GetMarkLength() { return marks.Length; }
        public int[] getClues() { int[] clues = { clueBot, clueRight };  return clues; }

        public void setMarkOn(int i) { marks[i] = 1; }
        public void setMarkOff(int i) { marks[i] = 0; }

        public int getLengthX() { return lengthX; }
        public int getLengthY() { return lengthY; }

        public TileType GetTileType() { return type; }

        public string getAllTileInfo()
        {
            string str = "";
            if ( type == TileType.Tile)
            {
                str += type + "\t" + value + "\t" + lengthX + "\t" + lengthY + "\t" + clueBot + "\t" + clueRight + "\t" + string.Join(",", marks);
            }
            if (type == TileType.Clue)
            {
                str += type + "\t \t \t \t" + clueBot + "\t" + clueRight;
            }
            if (type == TileType.Blank)
            {
                str += type;
            }

            return str;
        }

    }
}
