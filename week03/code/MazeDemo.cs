using System;
using System.Collections.Generic;

public class MazeDemo
{
    public static void RunDemo()
    {
        Console.WriteLine("=== Maze Navigation Demo ===\n");
        
        // Create the same maze from the test
        var mazeMap = SetupMazeMap();
        var maze = new Maze(mazeMap);
        
        Console.WriteLine("Starting position:");
        Console.WriteLine(maze.GetStatus());
        Console.WriteLine();
        
        try
        {
            Console.WriteLine("Attempting to move up from start...");
            maze.MoveUp();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"❌ {e.Message}");
        }
        
        try
        {
            Console.WriteLine("Attempting to move left from start...");
            maze.MoveLeft();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"❌ {e.Message}");
        }
        
        Console.WriteLine("\n✅ Moving right...");
        maze.MoveRight();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving down...");
        maze.MoveDown();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving down...");
        maze.MoveDown();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving down...");
        maze.MoveDown();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving right...");
        maze.MoveRight();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving right...");
        maze.MoveRight();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving up...");
        maze.MoveUp();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving right...");
        maze.MoveRight();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving down...");
        maze.MoveDown();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving left...");
        maze.MoveLeft();
        Console.WriteLine(maze.GetStatus());
        
        try
        {
            Console.WriteLine("Attempting to move down (should hit wall)...");
            maze.MoveDown();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"❌ {e.Message}");
        }
        
        Console.WriteLine("✅ Moving right...");
        maze.MoveRight();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving down...");
        maze.MoveDown();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving down...");
        maze.MoveDown();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("✅ Moving right...");
        maze.MoveRight();
        Console.WriteLine(maze.GetStatus());
        
        Console.WriteLine("\n🎉 Successfully navigated through the maze!");
    }
    
    private static Dictionary<ValueTuple<int, int>, bool[]> SetupMazeMap()
    {
        Dictionary<ValueTuple<int, int>, bool[]> map = new() {
            { (1, 1), new[] { false, true, false, true } },
            { (1, 2), new[] { false, true, true, false } },
            { (1, 3), new[] { false, false, false, false } },
            { (1, 4), new[] { false, true, false, true } },
            { (1, 5), new[] { false, false, true, true } },
            { (1, 6), new[] { false, false, true, false } },
            { (2, 1), new[] { true, false, false, true } },
            { (2, 2), new[] { true, false, true, true } },
            { (2, 3), new[] { false, false, true, true } },
            { (2, 4), new[] { true, true, true, false } },
            { (2, 5), new[] { false, false, false, false } },
            { (2, 6), new[] { false, false, false, false } },
            { (3, 1), new[] { false, false, false, false } },
            { (3, 2), new[] { false, false, false, false } },
            { (3, 3), new[] { false, false, false, false } },
            { (3, 4), new[] { true, true, false, true } },
            { (3, 5), new[] { false, false, true, true } },
            { (3, 6), new[] { false, false, true, false } },
            { (4, 1), new[] { false, true, false, false } },
            { (4, 2), new[] { false, false, false, false } },
            { (4, 3), new[] { false, true, false, true } },
            { (4, 4), new[] { true, true, true, false } },
            { (4, 5), new[] { false, false, false, false } },
            { (4, 6), new[] { false, false, false, false } },
            { (5, 1), new[] { true, true, false, true } },
            { (5, 2), new[] { false, false, true, true } },
            { (5, 3), new[] { true, true, true, true } },
            { (5, 4), new[] { true, false, true, true } },
            { (5, 5), new[] { false, false, true, true } },
            { (5, 6), new[] { false, true, true, false } },
            { (6, 1), new[] { true, false, false, false } },
            { (6, 2), new[] { false, false, false, false } },
            { (6, 3), new[] { true, false, false, false } },
            { (6, 4), new[] { false, false, false, false } },
            { (6, 5), new[] { false, false, false, false } },
            { (6, 6), new[] { true, false, false, false } }
        };
        return map;
    }
}
