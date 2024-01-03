
namespace DataStructuresIssues.Solutions
{
    internal class UniqueString : ISolveIssue
    {
        const string isUnique = "TRUE. The string has all unique values";
        const string notUnique = "FALSE. The string has non unique values";

        /// <summary>
        ///Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you 
        ///cannot use additional data structures?
        ///</summary>
        public void Solve()
        {
            while (true)
            {
                Console.WriteLine("Enter a string to check is it's characters are unique:");
                var str = Console.ReadLine();
                if (str == Helper.QuitStr)
                {
                    return;
                }

                Console.WriteLine("Method1: " + (IsUnique(str) ? isUnique : notUnique));
                Console.WriteLine("Method2: " + (IsUnique2(str) ? isUnique : notUnique));
            }
        }
        //O(n^2)
        private bool IsUnique(string? str)
        {
            if (str == null || str.Length == 1)
                return true;

            for (int i = 0; i < str.Length - 1; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[j] == str[i])
                        return false;
                }
            }

            return true;
        }
        //for ASCII only, O(n)
        private bool IsUnique2(string? str)
        {
            if (str == null || str.Length > 128)
                return true;

            bool[] foundChars = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                char nextCH = str[i];
                if (nextCH > 128)
                    return false;
                if (foundChars[nextCH])
                    return false;
                foundChars[nextCH] = true;
            }

            return true;
        }
    }
}
