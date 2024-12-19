var possiblePatterns = (await File.ReadAllLinesAsync(Path.Join(Directory.GetCurrentDirectory(), "input1.txt")))[0].Split(", ").ToHashSet();
var wantedPatterns = await File.ReadAllLinesAsync(Path.Join(Directory.GetCurrentDirectory(), "input2.txt"));

var part1Answer = 0;
long part2Answer = 0;
foreach (var pattern in wantedPatterns)
{
    var combinations = CountPatternCombinations(pattern);
    part1Answer = combinations > 0 ? part1Answer + 1 : part1Answer;
    part2Answer += combinations;
}
Console.WriteLine($"First part: {part1Answer}");
Console.WriteLine($"Second part: {part2Answer}");
return;


long CountPatternCombinations(string pattern)
{
    var dp = new long[pattern.Length + 1];
    dp[0] = 1; 

    for (var i = 1; i <= pattern.Length; i++)
    {
        dp[i] = 0; 
        for (var j = 0; j < i; j++)
        {
            var substring = pattern.Substring(j, i - j);
            if (possiblePatterns.Contains(substring))
            {
                dp[i] += dp[j];
            }
        }
    }
    
    return dp[pattern.Length];
}