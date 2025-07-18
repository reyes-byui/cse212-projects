/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
            
            // Add points to the player's total, or create new entry if player doesn't exist
            if (players.ContainsKey(playerId)) {
                players[playerId] += points;
            } else {
                players[playerId] = points;
            }
        }
        
        // Convert dictionary to list of key-value pairs for sorting
        var playersList = players.ToList();
        
        // Sort by points in descending order
        playersList.Sort((x, y) => y.Value.CompareTo(x.Value));
        
        // Display top 10 players
        Console.WriteLine("Top 10 Players by Total Career Points:");
        Console.WriteLine("=====================================");
        
        for (int i = 0; i < Math.Min(10, playersList.Count); i++) {
            var player = playersList[i];
            Console.WriteLine($"{i + 1,2}. {player.Key,-12} {player.Value,7:N0} points");
        }
    }
}