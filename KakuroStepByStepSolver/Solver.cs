using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Enums;

namespace KakuroStepByStepSolver
{
    class Solver
    {
        Board board;
        //int[,] uniquePartitions = new int { {null}, {null}, {1,2 } };   //need to figure how to define this...
        Dictionary<int,Dictionary<int,string>> unique_partitions = new Dictionary<int,  Dictionary<int, string>>();
        Dictionary<int, Dictionary<int, string[]>> all_partitions = new Dictionary<int, Dictionary<int, string[]>>();

        public Solver(Board board) 
        {
            this.board = board;

            Dictionary<int, string> parts2 = new Dictionary<int, string>();
            parts2.Add(3, "1+2");
            parts2.Add(4, "1+3");
            parts2.Add(16, "7+9");
            parts2.Add(17, "8+9");

            Dictionary<int, string> parts3 = new Dictionary<int, string>();
            parts3.Add(6, "1+2+3");
            parts3.Add(7, "1+2+4");
            parts3.Add(23, "6+8+9");
            parts3.Add(24, "7+8+9");

            Dictionary<int, string> parts4 = new Dictionary<int, string>();
            parts4.Add(10, "1+2+3+4");
            parts4.Add(11, "1+2+3+5");
            parts4.Add(29, "5+7+8+9");
            parts4.Add(30, "6+7+8+9");

            Dictionary<int, string> parts5 = new Dictionary<int, string>();
            parts5.Add(15, "1+2+3+4+5");
            parts5.Add(16, "1+2+3+4+6");
            parts5.Add(34, "4+6+7+8+9");
            parts5.Add(35, "5+6+7+8+9");

            Dictionary<int, string> parts6 = new Dictionary<int, string>();
            parts6.Add(21, "1+2+3+4+5+6");
            parts6.Add(22, "1+2+3+4+5+7");
            parts6.Add(38, "3+5+6+7+8+9");
            parts6.Add(39, "4+5+6+7+8+9");

            Dictionary<int, string> parts7 = new Dictionary<int, string>();
            parts7.Add(28, "1+2+3+4+5+6+7");
            parts7.Add(29, "1+2+3+4+5+6+8");
            parts7.Add(41, "2+4+5+6+7+8+9");
            parts7.Add(42, "3+4+5+6+7+8+9");

            Dictionary<int, string> parts8 = new Dictionary<int, string>();
            parts8.Add(36, "1+2+3+4+5+6+7+8");
            parts8.Add(37, "1+2+3+4+5+6+7+9");
            parts8.Add(38, "1+2+3+4+5+6+8+9");
            parts8.Add(39, "1+2+3+4+5+7+8+9");
            parts8.Add(40, "1+2+3+4+6+7+8+9");
            parts8.Add(41, "1+2+3+5+6+7+8+9");
            parts8.Add(42, "1+2+4+5+6+7+8+9");
            parts8.Add(43, "1+3+4+5+6+7+8+9");
            parts8.Add(44, "2+3+4+5+6+7+8+9");

            Dictionary<int, string> parts9 = new Dictionary<int, string>();
            parts9.Add(45, "1+2+3+4+5+6+7+8+9");

            unique_partitions.Add(2, parts2);
            unique_partitions.Add(3, parts3);
            unique_partitions.Add(4, parts4);
            unique_partitions.Add(5, parts5);
            unique_partitions.Add(6, parts6);
            unique_partitions.Add(7, parts7);
            unique_partitions.Add(8, parts8);
            unique_partitions.Add(9, parts9);

            //Dictionary<int, Dictionary<int, string[]>> all_partitions = new Dictionary<int, Dictionary<int, string[]>>();

            Dictionary<int, string[]> part2 = new Dictionary<int, string[]>();
            part2.Add(3, new string[] { "1+2" });
            part2.Add(4, new string[] { "1+3" });
            part2.Add(5, new string[] { "1+4", "2+3" });
            part2.Add(6, new string[] { "1+5", "2+4" });
            part2.Add(7, new string[] { "1+6","2+5","3+4" });
            part2.Add(8, new string[] { "1+7","2+6","3+5" });
            part2.Add(9, new string[] { "1+8","2+7","3+6","4+5" });
            part2.Add(10,new string[] { "1+9","2+8","3+7","4+6" });
            part2.Add(11,new string[] { "2+9","3+8","4+7","5+6" });
            part2.Add(12,new string[] { "3+9","4+8","5+7" });
            part2.Add(13,new string[] { "4+9","5+8","6+7" });
            part2.Add(14,new string[] { "5+9","6+8" });
            part2.Add(15,new string[] { "6+9","7+8" });
            part2.Add(16,new string[] { "7+9" });
            part2.Add(17,new string[] { "8+9" });

            Dictionary<int, string[]> part3 = new Dictionary<int, string[]>();
            part3.Add(6, new string[] { "1+2+3" });
            part3.Add(7, new string[] { "1+2+4" });
            part3.Add(8, new string[] { "1+2+5","1+3+4" });
            part3.Add(9, new string[] { "1+2+6","1+3+5","2+3+4" });
            part3.Add(10,new string[] {"1+2+7","1+3+6","1+4+5", "2+3+5" });
            part3.Add(11,new string[] {"1+2+8","1+3+7","1+4+6","2+3+6", "2+4+5" });
            part3.Add(12,new string[] {"1+2+9","1+3+8","1+4+7","1+5+6","2+3+7","2+4+6", "3+4+5" });
            part3.Add(13,new string[] {"1+3+9","1+4+8","1+5+7","2+3+8","2+4+7","2+5+6", "3+4+6" });
            part3.Add(14,new string[] {"1+4+9","1+5+8","1+6+7","2+3+9","2+4+8","2+5+7","3+4+7", "3+5+6" });
            part3.Add(15,new string[] {"1+5+9","1+6+8","2+4+9","2+5+8","2+6+7","3+4+8","3+5+7", "4+5+6" });
            part3.Add(16,new string[] {"1+6+9","1+7+8","2+5+9","2+6+8","3+4+9","3+5+8","3+6+7", "4+5+7" });
            part3.Add(17,new string[] {"1+7+9","2+6+9","2+7+8","3+5+9","3+6+8","4+5+8", "4+6+7" });
            part3.Add(18,new string[] {"1+8+9","2+7+9","3+6+9","3+7+8","4+5+9","4+6+8", "5+6+7" });
            part3.Add(19,new string[] {"2+8+9","3+7+9","4+6+9","4+7+8", "5+6+8" });
            part3.Add(20,new string[] {"3+8+9","4+7+9","5+6+9", "5+7+8" });
            part3.Add(21,new string[] {"4+8+9","5+7+9", "6+7+8" });
            part3.Add(22,new string[] {"5+8+9", "6+7+9" });
            part3.Add(23,new string[] { "6+8+9" });
            part3.Add(24,new string[] { "7+8+9" });

            Dictionary<int, string[]> part4 = new Dictionary<int, string[]>();
            part4.Add(10,new string[] {"1+2+3+4" });
            part4.Add(11,new string[] {"1+2+3+5" });
            part4.Add(12,new string[] {"1+2+3+6","1+2+4+5" });
            part4.Add(13,new string[] {"1+2+3+7","1+2+4+6","1+3+4+5" });
            part4.Add(14,new string[] {"1+2+3+8","1+2+4+7","1+2+5+6","1+3+4+6","2+3+4+5" });
            part4.Add(15,new string[] {"1+2+3+9","1+2+4+8","1+2+5+7","1+3+4+7","1+3+5+6","2+3+4+6" });
            part4.Add(16,new string[] {"1+2+4+9","1+2+5+8","1+2+6+7","1+3+4+8","1+3+5+7","1+4+5+6","2+3+4+7","2+3+5+6" });
            part4.Add(17,new string[] {"1+2+5+9","1+2+6+8","1+3+4+9","1+3+5+8","1+3+6+7","1+4+5+7","2+3+4+8","2+3+5+7","2+4+5+6" });
            part4.Add(18,new string[] {"1+2+6+9","1+2+7+8","1+3+5+9","1+3+6+8","1+4+5+8","1+4+6+7","2+3+4+9","2+3+5+8","2+3+6+7","2+4+5+7","3+4+5+6" });
            part4.Add(19,new string[] {"1+2+7+9","1+3+6+9","1+3+7+8","1+4+5+9","1+4+6+8","1+5+6+7","2+3+5+9","2+3+6+8","2+4+5+8","2+4+6+7","3+4+5+7" });
            part4.Add(20,new string[] {"1+2+8+9","1+3+7+9","1+4+6+9","1+4+7+8","1+5+6+8","2+3+6+9","2+3+7+8","2+4+5+9","2+4+6+8","2+5+6+7","3+4+5+8","3+4+6+7" });
            part4.Add(21,new string[] {"1+3+8+9","1+4+7+9","1+5+6+9","1+5+7+8","2+3+7+9","2+4+6+9","2+4+7+8","2+5+6+8","3+4+5+9","3+4+6+8","3+5+6+7" });
            part4.Add(22,new string[] {"1+4+8+9","1+5+7+9","1+6+7+8","2+3+8+9","2+4+7+9","2+5+6+9","2+5+7+8","3+4+6+9","3+4+7+8","3+5+6+8","4+5+6+7" });
            part4.Add(23,new string[] {"1+5+8+9","1+6+7+9","2+4+8+9","2+5+7+9","2+6+7+8","3+4+7+9","3+5+6+9","3+5+7+8","4+5+6+8" });
            part4.Add(24,new string[] {"1+6+8+9","2+5+8+9","2+6+7+9","3+4+8+9","3+5+7+9","3+6+7+8","4+5+6+9","4+5+7+8" });
            part4.Add(25,new string[] {"1+7+8+9","2+6+8+9","3+5+8+9","3+6+7+9","4+5+7+9","4+6+7+8" });
            part4.Add(26,new string[] {"2+7+8+9","3+6+8+9","4+5+8+9","4+6+7+9","5+6+7+8" });
            part4.Add(27,new string[] {"3+7+8+9","4+6+8+9","5+6+7+9" });
            part4.Add(28,new string[] {"4+7+8+9","5+6+8+9" });
            part4.Add(29,new string[] {"5+7+8+9" });
            part4.Add(30,new string[] {"6+7+8+9" });

            Dictionary<int, string[]> part5 = new Dictionary<int, string[]>();
            part5.Add(15,new string[] { "1+2+3+4+5" });
            part5.Add(16,new string[] { "1+2+3+4+6" });
            part5.Add(17,new string[] {"1+2+3+4+7", "1+2+3+5+6" });
            part5.Add(18,new string[] {"1+2+3+4+8","1+2+3+5+7", "1+2+4+5+6" });
            part5.Add(19,new string[] {"1+2+3+4+9","1+2+3+5+8","1+2+3+6+7","1+2+4+5+7", "1+3+4+5+6" });
            part5.Add(20,new string[] {"1+2+3+5+9","1+2+3+6+8","1+2+4+5+8","1+2+4+6+7","1+3+4+5+7", "2+3+4+5+6" });
            part5.Add(21,new string[] {"1+2+3+6+9","1+2+3+7+8","1+2+4+5+9","1+2+4+6+8","1+2+5+6+7","1+3+4+5+8","1+3+4+6+7", "2+3+4+5+7" });
            part5.Add(22,new string[] {"1+2+3+7+9","1+2+4+6+9","1+2+4+7+8","1+2+5+6+8","1+3+4+5+9","1+3+4+6+8","1+3+5+6+7","2+3+4+5+8", "2+3+4+6+7" });
            part5.Add(23,new string[] {"1+2+3+8+9","1+2+4+7+9","1+2+5+6+9","1+2+5+7+8","1+3+4+6+9","1+3+4+7+8","1+3+5+6+8","1+4+5+6+7","2+3+4+5+9","2+3+4+6+8", "2+3+5+6+7" });
            part5.Add(24,new string[] {"1+2+4+8+9","1+2+5+7+9","1+2+6+7+8","1+3+4+7+9","1+3+5+6+9","1+3+5+7+8","1+4+5+6+8","2+3+4+6+9","2+3+4+7+8","2+3+5+6+8", "2+4+5+6+7" });
            part5.Add(25,new string[] {"1+2+5+8+9","1+2+6+7+9","1+3+4+8+9","1+3+5+7+9","1+3+6+7+8","1+4+5+6+9","1+4+5+7+8","2+3+4+7+9","2+3+5+6+9","2+3+5+7+8","2+4+5+6+8", "3+4+5+6+7" });
            part5.Add(26,new string[] {"1+2+6+8+9","1+3+5+8+9","1+3+6+7+9","1+4+5+7+9","1+4+6+7+8","2+3+4+8+9","2+3+5+7+9","2+3+6+7+8","2+4+5+6+9","2+4+5+7+8", "3+4+5+6+8" });
            part5.Add(27,new string[] {"1+2+7+8+9","1+3+6+8+9","1+4+5+8+9","1+4+6+7+9","1+5+6+7+8","2+3+5+8+9","2+3+6+7+9","2+4+5+7+9","2+4+6+7+8","3+4+5+6+9", "3+4+5+7+8" });
            part5.Add(28,new string[] {"1+3+7+8+9","1+4+6+8+9","1+5+6+7+9","2+3+6+8+9","2+4+5+8+9","2+4+6+7+9","2+5+6+7+8","3+4+5+7+9", "3+4+6+7+8" });
            part5.Add(29,new string[] {"1+4+7+8+9","1+5+6+8+9","2+3+7+8+9","2+4+6+8+9","2+5+6+7+9","3+4+5+8+9","3+4+6+7+9", "3+5+6+7+8" });
            part5.Add(30,new string[] {"1+5+7+8+9","2+4+7+8+9","2+5+6+8+9","3+4+6+8+9","3+5+6+7+9", "4+5+6+7+8" });
            part5.Add(31,new string[] {"1+6+7+8+9","2+5+7+8+9","3+4+7+8+9","3+5+6+8+9", "4+5+6+7+9" });
            part5.Add(32,new string[] {"2+6+7+8+9","3+5+7+8+9", "4+5+6+8+9" });
            part5.Add(33,new string[] {"3+6+7+8+9", "4+5+7+8+9" });
            part5.Add(34,new string[] { "4+6+7+8+9" });
            part5.Add(35,new string[] { "5+6+7+8+9" });

            Dictionary<int, string[]> part6 = new Dictionary<int, string[]>();
            part6.Add(21,new string[] { "1+2+3+4+5+6" });
            part6.Add(22,new string[] { "1+2+3+4+5+7" });
            part6.Add(23,new string[] {"1+2+3+4+5+8", "1+2+3+4+6+7" });
            part6.Add(24,new string[] {"1+2+3+4+5+9","1+2+3+4+6+8", "1+2+3+5+6+7" });
            part6.Add(25,new string[] {"1+2+3+4+6+9","1+2+3+4+7+8","1+2+3+5+6+8", "1+2+4+5+6+7" });
            part6.Add(26,new string[] {"1+2+3+4+7+9","1+2+3+5+6+9","1+2+3+5+7+8","1+2+4+5+6+8", "1+3+4+5+6+7" });
            part6.Add(27,new string[] {"1+2+3+4+8+9","1+2+3+5+7+9","1+2+3+6+7+8","1+2+4+5+6+9","1+2+4+5+7+8","1+3+4+5+6+8", "2+3+4+5+6+7" });
            part6.Add(28,new string[] {"1+2+3+5+8+9","1+2+3+6+7+9","1+2+4+5+7+9","1+2+4+6+7+8","1+3+4+5+6+9","1+3+4+5+7+8", "2+3+4+5+6+8" });
            part6.Add(29,new string[] {"1+2+3+6+8+9","1+2+4+5+8+9","1+2+4+6+7+9","1+2+5+6+7+8","1+3+4+5+7+9","1+3+4+6+7+8","2+3+4+5+6+9", "2+3+4+5+7+8" });
            part6.Add(30,new string[] {"1+2+3+7+8+9","1+2+4+6+8+9","1+2+5+6+7+9","1+3+4+5+8+9","1+3+4+6+7+9","1+3+5+6+7+8","2+3+4+5+7+9", "2+3+4+6+7+8" });
            part6.Add(31,new string[] {"1+2+4+7+8+9","1+2+5+6+8+9","1+3+4+6+8+9","1+3+5+6+7+9","1+4+5+6+7+8","2+3+4+5+8+9","2+3+4+6+7+9", "2+3+5+6+7+8" });
            part6.Add(32,new string[] {"1+2+5+7+8+9","1+3+4+7+8+9","1+3+5+6+8+9","1+4+5+6+7+9","2+3+4+6+8+9","2+3+5+6+7+9", "2+4+5+6+7+8" });
            part6.Add(33,new string[] {"1+2+6+7+8+9","1+3+5+7+8+9","1+4+5+6+8+9","2+3+4+7+8+9","2+3+5+6+8+9","2+4+5+6+7+9", "3+4+5+6+7+8" });
            part6.Add(34,new string[] {"1+3+6+7+8+9","1+4+5+7+8+9","2+3+5+7+8+9","2+4+5+6+8+9", "3+4+5+6+7+9" });
            part6.Add(35,new string[] {"1+4+6+7+8+9","2+3+6+7+8+9","2+4+5+7+8+9", "3+4+5+6+8+9" });
            part6.Add(36,new string[] {"1+5+6+7+8+9","2+4+6+7+8+9", "3+4+5+7+8+9" });
            part6.Add(37,new string[] {"2+5+6+7+8+9", "3+4+6+7+8+9" });
            part6.Add(38,new string[] { "3+5+6+7+8+9" });
            part6.Add(39,new string[] { "4+5+6+7+8+9" });

            Dictionary<int, string[]> part7 = new Dictionary<int, string[]>();
            part7.Add(28,new string[] { "1+2+3+4+5+6+7" });
            part7.Add(29,new string[] { "1+2+3+4+5+6+8" });
            part7.Add(30,new string[] {"1+2+3+4+5+6+9", "1+2+3+4+5+7+8" });
            part7.Add(31,new string[] {"1+2+3+4+5+7+9", "1+2+3+4+6+7+8" });
            part7.Add(32,new string[] {"1+2+3+4+5+8+9","1+2+3+4+6+7+9", "1+2+3+5+6+7+8" });
            part7.Add(33,new string[] {"1+2+3+4+6+8+9","1+2+3+5+6+7+9", "1+2+4+5+6+7+8" });
            part7.Add(34,new string[] {"1+2+3+4+7+8+9","1+2+3+5+6+8+9","1+2+4+5+6+7+9", "1+3+4+5+6+7+8" });
            part7.Add(35,new string[] {"1+2+3+5+7+8+9","1+2+4+5+6+8+9","1+3+4+5+6+7+9", "2+3+4+5+6+7+8" });
            part7.Add(36,new string[] {"1+2+3+6+7+8+9","1+2+4+5+7+8+9","1+3+4+5+6+8+9", "2+3+4+5+6+7+9" });
            part7.Add(37,new string[] {"1+2+4+6+7+8+9","1+3+4+5+7+8+9", "2+3+4+5+6+8+9" });
            part7.Add(38,new string[] {"1+2+5+6+7+8+9","1+3+4+6+7+8+9", "2+3+4+5+7+8+9" });
            part7.Add(39,new string[] {"1+3+5+6+7+8+9", "2+3+4+6+7+8+9" });
            part7.Add(40,new string[] {"1+4+5+6+7+8+9", "2+3+5+6+7+8+9" });
            part7.Add(41,new string[] { "2+4+5+6+7+8+9" });
            part7.Add(42,new string[] { "3+4+5+6+7+8+9" });

            Dictionary<int, string[]> part8 = new Dictionary<int, string[]>();
            part8.Add(36,new string[] { "1+2+3+4+5+6+7+8" });
            part8.Add(37,new string[] { "1+2+3+4+5+6+7+9" });
            part8.Add(38,new string[] { "1+2+3+4+5+6+8+9" });
            part8.Add(39,new string[] { "1+2+3+4+5+7+8+9" });
            part8.Add(40,new string[] { "1+2+3+4+6+7+8+9" });
            part8.Add(41,new string[] { "1+2+3+5+6+7+8+9" });
            part8.Add(42,new string[] { "1+2+4+5+6+7+8+9" });
            part8.Add(43,new string[] { "1+3+4+5+6+7+8+9" });
            part8.Add(44,new string[] { "2+3+4+5+6+7+8+9" });

            Dictionary<int, string[]> part9 = new Dictionary<int, string[]>();
            part9.Add(45, new string[] { "1+2+3+4+5+6+7+8+9" });

            all_partitions.Add(2, part2);
            all_partitions.Add(3, part3);
            all_partitions.Add(4, part4);
            all_partitions.Add(5, part5);
            all_partitions.Add(6, part6);
            all_partitions.Add(7, part7);
            all_partitions.Add(8, part8);
            all_partitions.Add(9, part9);

            /*
             * reading maps
             * System.Console.WriteLine(unique_partitions[2][16]);
             * System.Console.WriteLine(unique_partitions[3][6]);
             */
            System.Console.WriteLine("testing unique partitions (probably won't use)");
            System.Console.WriteLine(unique_partitions[3][6]);

            System.Console.WriteLine("testing all partitions");
            System.Console.WriteLine("checking if 2 digit 7 has solution: " + all_partitions[2][7].Length);
            System.Console.WriteLine("taking  2 digit 7 has solution index 0: " + all_partitions[2][7][0]);
            System.Console.WriteLine("taking  2 digit 7 has solution index 0: " + all_partitions[2][7][1]);
            System.Console.WriteLine("taking  2 digit 7 has solution index 0: " + all_partitions[2][7][2]);

            System.Console.WriteLine("Test 12;10: " + string.Join(",", findUniqueMarks(all_partitions[2][12], all_partitions[2][10])));
            System.Console.WriteLine("Test 12;8: " + string.Join(",", findUniqueMarks(all_partitions[2][12], all_partitions[2][8])));
            System.Console.WriteLine("Test 6;10: " + string.Join(",", findUniqueMarks(all_partitions[2][6], all_partitions[2][10])));
            System.Console.WriteLine("Test 6;8: " + string.Join(",", findUniqueMarks(all_partitions[2][6], all_partitions[2][8])));

        }

        /*solving strategy:
         * 1) Write mark ups from clues in all tiles
         * 2) Take tile with least marks and check every number for possible combinations horizotnaly and vertically (basic solve tactic)
         *    2.1) After if combination makes the remainder just 1, write that number; else update possible combination to the tiles next to that one
         * 3) ???
         */

        private int[] findUniqueMarks(string[] comboBot, string[] comboRight)
        {
            //{ "1+9","2+8","3+7","4+6" } - 10 of 2 parts
            //{ "3+9","4+8","5+7" } - 12 of 2 parts

            int[] ans = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ansBot = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ansRight = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < comboBot.Length; i++)
            {
                string combination = comboBot[i];
                string[] splited = combination.Split("+");
                for (int j = 0; j < splited.Length; j++)
                {
                    int nr = Int16.Parse(splited[j]);
                    ansBot[nr - 1] = 1;
                }
            }

            for (int i = 0; i < comboRight.Length; i++)
            {
                string combination = comboRight[i];
                string[] splited = combination.Split("+");
                //initial markup from partitions
                for (int j = 0; j < splited.Length; j++)
                {
                    int nr = Int16.Parse(splited[j]);
                    ansRight[nr - 1] = 1;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (ansBot[i] == 1 && ansRight[i] == 1)
                    ans[i] = 1;
            }
            return ans;
        }

        public void WriteMarkups()
        {
            //first write markups from clues

            for (int i = 0; i < board.getXSize(); i++)
            {
                for (int j = 0; j < board.getYSize(); j++)
                {
                    Tile tile = board.getTile(i, j);
                    if (tile.GetTileType() == Enums.TileType.Tile)
                    {
                        int[] clues = tile.getClues();
                        string[] comboBot = all_partitions[tile.getLengthY()][clues[0]];
                        string[] comboRight = all_partitions[tile.getLengthX()][clues[1]];
                        int[] marks = findUniqueMarks(comboBot, comboRight);
                        tile.AddMarks(marks);
                    }
                }
            }
        }

        //need to find lowest mark nr now...

    }
}
