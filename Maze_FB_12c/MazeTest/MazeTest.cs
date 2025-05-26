using Maze_FB_12c;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace MazeTest
{
    [TestFixture]
    internal class MazeTest
    {
        [TestCase("single.txt", "7 7", "1 1", "#######", 9)]
        [TestCase("multiple.txt", "11 11", "5 5", "###########", 13)]
        [TestCase("noway.txt", "11 11", "5 5", "###########", 13)]
        [TestCase("loops.txt", "11 11", "5 5", "###########", 13)]
        [TestCase("all.txt", "21 21", "9 10", "##########.##########", 23)]
        public void TestReader(string path, string wh, string coords, string row, int length)
        {
            MazeSolver solver = new MazeSolver();
            List<string> lista = solver.Beolvasas(path);
            ClassicAssert.AreEqual(lista[0], wh);
            ClassicAssert.AreEqual(lista[1], coords);
            ClassicAssert.AreEqual(lista[2], row);
            ClassicAssert.AreEqual(lista.Count, length);
        }

        [TestCase("single.txt", 1)]
        [TestCase("multiple.txt", 2)]
        [TestCase("noway.txt", 0)]
        [TestCase("loops.txt", 1)]
        [TestCase("all.txt", 4)]

        public void TestSolver(string path, int expected)
        {
            MazeSolver solver = new MazeSolver();
            List<string> lista = solver.Solve(path);
            ClassicAssert.AreEqual(expected, lista.Count);
        }

        [TestCase("single.txt", true)]
        [TestCase("multiple.txt", true)]
        [TestCase("noway.txt", true)]
        [TestCase("loops.txt", true)]
        [TestCase("all.txt", true)]

        public void TestWH(string path, bool logic)
        {
            MazeSolver solver = new MazeSolver();
            bool logikai = solver.MazeWidthHeight(solver.Beolvasas(path)[0]);
            ClassicAssert.AreEqual(logic, logikai);
        }

        [TestCase("single.txt", true)]
        [TestCase("multiple.txt", true)]
        [TestCase("noway.txt", true)]
        [TestCase("loops.txt", true)]
        [TestCase("all.txt", true)]
        public void TestCoords(string path, bool logic)
        {
            MazeSolver solver = new MazeSolver();
            bool logikai = solver.StartCoordinates(solver.Beolvasas(path)[1]);
            ClassicAssert.AreEqual(logic, logikai);
        }

        [TestCase("single.txt", true)]
        [TestCase("multiple.txt", true)]
        [TestCase("noway.txt", true)]
        [TestCase("loops.txt", true)]
        [TestCase("all.txt", true)]
        public void TestHandleMaze(string path, bool logic)
        {
            MazeSolver solver = new MazeSolver();
            bool logikai = solver.HandleMaze(solver.Beolvasas(path).Skip(2).ToList());
            ClassicAssert.AreEqual(logic, logikai);
        }

    }
}
