using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add multiple items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in priority order (highest first)
    // Defect(s) Found: Loop doesn't check last item, item not removed from queue after dequeue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 3);
        priorityQueue.Enqueue("Medium", 2);
        
        // Should dequeue highest priority first
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with same priority and verify FIFO for same priority
    // Expected Result: Items with same priority should be dequeued in FIFO order
    // Defect(s) Found: Using >= instead of > for priority comparison, breaks FIFO for equal priorities
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);
        
        // Should dequeue in FIFO order when priorities are equal
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of different and same priorities
    // Expected Result: Higher priority first, then FIFO for same priority
    // Defect(s) Found: Using >= instead of > for priority comparison, breaks FIFO for equal priorities
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 2);
        
        // Should dequeue: B (3, first), D (3, second), C (2, first), E (2, second), A (1)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: Exception should be thrown
    // Defect(s) Found: None - exception handling works correctly
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: Single item should be dequeued successfully
    // Defect(s) Found: None - works correctly for single item
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 5);
        
        Assert.AreEqual("Only", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items, dequeue some, add more, verify order
    // Expected Result: Queue should maintain correct priority order throughout
    // Defect(s) Found: Item not removed from queue after dequeue
    public void TestPriorityQueue_MixedOperations()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 1);
        
        Assert.AreEqual("First", priorityQueue.Dequeue()); // Priority 2
        
        priorityQueue.Enqueue("Third", 3);
        priorityQueue.Enqueue("Fourth", 1);
        
        Assert.AreEqual("Third", priorityQueue.Dequeue()); // Priority 3
        Assert.AreEqual("Second", priorityQueue.Dequeue()); // Priority 1, earlier
        Assert.AreEqual("Fourth", priorityQueue.Dequeue()); // Priority 1, later
    }
}