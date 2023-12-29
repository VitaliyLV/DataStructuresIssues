using DataStructuresIssues;
using DataStructuresIssues.ArraysStrings;

var solutions = new Dictionary<int, ISolveIssue>
{
    { 1, new UniqueString() }
};

while (true)
{
    Console.WriteLine("\nPlease select solution Number or q to exit:");
    foreach (var item in solutions)
    {
        var typeName = item.Value.ToString();
        Console.WriteLine($"{item.Key}: {typeName?.Substring(typeName.LastIndexOf('.') + 1)}");
    }

    var solutionNum = Console.ReadLine();
    if (solutionNum == "q")
    {
        break;
    }
    else if (int.TryParse(solutionNum, out int num))
    {
        if (solutions.ContainsKey(num))
            solutions[num].Solve();
        else
            Console.WriteLine("Incorrect number");
    }
    else
    {
        Console.WriteLine("Enter number");
    }
}
