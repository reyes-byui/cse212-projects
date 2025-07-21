using System;

public class TestFindPairs
{
    public static void RunTest()
    {
        Console.WriteLine("=== FindPairs Method Test ===\n");

        // Test case 1: Basic example from the problem description
        Console.WriteLine("Test 1: Basic example");
        string[] words1 = {"am", "at", "ma", "if", "fi"};
        var result1 = SetsAndMaps.FindPairs(words1);
        Console.WriteLine($"Input: [{string.Join(", ", words1)}]");
        Console.WriteLine($"Result: [{string.Join(", ", result1)}]");
        Console.WriteLine($"Expected: [ma & am, fi & if] (order may vary)\n");

        // Test case 2: With palindromes (should be ignored)
        Console.WriteLine("Test 2: With palindromes");
        string[] words2 = {"ab", "aa", "ba"};
        var result2 = SetsAndMaps.FindPairs(words2);
        Console.WriteLine($"Input: [{string.Join(", ", words2)}]");
        Console.WriteLine($"Result: [{string.Join(", ", result2)}]");
        Console.WriteLine($"Expected: [ba & ab] (aa is ignored as palindrome)\n");

        // Test case 3: Numbers
        Console.WriteLine("Test 3: With numbers");
        string[] words3 = {"23", "84", "49", "13", "32", "46", "91", "99", "94", "31"};
        var result3 = SetsAndMaps.FindPairs(words3);
        Console.WriteLine($"Input: [{string.Join(", ", words3)}]");
        Console.WriteLine($"Result: [{string.Join(", ", result3)}]");
        Console.WriteLine($"Expected: [32 & 23, 94 & 49, 31 & 13] (order may vary)\n");

        // Test case 4: No pairs
        Console.WriteLine("Test 4: No pairs found");
        string[] words4 = {"ab", "cd", "ef"};
        var result4 = SetsAndMaps.FindPairs(words4);
        Console.WriteLine($"Input: [{string.Join(", ", words4)}]");
        Console.WriteLine($"Result: [{string.Join(", ", result4)}]");
        Console.WriteLine($"Expected: [] (empty array)\n");
    }
}
