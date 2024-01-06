using DataStructuresIssues;
using System.Reflection;

var solutions = new Dictionary<int, ISolveIssue>();

string nspace = "DataStructuresIssues.Solutions";
int i = 0;
var types = from t in Assembly.GetExecutingAssembly().GetTypes()
        where t.IsClass && t.Namespace == nspace
        select t;
foreach (var item in types)
{
    var tp = item.GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>());
    ISolveIssue? solveIssue = tp as ISolveIssue;
    if (solveIssue != null)
        solutions.Add(i++, solveIssue);
}

while (true)
{
    Console.WriteLine($"\nPlease select solution Number or {Helper.QuitStr} to exit:");
    foreach (var item in solutions)
    {
        var typeName = item.Value.ToString();
        Console.WriteLine($"{item.Key}: {typeName?.Substring(typeName.LastIndexOf('.') + 1)}");
    }

    var solutionNum = Console.ReadLine();
    if (solutionNum == Helper.QuitStr)
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
