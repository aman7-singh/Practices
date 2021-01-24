using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class Node<T>
    {
        public T data;
        public Node(T data)
        {
            this.data = data;
        }
    }
    public class HashNodeMap<T>
    {
        public int key;
        public Node<T> data;
        public HashNodeMap<T> next;
    }

    public class StringMap<TValue> : IStringMap<TValue> where TValue : class
    {
        public HashNodeMap<TValue> hashNode = null;
        /// <summary> Returns number of elements in a map</summary>
        public int Count { get; set; }

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        // Do not change this property
        public TValue DefaultValue { get; set; }

        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in a map, then the value associated with this key should be overriden.
        /// </summary>
        /// <returns>true if the value for the key was overriden otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        public bool AddElement(string key, TValue value)
        {
            try
            {
                HashNodeMap<TValue> current = null;
                if (hashNode == null)
                {
                    hashNode = CreateNode(key, value);
                }
                else
                {
                    current = hashNode;
                    while (current.next != null)
                    {
                        current = current.next;
                    }
                    current.next = CreateNode(key, value);
                }
                Count++;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        public bool RemoveElement(string key)
        {
            try
            {
                Node<TValue> data = new Node<TValue>(DefaultValue);
                int hashCode = key.GetHashCode();
                HashNodeMap<TValue> current = hashNode;
                bool flag = false;
                while (current != null && current.next != null)
                {
                    if (current.key == hashCode)
                    {
                        if (current.next != null)
                        {
                            current = current.next;
                            Count--;
                        }
                        else
                        {
                            current = null;
                        }
                    }
                    if (current.next != null && flag == false)
                    {
                        current = current.next;

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If a key is null</exception>
        /// <exception cref="System.ArgumentException">If a key is an empty string</exception>
        public TValue GetValue(string key)
        {
            Node<TValue> data = new Node<TValue>(DefaultValue);
            int hashCode = key.GetHashCode();
            HashNodeMap<TValue> current = hashNode;

            while (current != null)
            {
                if (current.key == hashCode)
                {
                    data = current.data;
                    break;
                }
                if (current.next != null)
                {
                    current = current.next;
                }
            }
            return data.data;
        }
        private HashNodeMap<TValue> CreateNode(string key, TValue data)
        {
            int hashCode = key.GetHashCode();
            HashNodeMap<TValue> newNodeMap = new HashNodeMap<TValue>();
            newNodeMap.data = new Node<TValue>(data);
            newNodeMap.key = hashCode;
            return newNodeMap;
        }
    }


}
