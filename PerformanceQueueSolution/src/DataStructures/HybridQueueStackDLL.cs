using System;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// HybridQueueStackDLL: Dictionary + Doubly Linked List tabanlı yapı.
    /// Normal dağıtımda, ekleme ve silme ortalama O(1)'dir.
    /// </summary>
    public class HybridQueueStackDLL<TKey, TValue>
    {
        public string Name { get; }
        private Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> dict;
        private LinkedList<KeyValuePair<TKey, TValue>> list;

        public HybridQueueStackDLL(string name)
        {
            Name = name;
            dict = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
            list = new LinkedList<KeyValuePair<TKey, TValue>>();
        }

        public void Add(TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
                throw new ArgumentException("Key already exists.");
            var node = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            list.AddLast(node);
            dict.Add(key, node);
        }

        public TValue Dequeue()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("Queue empty");
            var node = list.First;
            list.RemoveFirst();
            dict.Remove(node.Value.Key);
            return node.Value.Value;
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }
    }
}