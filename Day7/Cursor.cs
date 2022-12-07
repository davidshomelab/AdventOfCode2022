using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    /// <summary>
    /// Handles moving around a directory tree
    /// </summary>
    internal class Cursor
    {
        /// <summary>
        /// Where we are now
        /// </summary>
        internal Directory CurrentNode { get; private set; }

        /// <summary>
        /// Internal method to move to the current node's parent
        /// </summary>
        void GoToParent()
        {
            CurrentNode = CurrentNode.Parent;
        }

        /// <summary>
        /// Internal method to move to child node
        /// </summary>
        /// <param name="child">Name of the child node to move to</param>
        void GoToChild(string child)
        {
            CurrentNode = CurrentNode.Children.Single(x => x.Name == child);
        }

        /// <summary>
        /// External method to handle any directory moves
        /// Can move to any child node and also special locations
        /// <c>..</c> and <c>/</c> for the parent and root node
        /// </summary>
        /// <param name="location">Node to move to</param>
        internal void GoTo(string location)
        {
            if (location == "..")
            {
                GoToParent();
            }
            else if (location == "/") {
                while (CurrentNode.Name != "/")
                {
                    GoToParent();
                }
            }
            else
            {
                GoToChild(location);
            }
        }

        /// <summary>
        /// Create new cursor in a blank directory tree
        /// </summary>
        internal Cursor()
        {
            CurrentNode = new Directory("/");
        }
    }
}
