/// <summary>
/// This queue is circular.  When people are added via add_person, then they are added to the 
/// back of the queue (per FIFO rules).  When get_next_person is called, the next person
/// in the queue is displayed and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
/// 


public class TakingTurnsQueue {
    private readonly Queue<(string name, int turns)> _people = new Queue<(string name, int turns)>();

    public int Length => _people.Count;

    public void AddPerson(string name, int turns) {
        _people.Enqueue((name, turns));
    }

    public void GetNextPerson() {
        if (_people.Count == 0) {
            Console.WriteLine("No one in the queue.");
            return;
        }

        var (name, turns) = _people.Dequeue();
        Console.WriteLine(name); // Output the name

        if (turns > 1 || turns < 1) { // If turns is greater than 1 or infinite, re-enqueue
            _people.Enqueue((name, turns - 1));
        }
    }
}