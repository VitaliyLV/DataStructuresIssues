using System.Text;

namespace DataStructuresIssues.Solutions
{
    internal class OneAway : ISolveIssue
    {
        const string trueResponse = "TRUE. The string are one edit away";
        const string falseResponse = "FALSE. The strings are not one edit away";

        /// <summary>
        /// One Away: There are three types of edits that can be performed on strings: insert a character,
        /// remove a character, or replace a character.Given two strings, write a function to check if they are
        /// one edit (or zero edits) away
        /// </summary>

        public void Solve()
        {
            while (true)
            {
                Console.WriteLine("Enter 2 strings to check if one is permutation on the other:");
                var str1 = Console.ReadLine();
                if (str1 == Helper.QuitStr)
                    return;

                var str2 = Console.ReadLine();
                
                Console.WriteLine("Method1: " + (CheckOneEdit(str1, str2) ? trueResponse : falseResponse));
            }
        }

        public bool CheckOneEdit(string? s1, string? s2)
        {
            if (s1 == s2)
            {
                return true;
            }
            if (s1 is null)
                s1 = string.Empty;
            if (s2 is null)
                s2 = string.Empty;
            if (Math.Abs(s1.Length - s2.Length) > 1)
                return false;

            bool operationMade = false;
            int minLength = s1.Length > s2.Length ? s2.Length : s1.Length;
            for (int i = 0; i < minLength; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (operationMade)
                        return false;
                    operationMade = true;
                    if (s1.Length == s2.Length)
                        continue;
                    if (s1.Length > s2.Length)
                    {
                        s2 = StringFromOther(s1, s2, i);
                    }
                    else
                        s1 = StringFromOther(s2, s1, i);
                }
            }
            return true;
        }

        private string StringFromOther(string from, string to, int index)
        {
            StringBuilder sb = new StringBuilder(to.Substring(0, index));
            sb.Append(from[index]);
            sb.Append(to.Substring(index));
            return sb.ToString();
        }
    }
}
