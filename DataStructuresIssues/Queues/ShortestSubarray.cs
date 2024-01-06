namespace DataStructuresIssues.Solutions
{
    internal class ShortestSubarray : ISolveIssue
    {
        /// <summary>
        /// Given an integer array nums and an integer k, return the length of the shortest non-empty subarray of nums
        /// with a sum of at least k. If there is no such subarray, return -1.
        /// LeetCode 862
        /// </summary>
        public void Solve()
        {
            //int[] nums = new int[] { 1,2,5,4,-2,1,-4 };
            var nums = Helper.ReadNumbers();
            if(nums == null) 
                return;
            Console.WriteLine("Enter minimal searched sum:");
            var numStr = Console.ReadLine();
            if (int.TryParse(numStr, out var num))
            {
                Console.WriteLine("Slower method: " + ShortestSubSlower(nums.ToArray(), num));
                Console.WriteLine("Faster mathod: " + ShortestSubFaster(nums.ToArray(), num));
            }
        }
        //resolve by adding numbers in 3 loops
        public int ShortestSubSlower(int[] nums, int k)
        {
            if (nums.Length == 0)
                return -1;
            if(nums.Any(x => x >= k))
                return 1;
            
            for (int i = 2; i <= nums.Length; i++) // i - number of items in subarray
            {
                for (int j = 0; j <= nums.Length - i; j++) // j - subarray start position
                {
                    int sum = 0;
                    for (int x = 0; x < i; x++) // x - item to add position
                    {
                        sum += nums[x + j];
                    }
                    if (sum >= k)
                        return i;
                }
            }
            return -1;
        }
        //resolve by saving added values on each step and removing negative numbers from both ends
        public int ShortestSubFaster(int[] nums, int k)
        {
            if (nums.Length == 0)
                return -1;
            if (nums.Any(x => x >= k))
                return 1;

            List<int> numbers = new List<int>(nums);
            List<int> sumArray = new List<int>(nums);
            
            RemoveNegatives(ref sumArray, ref numbers);
            int minNum = 2;
            while (minNum <= numbers.Count)
            {
                sumArray.RemoveAt(sumArray.Count - 1);
                for (int j =  0; j < sumArray.Count; j++)
                {
                    int sum = sumArray[j] + numbers[j + minNum - 1];
                    if (sum >= k)
                        return minNum;
                    sumArray[j] = sum;
                }
                
                minNum++;
                RemoveNegatives(ref sumArray, ref numbers);
            }
            return -1;
        }

        void RemoveNegatives(ref List<int> sumArr, ref List<int> numbers)
        {
            while (sumArr.Last() < 0)
            {
                sumArr.RemoveAt(sumArr.Count - 1);
            }
            while(sumArr.First() < 0)
            {
                sumArr.RemoveAt(0);
                numbers.RemoveAt(0);
            }
        }

        
    }
}
