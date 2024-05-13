using System.Text.Json;

public static class SetsAndMapsTester {
    public static void Run() {
        // Problem 1: Find Pairs with Sets
        Console.WriteLine("\n=========== Finding Pairs TESTS ===========");
        DisplayPairs(new[] { "am", "at", "ma", "if", "fi" });
        // ma & am
        // fi & if
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "bc", "cd", "de", "ba" });
        // ba & ab
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ba", "ac", "ad", "da", "ca" });
        // ba & ab
        // da & ad
        // ca & ac
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "ac" }); // No pairs displayed
        Console.WriteLine("---------");
        DisplayPairs(new[] { "ab", "aa", "ba" });
        // ba & ab
        Console.WriteLine("---------");
        DisplayPairs(new[] { "23", "84", "49", "13", "32", "46", "91", "99", "94", "31", "57", "14" });
        // 32 & 23
        // 94 & 49
        // 31 & 13

        // Problem 2: Degree Summary
        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== Census TESTS ===========");
        Console.WriteLine(string.Join(", ", SummarizeDegrees("census.txt")));
        // Results may be in a different order:
        // <Dictionary>{[Bachelors, 5355], [HS-grad, 10501], [11th, 1175],
        // [Masters, 1723], [9th, 514], [Some-college, 7291], [Assoc-acdm, 1067],
        // [Assoc-voc, 1382], [7th-8th, 646], [Doctorate, 413], [Prof-school, 576],
        // [5th-6th, 333], [10th, 933], [1st-4th, 168], [Preschool, 51], [12th, 433]}

        // Problem 3: Anagrams
        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== Anagram TESTS ===========");
        Console.WriteLine(IsAnagram("CAT", "ACT")); // true
        Console.WriteLine(IsAnagram("DOG", "GOOD")); // false
        Console.WriteLine(IsAnagram("AABBCCDD", "ABCD")); // false
        Console.WriteLine(IsAnagram("ABCCD", "ABBCD")); // false
        Console.WriteLine(IsAnagram("BC", "AD")); // false
        Console.WriteLine(IsAnagram("Ab", "Ba")); // true
        Console.WriteLine(IsAnagram("A Decimal Point", "Im a Dot in Place")); // true
        Console.WriteLine(IsAnagram("tom marvolo riddle", "i am lord voldemort")); // true
        Console.WriteLine(IsAnagram("Eleven plus Two", "Twelve Plus One")); // true
        Console.WriteLine(IsAnagram("Eleven plus One", "Twelve Plus One")); // false

        // Problem 4: Maze
        Console.WriteLine("\n=========== Maze TESTS ===========");
        Dictionary<ValueTuple<int, int>, bool[]> map = SetupMazeMap();
        var maze = new Maze(map);
        maze.ShowStatus(); // Should be at (1,1)
        maze.MoveUp(); // Error
        maze.MoveLeft(); // Error
        maze.MoveRight(); //(2,1)
        maze.MoveRight(); // Error
        maze.MoveDown(); //(2,2)
        maze.MoveDown(); //(2,3)
        maze.MoveRight(); // error
        maze.MoveDown(); //(2,4)
        maze.MoveRight(); //(3,4)
        maze.MoveRight(); //(4,4)
        maze.MoveRight(); //(5,4)
        maze.MoveDown(); //(5,5)
        maze.MoveDown(); //(5,6)
        maze.MoveRight(); //(6,6)

                
    }

    
    private static void DisplayPairs(string[] words) {
        
        HashSet<string> seenWords = new HashSet<string>();
        foreach (var word in words)
        {
            // Reverse the current word to check for its symmetric pair
            string reverseWord = Reverse(word);

            // Check if the reversed word exists in the set
            if (seenWords.Contains(reverseWord))
            {
                // Display the pair
                Console.WriteLine($"{reverseWord} & {word}");
            }
            else
            {
                // Add the current word to the set
                seenWords.Add(word);
            }
        }

    }

    private static string Reverse(string word)
    {
        // Reverse the order of characters in the word
        return word[1].ToString() + word[0];
    }

    

    private static Dictionary<string, int> SummarizeDegrees(string filename) {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename)) {
            var fields = line.Split(",");
            // Todo Problem 2 - ADD YOUR CODE HERE
            if (fields.Length >= 4) // Ensure the line has at least 4 fields
            {
                string degree = fields[3].Trim(); // Extract the degree from the 4th column
                if (!string.IsNullOrEmpty(degree))
                {
                    // Update the count for the degree in the dictionary
                    if (degrees.ContainsKey(degree))
                    {
                        degrees[degree]++;
                    }
                    else
                    {
                        degrees[degree] = 1;
                    }
                }
            }

        }

        return degrees;
    }

    
    private static bool IsAnagram(string word1, string word2) {
        // Remove spaces and convert both words to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // If lengths are not equal, they cannot be anagrams
        if (word1.Length != word2.Length)
            return false;

        // Dictionary to store the count of each letter in word1
        Dictionary<char, int> letterCount = new Dictionary<char, int>();

        // Count the occurrences of each letter in word1
        foreach (char c in word1)
        {
            if (letterCount.ContainsKey(c))
                letterCount[c]++;
            else
                letterCount[c] = 1;
        }

        // Compare word2 with word1
        foreach (char c in word2)
        {
            // If a letter in word2 is not found in word1 or if its count is zero, they are not anagrams
            if (!letterCount.ContainsKey(c) || letterCount[c] == 0)
                return false;

            // Decrease the count of the letter in word1
            letterCount[c]--;
        }

        // If all letters in word2 have been matched and their counts are zero, they are anagrams
        return true;
    }

    
    
    private static Dictionary<ValueTuple<int, int>, bool[]> SetupMazeMap() {
        Dictionary<ValueTuple<int, int>, bool[]> map = new() {
            { (1, 1), new[] { false, true, false, true } },
            { (1, 2), new[] { false, true, true, false } },
            { (1, 3), new[] { false, false, false, false } },
            { (1, 4), new[] { false, true, false, true } },
            { (1, 5), new[] { false, false, true, true } },
            { (1, 6), new[] { false, false, true, false } },
            { (2, 1), new[] { true, false, false, true } },
            { (2, 2), new[] { true, false, true, true } },
            { (2, 3), new[] { false, false, true, true } },
            { (2, 4), new[] { true, true, true, false } },
            { (2, 5), new[] { false, false, false, false } },
            { (2, 6), new[] { false, false, false, false } },
            { (3, 1), new[] { false, false, false, false } },
            { (3, 2), new[] { false, false, false, false } },
            { (3, 3), new[] { false, false, false, false } },
            { (3, 4), new[] { true, true, false, true } },
            { (3, 5), new[] { false, false, true, true } },
            { (3, 6), new[] { false, false, true, false } },
            { (4, 1), new[] { false, true, false, false } },
            { (4, 2), new[] { false, false, false, false } },
            { (4, 3), new[] { false, true, false, true } },
            { (4, 4), new[] { true, true, true, false } },
            { (4, 5), new[] { false, false, false, false } },
            { (4, 6), new[] { false, false, false, false } },
            { (5, 1), new[] { true, true, false, true } },
            { (5, 2), new[] { false, false, true, true } },
            { (5, 3), new[] { true, true, true, true } },
            { (5, 4), new[] { true, false, true, true } },
            { (5, 5), new[] { false, false, true, true } },
            { (5, 6), new[] { false, true, true, false } },
            { (6, 1), new[] { true, false, false, false } },
            { (6, 2), new[] { false, false, false, false } },
            { (6, 3), new[] { true, false, false, false } },
            { (6, 4), new[] { false, false, false, false } },
            { (6, 5), new[] { false, false, false, false } },
            { (6, 6), new[] { true, false, false, false } }
        };
        return map;
    }

    public class Maze
{
    private Dictionary<(int, int), bool[]> map;
    private (int, int) currentPosition;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        map = mazeMap;
        currentPosition = (1, 1); // Starting position
    }

        private bool IsValidMove((int, int) position, int direction)
{
    if (!map.ContainsKey(position))
        return false;

    bool[] directions = map[position];

    // Check if the specified direction is valid based on the map configuration
    return directions[direction];
}

public void MoveLeft()
{
    var newPosition = (currentPosition.Item1-1, currentPosition.Item2);
    if (IsValidMove(currentPosition, 0)) // Check if left movement is valid
    {
        currentPosition = newPosition;
        Console.WriteLine($"Moved left to position: {currentPosition}");
    }
    else
    {
        Console.WriteLine("Error: Cannot move left from current position");
    }
}

public void MoveRight()
{
    var newPosition = (currentPosition.Item1+1, currentPosition.Item2);
    if (IsValidMove(currentPosition, 1)) // Check if right movement is valid
    {
        currentPosition = newPosition;
        Console.WriteLine($"Moved right to position: {currentPosition}");
    }
    else
    {
        Console.WriteLine("Error: Cannot move right from current position");
    }
}

public void MoveUp()
{
    var newPosition = (currentPosition.Item1, currentPosition.Item2-1);
    if (IsValidMove(currentPosition, 2)) // Check if up movement is valid
    {
        currentPosition = newPosition;
        Console.WriteLine($"Moved up to position: {currentPosition}");
    }
    else
    {
        Console.WriteLine("Error: Cannot move up from current position");
    }
}

public void MoveDown()
{
    var newPosition = (currentPosition.Item1, currentPosition.Item2+1);
    if (IsValidMove(currentPosition, 3)) // Check if down movement is valid
    {
        currentPosition = newPosition;
        Console.WriteLine($"Moved down to position: {currentPosition}");
    }
    else
    {
        Console.WriteLine("Error: Cannot move down from current position");
    }
}
    public void ShowStatus()
    {
        Console.WriteLine($"Current Position: {currentPosition}");
    }
}
}
   

