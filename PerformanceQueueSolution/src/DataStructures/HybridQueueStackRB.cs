using System;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Yaklaşım-> HybridQueueStackRB: SortedDictionary (red–black tree tabanlı) kullanılarak oluşturulan yapı.
    /// Çakışmalar altında en kötü durumda O(log n) performans sunar.
    /// </summary>
    public class HybridQueueStackRB<TKey, TValue> where TKey : IComparable<TKey>
    {
        public string Name { get; }
        private SortedDictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> sortedDict;
        private LinkedList<KeyValuePair<TKey, TValue>> list;

        public HybridQueueStackRB(string name)
        {
            Name = name;
            sortedDict = new SortedDictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
            list = new LinkedList<KeyValuePair<TKey, TValue>>();
        }

        public void Add(TKey key, TValue value)
        {
            if (sortedDict.ContainsKey(key))
                throw new ArgumentException("Key already exists.");
            var node = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            list.AddLast(node);
            sortedDict.Add(key, node);
        }

        public TValue Dequeue()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Queue empty");
            var node = list.First;
            list.RemoveFirst();
            sortedDict.Remove(node.Value.Key);
            return node.Value.Value;
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }
    }
}