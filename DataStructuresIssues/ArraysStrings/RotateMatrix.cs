namespace DataStructuresIssues.Solutions
{
    internal class RotateMatrix : ISolveIssue
    {
        /// <summary>
        /// Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
        /// bytes, write a method to rotate the image by 90 degrees.Can you do this in place?
        /// LeetCode 48 Rotate image
        /// </summary>
        public void Solve()
        {
            while (true)
            {
                Console.WriteLine("Enter the size of the matrix:");
                var str1 = Console.ReadLine();
                if (str1 == Helper.QuitStr)
                    return;
                if (!int.TryParse(str1, out int mSize))
                {
                    Console.WriteLine("Incorrect number");
                    return;
                }
                int[,] matrix = new int[mSize, mSize];
                Console.WriteLine("Enter matrix:");
                for (int i = 0; i < mSize; i++)
                {
                    var str2 = Console.ReadLine();
                    int j = 0;
                    if (str2 != null)
                    {
                        foreach (var item in str2.Split(' '))
                        {
                            matrix[i, j++] = int.Parse(item);
                        }
                    }
                }

                RotateClockWise(ref matrix, mSize);
                Console.WriteLine("The 90 degrees rotated matrix:");
                for (int i = 0; i < mSize; i++)
                {
                    for (int j = 0; j < mSize; j++)
                        Console.Write($"{matrix[i, j]} ");
                    Console.WriteLine();
                }
            }
        }

        private void RotateClockWise(ref int[,] matrix, int size)
        {
            int n = size - 1;
            for (int i = 0; i < size / 2; i++)
            {
                for (int j = i; j < n - i; j++)
                {
                    int temp = matrix[j, n - i];
                    matrix[j, n - i] = matrix[i, j];

                    int temp2 = matrix[n - i, n - j];
                    matrix[n - i, n - j] = temp;

                    temp = matrix[n - j, i];
                    matrix[n - j, i] = temp2;

                    matrix[i, j] = temp;
                }
            }
        }
    }
}
