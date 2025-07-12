using System;

public class TakingTurnsQueueDemo
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose a demo to run:");
        Console.WriteLine("1. TakingTurnsQueue Demo");
        Console.WriteLine("2. PriorityQueue Demo");
        Console.Write("Enter your choice (1 or 2): ");
        
        var choice = Console.ReadLine();
        
        if (choice == "1")
        {
            RunTakingTurnsDemo();
        }
        else if (choice == "2")
        {
            RunPriorityQueueDemo();
        }
        else
        {
            Console.WriteLine("Invalid choice. Running both demos...\n");
            RunTakingTurnsDemo();
            Console.WriteLine("\n" + new string('=', 50) + "\n");
            RunPriorityQueueDemo();
        }
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    public static void RunTakingTurnsDemo()
    {
        Console.WriteLine("=== TakingTurnsQueue Demo ===\n");
        
        // Create a queue and add some people
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 2);    // Bob gets 2 turns
        queue.AddPerson("Tim", 0);    // Tim gets infinite turns (0 = infinite)
        queue.AddPerson("Sue", 3);    // Sue gets 3 turns
        
        Console.WriteLine("Added: Bob (2 turns), Tim (infinite turns), Sue (3 turns)");
        Console.WriteLine($"Queue length: {queue.Length}\n");
        
        // Take 10 turns to see the pattern
        Console.WriteLine("Taking 10 turns:");
        for (int i = 1; i <= 10; i++)
        {
            var person = queue.GetNextPerson();
            Console.WriteLine($"Turn {i}: {person.Name} (turns left: {(person.Turns <= 0 ? "infinite" : person.Turns.ToString())})");
            Console.WriteLine($"Queue length: {queue.Length}");
            
            if (queue.Length == 0)
            {
                Console.WriteLine("Queue is now empty!");
                break;
            }
        }
        
        Console.WriteLine("\nDemo complete!");
    }
    
    public static void RunPriorityQueueDemo()
    {
        Console.WriteLine("=== PriorityQueue Demo ===\n");
        
        // Create a priority queue and add some items
        var pQueue = new PriorityQueue();
        pQueue.Enqueue("Low Priority Task", 1);
        pQueue.Enqueue("High Priority Task", 5);
        pQueue.Enqueue("Medium Priority Task", 3);
        pQueue.Enqueue("Another High Priority", 5);
        pQueue.Enqueue("Another Medium Priority", 3);
        
        Console.WriteLine("Added tasks with priorities:");
        Console.WriteLine("- Low Priority Task (1)");
        Console.WriteLine("- High Priority Task (5)");
        Console.WriteLine("- Medium Priority Task (3)");
        Console.WriteLine("- Another High Priority (5)");
        Console.WriteLine("- Another Medium Priority (3)");
        Console.WriteLine("\nDequeuing in priority order (FIFO for same priority):");
        
        int count = 1;
        while (true)
        {
            try 
            {
                var task = pQueue.Dequeue();
                Console.WriteLine($"{count}. {task}");
                count++;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Queue is now empty!");
                break;
            }
        }
        
        Console.WriteLine("\nDemo complete!");
    }
}