# Data Structures Implementation Explanations

## Question 1: Implementing a Stack Using a Linked List

### Implementation Strategy
A stack follows the Last-In-First-Out (LIFO) principle, which aligns perfectly with using the head of a linked list as the stack's top. This design choice ensures optimal performance for all stack operations.

### Core Operations and Complexity Analysis

**Push Operation (O(1)):**
- Create a new node containing the data
- Set the new node's next pointer to the current head
- Update the head to point to the new node
- The constant time complexity results from direct head manipulation without traversal

**Pop Operation (O(1)):**
- Verify the stack is not empty
- Store the head node's data for return
- Update the head to point to the next node
- Remove the original head node
- Achieves O(1) through direct head access and removal

**GetTop Operation (O(1)):**
- Return the data value stored in the head node
- No structural modification required
- Constant time due to immediate head access

**IsEmpty Operation (O(1)):**
- Check if the head pointer is null
- Boolean evaluation requires no traversal
- Instantaneous determination of stack state

### Summary
This linked list implementation provides optimal efficiency for all stack operations, maintaining O(1) time complexity across the board through strategic use of the head pointer as the stack top.

---

## Question 2: Implementing a Queue Using a Linked List

### Implementation Strategy
A queue operates on the First-In-First-Out (FIFO) principle, requiring access to both ends of the data structure. The optimal approach maintains separate pointers to both the head (front) and tail (rear) of the linked list.

### Core Operations and Complexity Analysis

**Enqueue Operation (O(1)):**
- Create a new node with the incoming data
- Link the current tail's next pointer to the new node
- Update the tail pointer to the new node
- Handle edge case for empty queue by setting both head and tail
- Constant time achieved through direct tail manipulation

**Dequeue Operation (O(1)):**
- Verify the queue contains elements
- Store the head node's data for return
- Advance the head pointer to the next node
- Update tail to null if queue becomes empty
- O(1) complexity through direct head access

**Size Operation (O(1) or O(n)):**
- **Optimal approach:** Maintain an internal counter variable
  - Increment on enqueue, decrement on dequeue
  - Provides instant size retrieval in O(1) time
- **Alternative approach:** Traverse the entire list
  - Results in O(n) time complexity due to full traversal requirement

**IsEmpty Operation (O(1)):**
- Evaluate whether the head pointer equals null
- Immediate boolean result without traversal
- Constant time determination

### Summary
The dual-pointer approach (head and tail) enables efficient queue implementation with O(1) performance for enqueue, dequeue, and isEmpty operations. Maintaining an internal size counter ensures all operations achieve optimal time complexity, making this implementation highly efficient for queue-based applications.

---

## Question 3: Validating a Binary Search Tree Using Recursion

### Problem Overview
A Binary Search Tree (BST) is a specialized binary tree where each node maintains the ordering property: all values in the left subtree are less than the current node's value, and all values in the right subtree are greater than the current node's value. The challenge is to create a recursive function that verifies this property throughout the entire tree.

### Implementation Strategy
The key insight is that each node in a BST must satisfy constraints based on its position in the tree. A simple approach of comparing a node with only its immediate children is insufficient, as it doesn't account for ancestor constraints.

### Core Algorithm: Range-Based Validation

**Function Signature:**
```
IsBinarySearchTree(node, minValue, maxValue) -> boolean
```

**Recursive Logic:**
1. **Base Case:** If the current node is null, return true (empty subtrees are valid BSTs)
2. **Boundary Check:** Verify the current node's value falls within the allowed range [minValue, maxValue]
3. **Recursive Calls:**
   - Validate left subtree with updated maximum boundary (current node's value)
   - Validate right subtree with updated minimum boundary (current node's value)
4. **Return:** True only if current node is valid AND both subtrees are valid BSTs

### Detailed Algorithm Steps

**Initial Call:**
- Start with `IsBinarySearchTree(root, -∞, +∞)`
- Use extreme values to represent no initial constraints

**For Each Node:**
1. Check if `minValue < node.value < maxValue`
2. If invalid, return false immediately
3. Recursively validate left child: `IsBinarySearchTree(node.left, minValue, node.value)`
4. Recursively validate right child: `IsBinarySearchTree(node.right, node.value, maxValue)`
5. Return true only if both recursive calls return true

### Why This Approach Works

**Constraint Propagation:**
- Each recursive call narrows the valid range for descendant nodes
- Left subtree inherits the current minimum but gets a new maximum (current node's value)
- Right subtree inherits the current maximum but gets a new minimum (current node's value)

**Complete Validation:**
- Ensures every node respects not just its parent, but all ancestors in its path
- Prevents cases where local parent-child relationships are valid but global BST property is violated

### Time and Space Complexity

**Time Complexity: O(n)**
- Each node is visited exactly once
- Constant work performed at each node
- Linear traversal of all tree nodes

**Space Complexity: O(h)**
- Recursion depth equals tree height
- Best case (balanced tree): O(log n)
- Worst case (degenerate tree): O(n)
- Space used for recursive call stack

### Edge Cases Handled

1. **Empty Tree:** Null root returns true (empty trees are valid BSTs)
2. **Single Node:** Any single node forms a valid BST
3. **Duplicate Values:** Algorithm can be modified to handle duplicates by using ≤ or ≥ comparisons
4. **Degenerate Trees:** Linear chains are properly validated using range constraints

### Summary
The range-based recursive validation provides an elegant and efficient solution for BST verification. By maintaining and updating value constraints as we traverse the tree, we ensure that every node satisfies the BST property relative to all its ancestors, not just its immediate parent. This approach guarantees complete validation while maintaining optimal time complexity.
