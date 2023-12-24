using System.Reflection;
using G253505_Kryshalovich_Lab1.Interfaces;

namespace G253505_Kryshalovich_Lab1.Collections;

public class MyCustomCollection<T>
{
    private class Node
    {
        public T? Data { get; set; }
        public Node? Prev { get; set; }
        
        public Node? Next { get; set; }
    }

    private Node? _head;
    private Node? _tail;
    private Node? _current;
    

        
    private T Current() 
    {
        return _current!.Data!; //т.к. это будет использоваться вроде только в foreach, то можно не проверять на null
        
        //правильно ли будет проверить на нулл и если да, то выбросить исключение?
    }

    private void Reset()
    {
        _current = _head;
    }

    private bool Next()
    {
        _current = _current?.Next;
        return _current != null;
    }

    
    public T this[int index]
    {
        get
        {
            var iter = _head;
            for (int i = 0; i < index; ++i)
            {
                iter = iter?.Next;
            }

            return iter.Data;
        }
        set
        {
            var iter = _head;
            for (int i = 0; i < index; ++i)
            {
                iter = iter?.Next;
            }

            iter.Data = value;
        }
    }

    public int Count { get; private set; }


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
            _current = _head;
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
            _current = _head;
        }
        else
        {
            _head.Next.Prev = _head;
        }
        
        Count++;
    }

    public void Remove(T item)
    {
        var iter = _head;
        while (iter != null)
        {
            var del = iter;
            iter = iter.Next;
            if(del.Data!.Equals(item)) RemoveCurrent(del);
        }
        
    }

    private void RemoveCurrent(Node? node)
    {
        var left = node?.Prev;
        var right = node?.Next;

        if(left != null) left.Next = right;
        if(right != null) right.Prev = left;

        if (node == _head) _head = right;
        if (node == _tail) _tail = left;
        if (node == _current) Next();
        
        Count--;
    }


    private T RemoveCurrent()
    { 
        RemoveCurrent(_current);
        
        return _current.Data;
    }
    
    
}