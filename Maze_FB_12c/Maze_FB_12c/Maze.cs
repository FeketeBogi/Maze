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
            List<string> lines = new List<string>();

            StreamReader f = new StreamReader(filePath);
            while (!f.EndOfStream)
            {
                lines.Add(f.ReadLine());
            }
            f.Close();

            string[] wh = lines[0].Split();
            W = Convert.ToInt16(wh[0]);
            H = Convert.ToInt16(wh[1]);

            string[] xy = lines[1].Split();
            startX = Convert.ToInt16(xy[0]);
            startY = Convert.ToInt16(xy[1]);

            maze = new char[H, W];
            visited = new bool[H, W];

            for (int i = 0; i < H; i++)
            {
                string line = lines[2 + i];
                for (int j = 0; j < W; j++)
                {
                    maze[i, j] = line[j];
                }
            }

            BFS(startX, startY);

            exits = exits.OrderBy(e => e.Item1).ThenBy(e => e.Item2).ToList();

            List<string> strings = new List<string>();  
            foreach (var (x, y) in exits)
            {
                strings.Add($"{x} {y}");
            }

            return strings;
        }

        private void BFS(int x, int y)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((x, y));
            visited[y, x] = true;

            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            while (queue.Count > 0)
            {
                var (cx, cy) = queue.Dequeue();

                if ((cx == 0 || cx == W - 1 || cy == 0 || cy == H - 1) && (cx != startX || cy != startY))
                {
                    if (maze[cy, cx] == '.')
                    {
                        exits.Add((cx, cy));
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    int nx = cx + dx[i];
                    int ny = cy + dy[i];

                    if (nx >= 0 && nx < W && ny >= 0 && ny < H &&
                        !visited[ny, nx] && maze[ny, nx] == '.')
                    {
                        visited[ny, nx] = true;
                        queue.Enqueue((nx, ny));
                    }
                }
            }
        }
    }
}
