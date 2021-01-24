using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public static class MyCodeSchool
    {
        public static void MyLinkedListOperation()
        {
            var ne = new LinkedList();
            ne.addFirst(24);
            ne.addFirst(25);
            ne.addFirst(26);
            ne.addFirst(27);
            ne.addFirst(28);
            ne.InsterAt(10, 4);
            ne.InsterAt(10, 1);
            ne.DeleteAt(2);

            var ll = new LinkedList<int>();
            ll.AddFirst(10);
            ll.AddFirst(12);
            ll.AddFirst(16);
            ll.AddLast(11);
            ll.AddLast(13);
            ll.AddLast(15);
            //var n = new LinkedListNode<int>(19);
            //ll.Intersect(n,13);

            var mll = new MyLinkedList<int>();
            mll.AddFirst(10);
            mll.AddFirst(12);
            mll.AddFirst(16);
            mll.AddLast(11);
            mll.AddLast(13);
            mll.AddLast(15);
            mll.InsertAt(19, 2);
            mll.InsertAt(18, 5);
            mll.DeleteFirst();
            mll.DeleteLast();
            mll.DeleteAt(2);
            mll.DeleteAt(1);
        }


        #region Creating list usig Array
        public static void ListArrayOperations()
        {
            var list1 = new ListTypeArray<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(1);
            list1.Add(2);
            list1.Add(1);
            var cnt1 = list1.Count;
            list1.Remove(1);
            var list2 = new ListTypeArray<string>();
            list2.Add("1");
            list2.Add("2");
            list2.Add("1");
            list2.Add("2");
            list2.Add("1");
            list2.Remove("1");
            var cnt2 = list2.Count;

        }
        #endregion
    }
    public class Node
    {
        public Node next;
        public Object data;
    }
    public class MyLinkedList<T>
    {
        public Node head;
        public void AddFirst(T data)
        {
            Node toAdd = new Node();
            toAdd.data = data;
            toAdd.next = head;
            head = toAdd;
        }

        public void AddLast(T data)
        {
            if (head == null)
            {
                Node toAdd = new Node();
                toAdd.data = data;
                head.next = toAdd;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }
        }

        public void InsertAt(T data, int pos)
        {
            Node node = new Node();
            node.data = data;
            Node temp = head;

            if (pos == 1)
            {
                head.next = node;
                return;
            }

            for (int i = 0; i < pos - 1; i++)
            {
                temp = temp.next;
            }
            node.next = temp.next;
            temp.next = node;

        }

        public void DeleteFirst()
        {
            Node node = new Node();
            node = head.next;
            head = node;
        }
        public void DeleteLast()
        {
            Node node = new Node();
            node = head;
            while (node.next != null)
            {
                if (node.next.next == null)
                {
                    node.next = null;
                    break;
                }
                node = node.next;
            }
        }

        public void DeleteAt(int pos)
        {
            Node node = head;
            if (pos == 1)
            {
                node = node.next.next;
            }

            for (int i = 0; i < pos - 2; i++)
            {
                node = node.next;
            }
            Node tnode = node.next.next;
            node.next = tnode;
        }
    }

    public class ListTypeArray<T>
    {
        public int Count { get; private set; }
        T[] arr = new T[2];

        public void Add(T item)//O(n)
        {
            if (arr.Length == Count)
            {
                var temp = new T[2 * arr.Length];
                Array.Copy(arr, temp, arr.Length);

                arr = temp;
            }
            arr[Count] = item;
            Count++;
        }

        public void Remove(T item) //O(n)
        {
            bool flag = false;
            int i;
            for (i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != null && arr[i].Equals(item) || flag)
                {
                    arr[i] = arr[i + 1];
                    flag = true;
                }
            }
            Count--;
            arr[i] = typeof(T).IsValueType ? (dynamic)(-1) : (dynamic)("-1");
        }
    }

    public class LinkedList
    {
        public Node head { get; set; }
        public int count { get; }

        public void addFirst(int data)
        {
            var newNode = new Node();
            newNode.data = data;
            var temp = head;
            newNode.next = temp;
            head = newNode;
        }

        public void InsterAt(int data, int pos)
        {
            var newNode = new Node();
            newNode.data = data;
            var temp = head;
            if (pos == 1)
            {
                newNode.next = temp;
                head = newNode;
                return;
            }
            for (int i = 0; i < pos - 2; i++)
            {
                temp = temp.next;
            }
            newNode.next = temp.next;
            temp.next = newNode;
        }

        public void DeleteAt(int pos)
        {
            Node temp = head;
            for (int i = 0; i < pos - 2; i++)
            {
                temp = temp.next;
            }
            temp.next = temp.next.next;
        }
    }
}
