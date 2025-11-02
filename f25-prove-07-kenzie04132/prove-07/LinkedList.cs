using System.Collections;

namespace prove_07;

/// <summary>
/// Implements a basic doubly linked list of integers
/// </summary>
public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Adds a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void AddFirst(int value)
    {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Adds a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void AddLast(int value)
    {
        // Creates new node
        Node newNode = new Node(value);
        
        // If is empty, head and tail are effected
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If list is not empty, only tail changes 
        else
        {
            newNode.Prev = _tail; 
            _tail!.Next = newNode; 
            _tail = newNode; 
        }
    }

    /// <summary>
    /// Removes the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveFirst()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  It's okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Removes the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveLast()
    {
        // If list has one item/is empty, head and tail = null
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If list has more than one item, only tail changes 
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null;
            _tail = _tail.Prev; 
        }
    }

    /// <summary>
    /// Adds 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void AddAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    AddLast(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Removes the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // Removes head
                if (curr == _head)
                {
                    RemoveFirst();
                }
                // Removes tail
                else if (curr == _tail)
                {
                    RemoveLast();
                }
                // If what needs to be removed is in the middle
                else
                {
                    // Reconnect the previous node to the next node
                    curr.Prev!.Next = curr.Next;
                    // Reconnect the next node to the previous node
                    curr.Next!.Prev = curr.Prev;
                }
                
                return;
            }

            curr = curr.Next; // Go to next node to search for 'value'
        }
    }

    /// <summary>
    /// Searches for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == oldValue)
            {
                curr.Data = newValue; // Replace the value
            }

            curr = curr.Next; // Continue to next node to find ALL matches
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        var curr = _tail; // Starts at the end
        while (curr is not null)
        {
            yield return curr.Data; // Yield each item to user
            curr = curr.Prev; // Goes backward in list 
        }
    }

    public override string ToString()
    {
        return "<LinkedList>[" + string.Join(", ", this) + "]";
    }
}