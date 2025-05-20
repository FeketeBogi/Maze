using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maze_FB_12c
{
    [TestFixture]
    internal class Test
    {
        [TestCase("single.txt", 1)]
        [TestCase("multiple.txt", 2)]
        [TestCase("noway.txt", 0)]
        [TestCase("loops.txt", 1)]
        [TestCase("all.txt", 4)]
        
        public void MazeTest(string path, int expected)
        {
            MazeSolver huh = new MazeSolver();
            List<string> lista = huh.Solve(path);
            ClassicAssert.AreEqual(expected, lista.Count);
        }

    }
}
