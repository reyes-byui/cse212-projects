public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing (no duplicates)
    }

    public bool Contains(int value)
    {
        // Check if the current node contains the value
        if (value == Data)
            return true;
        else if (value < Data && Left != null)
            return Left.Contains(value);
        else if (value > Data && Right != null)
            return Right.Contains(value);
        return false;
    }

    public int GetHeight()
    {
        // Height is 1 + max height of left/right subtrees
        int leftHeight = Left != null ? Left.GetHeight() : 0;
        int rightHeight = Right != null ? Right.GetHeight() : 0;
        return 1 + (leftHeight > rightHeight ? leftHeight : rightHeight);
    }
}