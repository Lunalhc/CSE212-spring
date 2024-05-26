using System.Collections;

public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail;

    
    public void InsertHead(int value) {
    
        Node newNode = new Node(value);
        
        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        }
        
        else {
            newNode.Next = _head; 
            _head.Prev = newNode; 
            _head = newNode; 
        }
    }

    
    public void InsertTail(int value) {
        
        Node newNode = new Node(value);

        if (_tail is null) {
            _head = newNode;
            _tail = newNode;
        }
        
        else {
            _tail.Next = newNode; 
            newNode.Prev = _tail; 
            _tail = newNode; 
        }
    }


    public void RemoveHead() {
        
        if (_head == _tail) {
            _head = null;
            _tail = null;
        }
        
        else if (_head is not null) {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    public void RemoveTail() {

        if (_tail == _head) {
            _head = null;
            _tail = null;
        }
        
        else if (_tail is not null) {
            _tail.Prev!.Next = null; 
            _tail = _tail.Prev;  
        }
    }

    public void InsertAfter(int value, int newValue) {
        
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                
                if (curr == _tail) {
                    InsertTail(newValue);
                }
                
                else {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; 
                    newNode.Next = curr.Next; 
                    curr.Next!.Prev = newNode; 
                    curr.Next = newNode; 
                }

                return; 
            }

            curr = curr.Next; 
        }
    }

    
    public void Remove(int value) {
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                
                if (curr == _head) {
                    RemoveHead();
                }
                else if (curr == _tail) {
                    RemoveTail();
                }
                
                else {
                    curr.Prev!.Next = curr.Next; 
                    curr.Next!.Prev = curr.Prev; 
                    
                }

                return; 
            }

            curr = curr.Next; 
        }
        
        
    }

   
    public void Replace(int oldValue, int newValue) {

        Node? curr = _head;
    
        while (curr is not null) {
            if (curr.Data == oldValue) {
                curr.Data = newValue; 
            }

            curr = curr.Next; 
    }
        
    }

    
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return this.GetEnumerator();
    }

        public IEnumerator<int> GetEnumerator() {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null) {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    
    public IEnumerable Reverse() {
        
        var curr = _tail; 
        while (curr is not null) {
            yield return curr.Data; 
            curr = curr.Prev; 
    }
    }

    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull() {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull() {
        return _head is not null && _tail is not null;
    }
}