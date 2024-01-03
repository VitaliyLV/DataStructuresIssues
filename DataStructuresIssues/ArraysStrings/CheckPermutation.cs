namespace DataStructuresIssues.Solutions
{
    internal class CheckPermutation : ISolveIssue
    {
        const string trueResponse = "TRUE. The string are permutations";
        const string falseResponse = "FALSE. The strings are not permutations";

        /// <summary>
        ///Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.
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

                Console.WriteLine("Method1: " + (IsPermutation1(str1, str2) ? trueResponse : falseResponse));
                Console.WriteLine("Method2: " + (IsPermutation2(str1, str2) ? trueResponse : falseResponse));
            }
        }
        //Compare number of each chars
        //O(n)
        private bool IsPermutation1(string? str1, string? str2)
        {
            if (str1 == null || str2 == null || str1.Length != str2.Length)
                return false;
            int[] chars1 = new int[128];
            int[] chars2 = new int[128];
            for (int i = 0; i < str1.Length; i++)
            {
                chars1[str1[i]]++;
                chars2[str2[i]]++;
            }
            for (int i = 0; i < 128; i++)
            {
                if (chars1[i] != chars2[i])
                    return false;
            }

            return true;
        }
        //sort and compare
        private bool IsPermutation2(string? str1, string? str2)
        {
            if (str1 == null || str2 == null || str1.Length != str2.Length)
                return false;
            var sortS1 = Sort(str1);
            var sortS2 = Sort(str2);
            if (sortS1! != null && sortS2 != null)
                return sortS1.Equals(sortS2);
            return false;
        }
        private string? Sort(string str)
        {
            char[] cArray = str.ToCharArray();
            Array.Sort(cArray);
            return new string(cArray);
        }
    }
}
