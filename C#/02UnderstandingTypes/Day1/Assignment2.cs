using System.Text.RegularExpressions;

namespace _02UnderstandingTypes;

public class PracticeArrays
{
    public static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }

    public static void PrintArray(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i != array.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
    public static void CopyArray()
    {
        int[] originalArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] newArray = new int[originalArray.Length];
        for (byte i = 0; i < originalArray.Length; i++)
        {
            newArray[i] = originalArray[i];
        }
        Console.WriteLine("Original array:");
        PrintArray(originalArray);
        
        Console.WriteLine("New array:");
        PrintArray(newArray);
    }

    public static void ListManager()
    {
        List<string> itemList = new List<string>();
        bool shouldLoop = true;
        while (shouldLoop)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear, or q to exit)):");
            string input = Console.ReadLine();
            switch (input[0])
            {
                case '+': // Add an item to the list
                    string itemToAdd = input.Substring(1).Trim();
                    if (!string.IsNullOrEmpty(itemToAdd))
                    {
                        itemList.Add(itemToAdd);
                        PrintArray(itemList.ToArray());
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid item to add.");
                    }

                    break;

                case '-': // Remove an item or clear the list
                    if (input == "--")
                    {
                        itemList.Clear();
                        Console.WriteLine("List cleared.");
                    }
                    else
                    {
                        string itemToRemove = input.Substring(1).Trim();
                        if (itemList.Contains(itemToRemove))
                        {
                            itemList.Remove(itemToRemove);
                            PrintArray(itemList.ToArray());
                        }
                        else
                        {
                            Console.WriteLine($"Item not found: {itemToRemove}");
                        }
                    }

                    break;
                case 'q':
                    shouldLoop = false;
                    break;

                default: // Invalid input
                    Console.WriteLine("Invalid input. Use + to add, - to remove, or -- to clear.");
                    break;
            }
        }
    }

    public static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for (int i = startNum; i <= endNum; i++)
        {
            // if prime
            bool isPrime = true;
            for (int j = 2; j*j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primes.Add(i);
            }
        }
        return primes.ToArray();
    }

    public static void RotateArray()
    {
        Console.WriteLine("Enter the array of integers (space separated):");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("Enter the number of rotations:");
        int k = int.Parse(Console.ReadLine());

        int n = array.Length;
        int[] sumArray = new int[n]; 

        
        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = new int[n];
            // rotate array
            for (int i = 0; i < n; i++)
            {
                int newPosition = (i + r) % n;
                rotatedArray[newPosition] = array[i];
            }
            // add it to sum array
            for (int i = 0; i < n; i++)
            {
                sumArray[i] += rotatedArray[i];
            }
        }
        Console.WriteLine("Sum array:");
        Console.WriteLine(string.Join(" ", sumArray));
    }

    public static void LongestSequenceOfEqualElements(int[] array)
    {
        int currentNum = array[0];
        int currentLength = 1;
        int longestNum = currentNum;
        int longestLength = currentLength;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == currentNum)
            {
                currentLength++;
            }
            else
            {
                currentNum = array[i];
                currentLength = 1;
            }

            if (currentLength > longestLength)
            {
                longestLength = currentLength;
                longestNum = currentNum;
                
            }
        }

        for (int i = 0; i < longestLength; i++)
        {
            Console.Write(longestNum + " ");
        }
        Console.WriteLine();
    }

    public static void MostFrequentNumber(int[] array)
    {
        Dictionary<int, int> frequencies = new Dictionary<int, int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (!frequencies.ContainsKey(array[i]))
            {
                frequencies.Add(array[i], 1);
            }
            else
            {
                frequencies[array[i]]++;
            }
        }

        int mostFrequentNumber = 0;
        int frequency = 0;
        foreach (KeyValuePair<int,int> keyValuePair in frequencies)
        {
            if (keyValuePair.Value > frequency)
            {
                mostFrequentNumber = keyValuePair.Key;
                frequency = keyValuePair.Value;
            }
        }
        Console.WriteLine($"Most frequent number is {mostFrequentNumber}");
    }

    
}

public class PracticeStrings
{
    public static void ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        for (int i = 0; i < charArray.Length / 2; i++)
        {
            char temp = charArray[i];
            charArray[i] = charArray[charArray.Length - 1 - i];
            charArray[charArray.Length - 1 - i] = temp;
        }
        string reversedString = new string(charArray);
        Console.WriteLine(reversedString);

        for (int i = s.Length - 1; i >= 0; i--)
        {
            Console.Write(s[i]);
        }
        Console.WriteLine();
    }
    
    public static string ReverseWordsInSentence(string sentence)
    {
        string pattern = @"[\s.,:;=\(\)&\[\]""'\\\/!?]+";
        List<string> words = new List<string>(Regex.Split(sentence, pattern));
        words.RemoveAll(w => string.IsNullOrEmpty(w));
        words.Reverse();
        List<string> separators = new List<string>(Regex.Matches(sentence, pattern).Cast<Match>().Select(m => m.Value));

        string CombineWordsAndSeparators(List<string> wordsList, List<string> separatorsList)
        {
            List<string> result = new List<string>();
            int maxLength = Math.Max(wordsList.Count, separatorsList.Count);
            for (int i = 0; i < maxLength; i++)
            {
                if (i < wordsList.Count)
                {
                    result.Add(wordsList[i]);
                }
                if (i < separatorsList.Count)
                {
                    result.Add(separatorsList[i]);
                }
            }
            return string.Join("", result);
        }
        string answer = CombineWordsAndSeparators(words, separators);
        Console.WriteLine(answer);
        return answer;
    }

    public static string[] GetPalindromes(string sentence)
    {
        bool IsPalindrome(string word)
        {
            int length = word.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (word[i] != word[length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
        string[] words = Regex.Split(sentence, @"\W+");  
        HashSet<string> palindromesSet = new HashSet<string>();
        foreach (string word in words)
        {
            if (IsPalindrome(word))  
            {
                palindromesSet.Add(word);
            }
        }
        string[] palindromesArray = palindromesSet.ToArray();
        Array.Sort(palindromesArray);  
        PracticeArrays.PrintArray(palindromesArray);
        return palindromesArray;
    }

    public static void URLParser(string url)
    {
        string protocol = "";
        if (url.Contains("://"))
        {
            int protocolIndex = url.IndexOf("://");
            protocol = url.Substring(0, protocolIndex);
            url = url.Substring(protocolIndex + 3);
        }

        string server = url;
        string resource = "";
        if (url.Contains("/"))
        {
            int slashIndex = url.IndexOf("/");
            server = url.Substring(0, slashIndex);
            resource = url.Substring(slashIndex+1);
        }
        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }
}

