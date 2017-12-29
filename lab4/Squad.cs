using System;
using System.Collections;
using System.Collections.Generic;

namespace lab4
{
    public class Squad<T> : IEnumerable<T>, IEnumerator<T> where T : Unit
    {
        private readonly List<T> list;
        private int position = -1;

        public List<T> Units => list;

        public string Commander { get; set;}

        public int Count => list.Count;

        public Squad()
        {
            list = new List<T>();
            Commander = "PLAYER";
        }

        public Squad(string commander) : this()
        {
            Commander = commander;
        }

        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public T this[string name]
        {
            get { return list.Find(unit => unit.Name.Equals(name)); }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            position++;
            return (position < list.Count);
        }
        
        public void Dispose() { }

        object IEnumerator.Current => Current;

        public T Current => list[position];

        public void Reset()
        {
            position = -1;
        }

        public void Add(T member)
        {
            list.Add(member);
        }

        public void Sort()
        {
            list.Sort();
        }
    }
}