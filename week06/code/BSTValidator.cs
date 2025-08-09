using System;

/// <summary>
/// Binary Search Tree Validator
/// This class provides methods to validate whether a binary tree is a valid Binary Search Tree (BST)
/// </summary>
public static class BSTValidator
{
    /// <summary>
    /// Determines if a binary tree is a valid Binary Search Tree
    /// Public interface method that initializes the validation process
    /// </summary>
    /// <param name="root">The root node of the binary tree to validate</param>
    /// <returns>True if the tree is a valid BST, false otherwise</returns>
    public static bool IsBinarySearchTree(Node? root)
    {
        // Start validation with no constraints (negative and positive infinity)
        return IsBinarySearchTreeHelper(root, int.MinValue, int.MaxValue);
    }

    /// <summary>
    /// Recursive helper method that validates BST property with range constraints
    /// </summary>
    /// <param name="node">Current node being validated</param>
    /// <param name="minValue">Minimum allowed value for this node (exclusive)</param>
    /// <param name="maxValue">Maximum allowed value for this node (exclusive)</param>
    /// <returns>True if the subtree rooted at node is a valid BST, false otherwise</returns>
    private static bool IsBinarySearchTreeHelper(Node? node, int minValue, int maxValue)
    {
        // Base case: empty subtree is a valid BST
        if (node == null)
            return true;

        // Check if current node violates BST property based on ancestor constraints
        if (node.Data <= minValue || node.Data >= maxValue)
            return false;

        // Recursively validate both subtrees with updated constraints
        // Left subtree: all values must be less than current node's value
        // Right subtree: all values must be greater than current node's value
        return IsBinarySearchTreeHelper(node.Left, minValue, node.Data) &&
               IsBinarySearchTreeHelper(node.Right, node.Data, maxValue);
    }

    /// <summary>
    /// Alternative implementation using nullable long values for true infinity bounds
    /// This version handles edge cases where node values might be int.MinValue or int.MaxValue
    /// </summary>
    /// <param name="root">The root node of the binary tree to validate</param>
    /// <returns>True if the tree is a valid BST, false otherwise</returns>
    public static bool IsBinarySearchTreeAdvanced(Node? root)
    {
        return IsBinarySearchTreeAdvancedHelper(root, null, null);
    }

    /// <summary>
    /// Advanced recursive helper with true unbounded constraints
    /// </summary>
    /// <param name="node">Current node being validated</param>
    /// <param name="minValue">Minimum allowed value (null means no lower bound)</param>
    /// <param name="maxValue">Maximum allowed value (null means no upper bound)</param>
    /// <returns>True if the subtree rooted at node is a valid BST, false otherwise</returns>
    private static bool IsBinarySearchTreeAdvancedHelper(Node? node, long? minValue, long? maxValue)
    {
        // Base case: empty subtree is a valid BST
        if (node == null)
            return true;

        // Check lower bound constraint
        if (minValue.HasValue && node.Data <= minValue.Value)
            return false;

        // Check upper bound constraint
        if (maxValue.HasValue && node.Data >= maxValue.Value)
            return false;

        // Recursively validate both subtrees with updated constraints
        return IsBinarySearchTreeAdvancedHelper(node.Left, minValue, node.Data) &&
               IsBinarySearchTreeAdvancedHelper(node.Right, node.Data, maxValue);
    }

    /// <summary>
    /// Demonstration method that creates test cases and validates them
    /// </summary>
    public static void RunValidationTests()
    {
        Console.WriteLine("=== Binary Search Tree Validation Tests ===\n");

        // Test Case 1: Valid BST
        Console.WriteLine("Test 1: Valid BST");
        Console.WriteLine("Tree structure:");
        Console.WriteLine("    10");
        Console.WriteLine("   /  \\");
        Console.WriteLine("  5    15");
        Console.WriteLine(" / \\   / \\");
        Console.WriteLine("2   7 12  20");
        
        var validBST = new Node(10);
        validBST.Insert(5);
        validBST.Insert(15);
        validBST.Insert(2);
        validBST.Insert(7);
        validBST.Insert(12);
        validBST.Insert(20);
        
        bool isValid1 = IsBinarySearchTree(validBST);
        Console.WriteLine($"Is valid BST: {isValid1}");
        Console.WriteLine($"Expected: True\n");

        // Test Case 2: Invalid BST (manually constructed to violate BST property)
        Console.WriteLine("Test 2: Invalid BST");
        Console.WriteLine("Tree structure (manually constructed):");
        Console.WriteLine("    10");
        Console.WriteLine("   /  \\");
        Console.WriteLine("  5    15");
        Console.WriteLine(" / \\   /");
        Console.WriteLine("2   7 12");
        Console.WriteLine("     \\");
        Console.WriteLine("      6  <- This violates BST property!");
        
        var invalidBST = new Node(10);
        var leftChild = new Node(5);
        var rightChild = new Node(15);
        var leftLeft = new Node(2);
        var leftRight = new Node(7);
        var rightLeft = new Node(12);
        var invalidNode = new Node(6); // This will make it invalid
        
        // Manually construct the tree to create an invalid BST
        invalidBST.GetType().GetProperty("Left")?.SetValue(invalidBST, leftChild);
        invalidBST.GetType().GetProperty("Right")?.SetValue(invalidBST, rightChild);
        leftChild.GetType().GetProperty("Left")?.SetValue(leftChild, leftLeft);
        leftChild.GetType().GetProperty("Right")?.SetValue(leftChild, leftRight);
        rightChild.GetType().GetProperty("Left")?.SetValue(rightChild, rightLeft);
        leftRight.GetType().GetProperty("Right")?.SetValue(leftRight, invalidNode);
        
        bool isValid2 = IsBinarySearchTree(invalidBST);
        Console.WriteLine($"Is valid BST: {isValid2}");
        Console.WriteLine($"Expected: False");
        Console.WriteLine("Reason: Node with value 6 is in right subtree of node with value 5,");
        Console.WriteLine("but 6 > 5, violating BST property for the subtree rooted at 10.\n");

        // Test Case 3: Single node (always valid)
        Console.WriteLine("Test 3: Single node");
        var singleNode = new Node(42);
        bool isValid3 = IsBinarySearchTree(singleNode);
        Console.WriteLine($"Is valid BST: {isValid3}");
        Console.WriteLine($"Expected: True\n");

        // Test Case 4: Empty tree (always valid)
        Console.WriteLine("Test 4: Empty tree");
        bool isValid4 = IsBinarySearchTree(null);
        Console.WriteLine($"Is valid BST: {isValid4}");
        Console.WriteLine($"Expected: True\n");

        Console.WriteLine("=== Validation Tests Complete ===");
    }
}
