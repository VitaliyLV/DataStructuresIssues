namespace DataStructuresIssues.Solutions
{
    internal class ContainsPermutation : ISolveIssue
    {
        const string trueResponse = "TRUE. The string are permutations";
        const string falseResponse = "FALSE. The strings are not permutations";

        /// <summary>
        ///LeetCode 567. Permutation in String
        ///Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
        ///In other words, return true if one of s1's permutations is the substring of s2.
        ///</summary>
        public void Solve()
        {
            while (true)
            {
                Console.WriteLine("Enter 2 strings to check if one is permutation on the other:");
                var str1 = Console.ReadLine();
                if (str1 == Helper.QuitStr)
                    return;

                var str2 = Console.ReadLine();
                if (str1 == null || str2 == null)
                {
                    Console.WriteLine(falseResponse);
                    return;
                }
                Console.WriteLine("Method1: " + (CheckInclusion(str1, str2) ? trueResponse : falseResponse));
            }
        }
        //Resolve by sorting
        public bool CheckInclusion(string s1, string s2)
        {
            if (s2.Length < s1.Length)
                return false;
            if (s2.Contains(s1))
                return true;
            string sortedS1 = Sort(s1);
            for (int i = 0; i <= s2.Length - s1.Length; i++)
            {
                var sortedS2 = Sort(s2.Substring(i, s1.Length));
                if (sortedS1.Equals(sortedS2))
                    return true;
            }

            return false;
        }
        private string Sort(string str)
        {
            char[] cArray = str.ToCharArray();
            Array.Sort(cArray);
            return new string(cArray);
        }

    }
}
