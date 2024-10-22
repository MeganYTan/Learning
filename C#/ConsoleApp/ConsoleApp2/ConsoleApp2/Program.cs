// See https://aka.ms/new-console-template for more information

// Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
//
//  
//
//     Example 1:
//
// Input: haystack = "sadbutsad", needle = "sad"
// Output: 0
// Explanation: "sad" occurs at index 0 and 6.
//     The first occurrence is at index 0, so we return 0.
//     Example 2:
//
// Input: haystack = "leetcode", needle = "leeto"
// Output: -1
// Explanation: "leeto" did not occur in "leetcode", so we return -1.
public class Program
{
    public static int Haystack(string haystack, string needle)
    {
        int initialNeedleIndex = 0;
        int needleIndex = 0;
        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle[needleIndex])
            {
                needleIndex++;
                if (needleIndex == needle.Length)
                {
                    return initialNeedleIndex;
                }
            }
            else
            {
                initialNeedleIndex = i+1;
                needleIndex = 0;
            }

            

        }
        return -1;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(
        Haystack("ssadbutsad", "sad")
        );
    }
}
