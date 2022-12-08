using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Forest
    {
        int[][] _trees;

        public int Width
        {
            get
            {
                return _trees[0].Length;
            }
        }
        public int Height
        {
            get
            {
                return _trees.Length;
            }
        }

        internal Forest(IEnumerable<int[]> trees)
        {
            _trees = trees.ToArray();
        }

        internal int[] GetLeft(int x, int y)
        {
            // we reverse this so the elemets are given in order of proximity to tree we are checking
            var output = _trees[y].Take(x).Reverse().ToArray();

            return output;
        }

        internal int[] GetRight(int x, int y)
        {
            var output = _trees[y].Skip(x + 1).ToArray();

            return output;
        }

        internal int[] GetAbove(int x, int y)
        {
            // we reverse this so the elemets are given in order of proximity to tree we are checking
            var output = _trees.Select(r => r[x]).Take(y).Reverse().ToArray();

            return output;
        }

        internal int[] GetBelow(int x, int y)
        {
            var output = _trees.Select(r => r[x]).Skip(y + 1).ToArray();

            return output;
        }

        internal int GetTreeHeight(int x, int y)
        {
            return _trees[y][x];
        }

        internal bool IsVisibleFromEdge(int x, int y)
        {
            int TreeHeight = GetTreeHeight(x, y);

            // if there are no adjacent trees we set a single value of -1
            // to ensure that a tree of height 0 at the edge is still counted
            return GetLeft(x, y).DefaultIfEmpty(-1).Max() < TreeHeight
            || GetRight(x, y).DefaultIfEmpty(-1).Max() < TreeHeight
            || GetAbove(x, y).DefaultIfEmpty(-1).Max() < TreeHeight
            || GetBelow(x, y).DefaultIfEmpty(-1).Max() < TreeHeight;
        }

        internal int ScenicScore(int x, int y)
        {
            int[] leftTrees = GetLeft(x, y);
            int[] rightTrees = GetRight(x, y);
            int[] aboveTrees = GetAbove(x, y);
            int[] belowTrees = GetBelow(x, y);

            int GetVisibleTrees(int[] trees)
            {
                // Read along linear array and return number of elements before one the same size or bigger than our current element
                int output = 0;
                foreach (int tree in trees)
                {
                    output++;
                    if (tree >= GetTreeHeight(x,y))
                    {
                        break;
                    }
                }

                return output;
            }

            return (GetVisibleTrees(leftTrees) * GetVisibleTrees(rightTrees) * GetVisibleTrees(aboveTrees) * GetVisibleTrees(belowTrees));
        }

    }
}
