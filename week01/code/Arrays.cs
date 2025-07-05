public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new array of doubles with the given length.
        // 2. Use a for loop to fill each position in the array.
        // 3. For each index i, set the value to number * (i + 1).
        // 4. Return the filled array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Find the number of elements in the list (n).
        // 2. Use GetRange to get the last 'amount' elements from the list.
        // 3. Remove those 'amount' elements from the end of the list using RemoveRange.
        // 4. Insert the saved elements at the beginning of the list using InsertRange.
        // 5. The list is now rotated to the right by 'amount' positions.

        int n = data.Count;
        if (amount <= 0 || amount >= n) return; // No rotation needed if amount is 0 or >= n

        // Step 2: Get the last 'amount' elements
        List<int> temp = data.GetRange(n - amount, amount);

        // Step 3: Remove those elements from the end
        data.RemoveRange(n - amount, amount);

        // Step 4: Insert them at the beginning
        data.InsertRange(0, temp);
    }
}
