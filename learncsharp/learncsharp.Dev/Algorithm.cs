namespace learncsharp.Dev;

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

    //
    // Finds the first non-repeating character in a string.
    //
    public char FirstNonRepeatingChar(string s)
    {
        var characterCount = new Dictionary<char, int>();

        // Iterate over string and store count for each character
        foreach (char ch in s)
        {
            if (characterCount.ContainsKey(ch))
            {
                characterCount[ch]++;
            }
            else
            {
                characterCount[ch] = 1;
            }
        }

        // Iterate over string looking for first non-repeater
        foreach (char ch in s)
        {
            if (characterCount[ch] == 1)
            {
                return ch;
            }
        }

        // return null character if no non-repeater found
        return '\0';
    }

    //
    // Convert Roman to Integer
    //
    // Example 1: Input: s = "III" Output: 3 Explanation: III = 3.
    // Example 2: Input: s = "LVIII" Output: 58 Explanation: L = 50, V= 5, III = 3.
    // Example 3: Input: s = "MCMXCIV" Output: 1994 Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
    //
    public int RomanToInt(string s)
    {
        var romanNumerals = new Dictionary<string, int>() { { "I", 1 }, { "V", 5 }, { "X", 10 } , { "L", 50 }, { "C", 100 },
                                                            { "D", 500 }, { "M", 1000 }, { "IV", 4 } , { "IX", 9 }, { "XL", 40 },
                                                            { "XC", 90 }, { "CD", 400 }, { "CM", 900 } };

        int Total = 0;
        bool skip = false;

        for (int i = 0; i < s.Length; ++i)
        {
            if (skip)
            {
                skip = false;
            }
            else
            {
                string s1 = s[i].ToString();
                if (i < (s.Length - 1))
                {
                    string s2 = s.Substring(i, 2);
                    bool readOk = romanNumerals.TryGetValue(s2, out int val);
                    if (readOk)
                    {
                        skip = true;
                        Total += val;
                    }
                    else
                    {
                        Total += romanNumerals[s1];
                    }
                }
                else
                {
                    Total += romanNumerals[s1];
                }
            }
        }

        return Total;

    }
}

