using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Maze_FB_12c
{
    internal class Program
    {
        //VÁLTOZÓK
        static List<List<char>> maze;
        static int X;
        static int Y;
        static void Main(string[] args)
        {
            Console.Write("Fájl: ");
            string title = Console.ReadLine();
            maze = Fajlbeolvasas($"{title}.txt");
            //Listakiiratas(maze);

            List<List<int>> exits = Move();

            //END
            Console.ReadKey();
        }
        //METÓDUSOK

        static List<List<int>> Move()
        {
            List<List<int>> exits = new List<List<int>>();
            int startX = X;
            int startY = Y;

            if (maze[X - 1][Y] == '.')
            {

            } else if (maze[X][Y-1] == '.')
            {
                
            } else if (maze[X][Y+1] == '.')
            {

            } else if (maze[X + 1][Y] == '.')
            {

            }

            return exits;
        }

        //Beolvasas
        static List<List<char>> Fajlbeolvasas(string path)
        {
            List<List<char>> maze = new List<List<char>>();
            StreamReader f = new StreamReader(path);
            f.ReadLine();
            string[] cords = f.ReadLine().Split(' ');
            X = Convert.ToInt32(cords[0]);
            Y = Convert.ToInt32(cords[1]);
            while (!f.EndOfStream)
            {
                List<char> row = new List<char>();
                string rowstring = f.ReadLine();
                for (int i = 0; i < rowstring.Length; i++)
                {
                    row.Add(rowstring[i]);
                }
                maze.Add(row);
            }
            return maze;
        }

        //Kiiratas
        static void Listakiiratas(List<List<char>> maze)
        {
            for(int i = 0; i<maze.Count; i++)
            {
                for (int j = 0; j < maze[i].Count; j++)
                {
                    Console.Write(maze[i][j]+" ");
                }
                Console.WriteLine();
            }
        }

        //
        //END

    }
    //CLASS
    //
    //END
}
