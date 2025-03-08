using System;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Yaklaşım->dynamic array based: Key-Value List.
    /// Eklemeler hızlı olabilir, ancak listenin başından silme O(n) maliyetlidir.
    /// </summary>
    public class NaiveKeyValueList
    {
        public string Name { get; }
        private List<KeyValuePair<int, string>> list;

        public NaiveKeyValueList(string name)
        {
            Name = name;
            list = new List<KeyValuePair<int, string>>();
        }

        public void Add(int key, string value)
        {
            list.Add(new KeyValuePair<int, string>(key, value));
        }

        public string Dequeue()
        {
            if (list.Count == 0)
                throw new InvalidOperationException("List empty");
            var kv = list[0];
            list.RemoveAt(0);
            return kv.Value;
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }
    }
}