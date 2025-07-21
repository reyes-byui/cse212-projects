using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== FindPairs Method Demonstration ===\n");

        // Test case 1: Basic example from the problem description
        Console.WriteLine("Test 1: Basic example from problem description");
        string[] words1 = {"am", "at", "ma", "if", "fi"};
        var result1 = FindPairs(words1);
        Console.WriteLine($"Input: [{string.Join(", ", words1)}]");
        Console.WriteLine($"Output: [{string.Join(", ", result1)}]");
        Console.WriteLine("Expected: symmetric pairs like 'ma & am' and 'fi & if'\n");

        // Test case 2: With palindromes (should be ignored)
        Console.WriteLine("Test 2: With palindromes (should be ignored)");
        string[] words2 = {"ab", "aa", "ba"};
        var result2 = FindPairs(words2);
        Console.WriteLine($"Input: [{string.Join(", ", words2)}]");
        Console.WriteLine($"Output: [{string.Join(", ", result2)}]");
        Console.WriteLine("Expected: 'ba & ab' only ('aa' ignored as palindrome)\n");

        // Test case 3: Numbers
        Console.WriteLine("Test 3: With numbers");
        string[] words3 = {"23", "32", "84", "49", "94"};
        var result3 = FindPairs(words3);
        Console.WriteLine($"Input: [{string.Join(", ", words3)}]");
        Console.WriteLine($"Output: [{string.Join(", ", result3)}]");
        Console.WriteLine("Expected: '32 & 23' and '94 & 49'\n");

        // Test case 4: No pairs
        Console.WriteLine("Test 4: No pairs found");
        string[] words4 = {"ab", "cd", "ef"};
        var result4 = FindPairs(words4);
        Console.WriteLine($"Input: [{string.Join(", ", words4)}]");
        Console.WriteLine($"Output: [{string.Join(", ", result4)}]");
        Console.WriteLine("Expected: empty array (no reverses found)\n");
    }

    // Copy of FindPairs method from SetsAndMaps
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();
        var processed = new HashSet<string>();

        foreach (var word in words)
        {
            // Skip if already processed
            if (processed.Contains(word))
                continue;

            // Check if it's a palindrome (same letters), skip if so
            if (word[0] == word[1])
                continue;

            // Create the reverse of the word using char array approach (fastest)
            char[] reversedChars = { word[1], word[0] };
            string reversed = new string(reversedChars);

            // Check if the reverse exists in the set and hasn't been processed
            if (wordSet.Contains(reversed) && !processed.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
                processed.Add(word);
                processed.Add(reversed);
            }
        }

        return result.ToArray();
    }
}