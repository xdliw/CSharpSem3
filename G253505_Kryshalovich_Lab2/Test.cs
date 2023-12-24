using System.Collections.Specialized;

using static G253505_Kryshalovich_Lab2.Utility;

using System.Collections;

namespace Test;

class MyCustomCollection<T> :  IEnumerator<T>, IEnumerable<T>
{
    private class Node
    {
        public T? Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }
        public Node(T? data,
                    Node? prev = null,
                    Node? next = null)
        {
            Data = data;
            Prev = prev;
            Next = next;
        }
    }

    private Node _head;
    private Node _tail;
    private Node _current;
    private int _count = 0;
    public T this[int index]
    {
        get => FindNode(index).Data!;
        set => FindNode(index).Data = value;
    }

    public int Count => _count;

    T IEnumerator<T>.Current => Current();

    object IEnumerator.Current => Current()!;

    public MyCustomCollection()
    {
        _head = new Node(default);
        _tail = _head;
        _current = _head;
    }

    public void Add(T item)
    {
        if (_tail == _head)
        {
            _head.Next = new Node(item, _head);
            _tail = _head.Next;
        }
        else
        {
            _tail.Next = new Node(item, _tail);
            _tail = _tail.Next;
        }
        ++_count;
    }

    public T Current()
    {
        CheckCurrent();
        return _current.Data!;
    }
    public int CountOfElements(Predicate<T> func)
    {
        Node? cur = _head.Next;
        int count = 0;
        while (cur is not null)
        {
            if (func(cur.Data!))
                ++count;
            cur = cur.Next;
        }
        return count;
    }
    private void CheckCurrent()
    {
        if (_current == _head)
            throw new IndexOutOfRangeException();
    }

    public void Remove(T item)
    {
        Node? findItem = FindNode(item);
        if (findItem is not null)
        {
            Node? saveCurrent = _current;
            _current = findItem;
            RemoveCurrent();
            if (findItem != saveCurrent)
                _current = saveCurrent;
        }
        else
        {
            // throw new NotFoundItemInCollection("Элемент не найден");
        }
    }

    public T RemoveCurrent()
    {
        CheckCurrent();
        T data = _current!.Data!;

        _current.Prev!.Next = _current.Next;
        if (_current.Next is not null)
            _current.Next.Prev = _current.Prev;
        else
            _tail = _current.Prev;

        _current = _current.Next ?? _current.Prev;
        --_count;
        return data;
    }
    public T? Find(Predicate<T> func)
    {
        Node? cur = _head.Next;
        while (cur is not null)
        {
            if (func(cur.Data!))
                return cur.Data;
            cur = cur.Next;
        }
        return default;
    }
    
    public void Reset() => _current = _head;

    private Node FindNode(int index)
    {
        if (index >= _count || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index < _count / 2)
        {
            Node findNode = _head.Next!;
            for (int i = 0; i < index; ++i)
            {
                findNode = findNode.Next!;
            }
            return findNode;
        }
        else
        {
            Node findNode = _tail;
            for (int i = _count - 1; i > index; --i)
            {
                findNode = findNode.Prev!;
            }
            return findNode;
        }
    }

    private Node? FindNode(T item)
    {
        Node? findItem = null;
        Node? cur = _head.Next;
        Comparer<T> comparer = Comparer<T>.Default;
        while (cur is not null && findItem is null)
        {
            if (comparer.Compare(item, cur.Data) == 0)
            {
                findItem = cur;
            }
            cur = cur.Next;
        }

        return findItem;
    }

    public bool MoveNext()
    {
        bool again = _current.Next is not null;
        if (again)
            _current = _current.Next!;
        else
            Reset();
        return again;
    }

    public void Dispose() { }

    public IEnumerator<T> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this;
    }
}

public class Test
{
    
    private delegate void PrintSome(string s);
    static event Action<string> DoIt;
    
    

    public static void Execute()
    {
        var c = new MyCustomCollection<int>();
        c.Add(1);
        c.Add(2);
        c.Add(3);

        foreach (var q in c)
        {
            Cout(q.ToString());
        }
    }
    

}