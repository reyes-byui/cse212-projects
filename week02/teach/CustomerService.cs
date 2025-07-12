/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Create a CustomerService with valid max size (5)
        // Expected Result: Should create successfully and show size 0, max 5
        Console.WriteLine("Test 1");
        var cs = new CustomerService(5);
        Console.WriteLine(cs);
        Console.WriteLine("Expected: [size=0 max_size=5 => ]");

        Console.WriteLine("=================");

        // Test 2  
        // Scenario: Create CustomerService with invalid max size (-1)
        // Expected Result: Should default to max size 10
        Console.WriteLine("Test 2");
        cs = new CustomerService(-1);
        Console.WriteLine(cs);
        Console.WriteLine("Expected: [size=0 max_size=10 => ]");

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Add one customer to empty queue
        // Expected Result: Should add successfully, queue size should be 1
        Console.WriteLine("Test 3");
        cs = new CustomerService(3);
        Console.WriteLine("Before adding customer:");
        Console.WriteLine(cs);
        // Simulate adding a customer (we'll need to modify this since AddNewCustomer requires user input)
        cs.TestAddCustomer("John Doe", "12345", "Login issues");
        Console.WriteLine("After adding customer:");
        Console.WriteLine(cs);
        Console.WriteLine("Expected: [size=1 max_size=3 => John Doe (12345)  : Login issues]");

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Try to add customer when queue is full
        // Expected Result: Should display error message
        Console.WriteLine("Test 4");
        cs = new CustomerService(2);
        cs.TestAddCustomer("Alice", "111", "Password reset");
        cs.TestAddCustomer("Bob", "222", "Account locked");
        Console.WriteLine("Queue before trying to add third customer:");
        Console.WriteLine(cs);
        Console.WriteLine("Trying to add third customer to full queue:");
        cs.TestAddCustomer("Charlie", "333", "Billing issue");

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Serve a customer from queue with customers
        // Expected Result: Should display customer info and remove from queue
        Console.WriteLine("Test 5");
        cs = new CustomerService(3);
        cs.TestAddCustomer("David", "444", "Technical support");
        cs.TestAddCustomer("Eve", "555", "Refund request");
        Console.WriteLine("Before serving customer:");
        Console.WriteLine(cs);
        Console.WriteLine("Serving customer:");
        cs.ServeCustomer();
        Console.WriteLine("After serving customer:");
        Console.WriteLine(cs);

        Console.WriteLine("=================");

        // Test 6
        // Scenario: Try to serve customer from empty queue
        // Expected Result: Should display error message
        Console.WriteLine("Test 6");
        cs = new CustomerService(5);
        Console.WriteLine("Trying to serve customer from empty queue:");
        cs.ServeCustomer();

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No customers in the queue.");
            return;
        }
        
        var customer = _queue[0];  // Get the first customer
        _queue.RemoveAt(0);        // Then remove them
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }

    /// <summary>
    /// Test version of AddNewCustomer that doesn't require user input
    /// </summary>
    public void TestAddCustomer(string name, string accountId, string problem) {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }
}