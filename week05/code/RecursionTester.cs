public static class RecursionTester {
    /// <summary>
    /// Entry point for the Prove 8 tests
    /// </summary>
    public static void Run() {
        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        Console.WriteLine(SumSquaresRecursive(10)); // 385
        Console.WriteLine(SumSquaresRecursive(100)); // 338350

        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        PermutationsChoose("ABCD", 3);
        // Expected Result (order may be different):
        // ABC
        // ABD
        // ACB
        // ACD
        // ADB
        // ADC
        // BAC
        // BAD
        // BCA
        // BCD
        // BDA
        // BDC
        // CAB
        // CAD
        // CBA
        // CBD
        // CDA
        // CDB
        // DAB
        // DAC
        // DBA
        // DBC
        // DCA
        // DCB

        Console.WriteLine("---------");
        PermutationsChoose("ABCD", 2);
        // Expected Result (order may be different):
        // AB
        // AC
        // AD
        // BA
        // BC
        // BD
        // CA
        // CB
        // CD
        // DA
        // DB
        // DC

        Console.WriteLine("---------");
        PermutationsChoose("ABCD", 1);
        // Expected Result (order may be different):
        // A
        // B
        // C
        // D

        // Sample Test Cases (may not be comprehensive) 
        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        Console.WriteLine(CountWaysToClimb(5)); // 13
        Console.WriteLine(CountWaysToClimb(20)); // 121415
        //Console.WriteLine(CountWaysToClimb(100));  // 180396380815100901214157639
        // i keep the last one commented out because it will crash my laptop
         
        Console.WriteLine("\n=========== PROBLEM 4 TESTS ===========");
        WildcardBinary("110*0*");
        // 110000
        // 110001
        // 110100
        // 110101
        WildcardBinary("***");
        // 000   
        // 001   
        // 010
        // 011
        // 100
        // 101
        // 110
        // 111

        
        Console.WriteLine("\n=========== PROBLEM 5 TESTS ===========");
        Maze smallMaze = new Maze(3, 3, new[] { 1, 1, 1, 1, 0, 1, 1, 1, 2 });
        SolveMaze(smallMaze);
        // Two Solutions (order in each solution should match):
        // <List>{(0, 0), (0, 1), (0, 2), (1, 2), (2, 2)}
        // <List>{(0, 0), (1, 0), (2, 0), (2, 1), (2, 2)}

        Maze bigMaze = new(20, 20,
            new[] {
                1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1,
                1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1,
                0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0,
                0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
                0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1,
                1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1,
                0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1,
                0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1,
                0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1,
                0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1,
                1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0,
                0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0,
                0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1,
                0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0,
                0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0,
                1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 2
            });
        SolveMaze(bigMaze);
        // One Solution (order should match):
        // <List>{(0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (3, 3), (3, 4), (3, 5),
        // (3, 6), (2, 6), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10), (2, 10), (3, 10),
        // (4, 10), (5, 10), (5, 9), (5, 8), (5, 7), (5, 6), (5, 5), (5, 4), (5, 3),
        // (5, 2), (5, 1), (5, 0), (6, 0), (7, 0), (8, 0), (9, 0), (10, 0), (10, 1),
        // (10, 2), (10, 3), (10, 4), (10, 5), (10, 6), (9, 6), (8, 6), (8, 7), (8, 8),
        // (7, 8), (7, 9), (7, 10), (7, 11), (7, 12), (7, 13), (6, 13), (5, 13), (5, 14), 
        // (5, 15), (5, 16), (5, 17), (5, 18), (5, 19), (6, 19), (7, 19), (8, 19), (9, 19),
        // (10, 19), (11, 19), (12, 19), (12, 18), (12, 17), (12, 16), (12, 15), (12, 14),
        // (12, 13), (12, 12), (12, 11), (12, 10), (12, 9), (13, 9), (14, 9), (15, 9),
        // (15, 8), (15, 7), (15, 6), (15, 5), (14, 5), (13, 5), (12, 5), (12, 4), (12, 3),
        // (12, 2), (12, 1), (13, 1), (14, 1), (15, 1), (16, 1), (17, 1), (17, 2), (17, 3),
        // (17, 4), (17, 5), (18, 5), (19, 5), (19, 6), (19, 7), (19, 8), (19, 9), (19, 10),
        // (19, 11), (19, 12), (18, 12), (17, 12), (16, 12), (16, 13), (16, 14), (16, 15), 
        // (17, 15), (18, 15), (18, 16), (18, 17), (18, 18), (18, 19), (19, 19)}
    }

    
    public static int SumSquaresRecursive(int n) {
       
        if (n <= 0)
        {
            return 0;
        }
        else
        {
            return n * n + SumSquaresRecursive(n-1);
        }
    }

    
    public static void PermutationsChoose(string letters, int size, string word = "") {
        if (word.Length == size)
        {
            Console.WriteLine (word);
        }
        else
        {
            for (var i = 0; i < letters.Length; i++)
            {
                var lettersLeft = letters.Remove(i, 1);
                
                PermutationsChoose(lettersLeft, size, word + letters[i]);
            }

            
        }
       
    }

    
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null) {
        
        if (remember == null) {
        remember = new Dictionary<int, decimal>();
        }
        
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.ContainsKey(s)) {
        return remember[s];
        }
        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1) + CountWaysToClimb(s - 2) + CountWaysToClimb(s - 3);
        remember[s] = ways;
        return ways;
    }

    
    public static void WildcardBinary(string pattern) {

        int wildcardIndex = pattern.IndexOf('*');

        if (wildcardIndex == -1) {
        Console.WriteLine(pattern);
        }

        else{
            WildcardBinary(pattern.Substring(0, wildcardIndex) + '0' + pattern.Substring(wildcardIndex + 1));
            WildcardBinary(pattern.Substring(0, wildcardIndex) + '1' + pattern.Substring(wildcardIndex + 1));
        }
       
    }
        
    

    
    public static void SolveMaze(Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        
        currPath.Add((x, y));

        
        if (maze.IsEnd(x, y))
        {
            
            Console.WriteLine(currPath.AsString());
            
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        
        var directions = new (int, int)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

      
        foreach (var dir in directions)
        {
            int newX = x + dir.Item1;
            int newY = y + dir.Item2;

            
            if (maze.IsValidMove(currPath, newX, newY))
            {
                
                SolveMaze(maze, newX, newY, currPath);
            }
        }

        
        currPath.RemoveAt(currPath.Count - 1);
    }

    }
         
    
    
