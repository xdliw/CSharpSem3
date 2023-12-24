using System.Collections;
using System.Linq.Expressions;
using G253505_Kryshalovich_Lab2.Interfaces;

namespace G253505_Kryshalovich_Lab2.Collections;
using MyCustomCollectionStuff;

public class MyCustomCollection<T> : ICustomCollection<T> , IEnumerable<T>, IEnumerator<T>
{
    
//private classes
    private class Node
    {
        public T? Data { get; set; }
        public Node? Prev { get; set; }
        
        public Node? Next { get; set; }
    }
    
    
//data

    private Node? _head;
    private Node? _tail;
    private Node? _current;
    public int Count { get; private set; } 



//methods



    //foreach
    IEnumerator IEnumerable.GetEnumerator() => this;
    public IEnumerator<T> GetEnumerator() => this;
    
    
    public void Reset() => _current = _head;
        
    public bool MoveNext()
    {
        if (_current == null) _current = _head; //its a simple spell but quite unbreakable. i hope
        else _current = _current?.Next;
        return _current != null;
    }
        
    object IEnumerator.Current => _current.Data;
    T IEnumerator<T>.Current => _current.Data;
        
        
    public void Dispose()
    {
        // throw new NotImplementedException(); //не буду вызывать
    }

    


    //not foreach
    
    public T this[int index]
    {

        get
        {
            if (index < 0 || index >= Count) 
                throw new IndexOutOfRangeException();

            var iter = _head;
            for (int i = 0; i < index; ++i)
            {
                iter = iter?.Next;
            }

            return iter.Data;
        }
        set
        {
            if (index < 0 || index >= Count) 
                throw new IndexOutOfRangeException();

            var iter = _head;
            for (int i = 0; i < index; ++i)
            {
                iter = iter?.Next;
            }

            iter.Data = value;
        }
    }



    public void Push_back(T item)
    {
        var temp = new Node()
        {
            Data = item,
            Prev = _tail,
            Next = null
        };

        _tail = temp;
        if (_tail.Prev == null)
        {
            _head = _tail;
        }
        else
        {
            _tail.Prev.Next = _tail;
        }
        
        Count++;
    }

    public void Push_front(T item)
    {
        var temp = new Node
        {
            Data = item,
            Prev = null,
            Next = _head
        };

        _head = temp;
        if (_head.Next == null)
        {
            _tail = _head;
        }
        else
        {
            _head.Next.Prev = _head;
        }
        
        Count++;
    }

    //deletes all instances of item
    public void Remove(T item)
    {
        var iter = _head;
        var ok = false;
        while (iter != null)
        {
            var del = iter;
            iter = iter.Next;
            if (del.Data!.Equals(item))
            {
                RemoveCurrent(del);
                ok = true;
            }
        }

        if (!ok)
            throw new NoItemInCollectionException();
    }

    private void RemoveCurrent(Node? node)
    {
        var left = node?.Prev;
        var right = node?.Next;

        if(left != null) left.Next = right;
        if(right != null) right.Prev = left;

        if (node == _head) _head = right;
        if (node == _tail) _tail = left;
        
        Count--;
    }

    //
    // private T RemoveCurrent()
    // { 
    //     RemoveCurrent(_current);
    //     
    //     return _current.Data;
    // }
    //
    
}