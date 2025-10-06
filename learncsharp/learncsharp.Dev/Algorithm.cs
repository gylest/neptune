namespace learncsharp;

public class Algorithm
{
    public Algorithm()
    {
    }

    //
    // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    // You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //
    public int[] TwoSum(int[] nums, int target)
    {
        int[] resultNotFound = { -1, -1 };
        int outer = nums.Length - 1;
        int inner = outer;
        int index = 0;
        int value1, value2;
        int index1, index2;

        for (int i = 0; i < outer; ++i)
        {
            for (int j = 0; j < inner; ++j)
            {
                value1 = nums[index];
                value2 = nums[index + j + 1];

                if ((value1 + value2) == target)
                {
                    index1 = index;
                    index2 = index + j + 1;
                    int[] result = { index1, index2 };

                    return result;
                }
            }

            --inner;
            ++index;

        }

        // return value if not found
        return resultNotFound;
    }
}

