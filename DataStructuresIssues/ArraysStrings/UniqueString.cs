using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIssues.ArraysStrings
{
    internal class UniqueString : ISolveIssue
    {
        public void Solve()
        {
            Console.WriteLine("Enter a string");
            var str = Console.ReadLine();
            Console.WriteLine(IsUnique(str) ? "The string has all unique values" : "The string has non unique values");
        }
        private bool IsUnique(string? str)
        {
            return true;
        }
    }
}
