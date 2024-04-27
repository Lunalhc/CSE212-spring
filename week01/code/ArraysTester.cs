using System.Globalization;

public static class ArraysTester {
    
    public static void Run() {
        
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        double[] multiples = MultiplesOf(7, 5);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{7, 14, 21, 28, 35}
        multiples = MultiplesOf(1.5, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{1.5, 3.0, 4.5, 6.0, 7.5, 9.0, 10.5, 12.0, 13.5, 15.0}
        multiples = MultiplesOf(-2, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{-2, -4, -6, -8, -10, -12, -14, -16, -18, -20}
        

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 1);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{9, 1, 2, 3, 4, 5, 6, 7, 8}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 5);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 3);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 9);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{1, 2, 3, 4, 5, 6, 7, 8, 9}
        
    }
    
    private static double[] MultiplesOf(double number, int length)
    {
        List<double> numbers = new List<double>();  // create a list that will store the numbers
        for (int i = 1; i < length+1; i++)  // a for loop that go through i times
            // i is the iteration, also the muplying factor
            // iterate until it got the required length
        {
            double newnumber = i*number;   // algorithm to find the next number
            numbers.Add(newnumber);   // append the number to the list
        }

        return numbers.ToArray();  // return to the list
    }
    
    
    private static void RotateListRight(List<int> data, int amount)
    {   
        int length = data.Count;  // calculate the length of the datalist
        amount = amount % length; // use modulus to find the shift number so that it is always within the field

        int[] temporary = new int[amount]; // create a temporary array to store the new elements

        for(int i = 0; i <amount; i++)  // for loop to copy the last "amount" of elements firectly to new temporary array
        {
            temporary[i] = data[length - amount +i];
            
        }

        for (int i = length -1; i>=amount; i--)  // shift the remaining element
        {
            data[i] = data[i - amount];
        }

        for (int i = 0;i<amount; i++)  // copy the elements in temporay array to the data list so that we don't have to rerturn to a new array
        {
            data[i] = temporary[i];
        }
        
    }
}
