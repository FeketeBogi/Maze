using Microsoft.Testing.Platform.Extensions.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_FB_12c
{
    public class MazeSolver
    {
        private int W, H;
        private int startX, startY;
        private char[,] maze;
        private bool[,] visited;
        private List<(int, int)> exits = new List<(int, int)>();

        public List<string> Solve(string filePath)
        {
            List<string> lines = Beolvasas(filePath);

            MazeWidthHeight(lines[0]);
            StartCoordinates(lines[1]);
            HandleMaze(lines.Skip(2).ToList());

            Reachable(startX, startY);

            exits = exits.OrderBy(e => e.Item1).ThenBy(e => e.Item2).ToList();

            List<string> strings = new List<string>();  
            foreach (var (x, y) in exits)
            {
                strings.Add($"{x} {y}");
            }

            return strings;
        }
        //

        //HandleMaze
        public bool HandleMaze(List<string> lines)
        { 
            maze = new char[H, W];
            visited = new bool[H, W];

            for (int y = 0; y < H; y++)
            {
                string line = lines[y];
                for (int x = 0; x < W; x++)
                {
                    maze[y, x] = line[x];
                }
            }
            return true;
        }

        //StartCoords
        public bool StartCoordinates(string line)
        {
            string[] xy = line.Split();
            startX = Convert.ToInt16(xy[0]);
            startY = Convert.ToInt16(xy[1]);
            return true;
        }

        //Width-Height
        public bool MazeWidthHeight(string line)
        {
            string[] wh = line.Split();
            W = Convert.ToInt16(wh[0]);
            H = Convert.ToInt16(wh[1]);
            return true;
        }

        //Beolvasas
        public List<string> Beolvasas(string filePath)
        {
            List<string> lines = new List<string>();
            StreamReader f = new StreamReader(filePath);
            while (!f.EndOfStream)
            {
                lines.Add(f.ReadLine());
            }
            f.Close();
            return lines;
        }

        //
        // ---------------------------
        public bool Reachable(int x, int y)
        {
            List<(int, int)> queue = new List<(int, int)>();
            queue.Add((x, y));
            visited[y, x] = true;

            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            int index = 0;

            while (index < queue.Count)
            {
                (int cx, int cy) = queue[index++];
                Exits(cx, cy);

                for (int i = 0; i < 4; i++)
                {
                    int nx = cx + dx[i];
                    int ny = cy + dy[i];
                    AddIfValid(nx, ny, queue);
                }
            }
            return true;
        }
        //

        //Exits
        public bool Exits(int x, int y)
        {
            if (IsExit(x, y) && maze[y, x] == '.')
            {
                exits.Add((x, y));
            }
            return true;
        }

        //Valid
        public bool AddIfValid(int x, int y, List<(int, int)> queue)
        {
            if (InsideMaze(x, y) && !visited[y, x] && maze[y, x] == '.')
            {
                visited[y, x] = true;
                queue.Add((x, y));
            }
            return true;
        }

        //Exit
        public bool IsExit(int x, int y)
        {
            return (x == 0 || x == W - 1 || y == 0 || y == H - 1) && (x != startX || y != startY);
        }

        //Inside
        public bool InsideMaze(int x, int y)
        {
            return x >= 0 && x < W && y >= 0 && y < H;
        }

        //
        //END
    }
}
