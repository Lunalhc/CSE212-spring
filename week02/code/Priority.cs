public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Enqueue items with different priorities and dequeue them.
        // Expected Result: item 1,3,2,4
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("Item 1", 3); // Higher priority
        priorityQueue.Enqueue("Item 2", 2);
        priorityQueue.Enqueue("Item 3", 3); // Higher priority, added after Item 1
        priorityQueue.Enqueue("Item 4", 1);
        Console.WriteLine(priorityQueue.Dequeue()); 
        Console.WriteLine(priorityQueue.Dequeue()); 
        Console.WriteLine(priorityQueue.Dequeue()); 
        Console.WriteLine(priorityQueue.Dequeue()); 

        // Defect(s) Found: 

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Enqueue items with the same priority and dequeue them.
        // Expected Result: Item A,B,C
        Console.WriteLine("Test 2");
        priorityQueue.Enqueue("Item A", 2);
        priorityQueue.Enqueue("Item B", 2);
        priorityQueue.Enqueue("Item C", 2);
        Console.WriteLine(priorityQueue.Dequeue()); 
        Console.WriteLine(priorityQueue.Dequeue()); 
        Console.WriteLine(priorityQueue.Dequeue()); 

        // Defect(s) Found: 

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: Try to dequeue from an empty queue.
        // Expected Result: the queue is empty
        Console.WriteLine("Test 3");
        Console.WriteLine(priorityQueue.Dequeue()); 
    }
}