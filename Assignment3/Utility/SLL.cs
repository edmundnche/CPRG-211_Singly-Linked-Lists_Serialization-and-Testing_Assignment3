using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{

    [DataContract]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        public Node<User> Head { get; set; }

        [DataMember]
        public Node<User> Tail { get; set; }

        [DataMember]
        public int Size { get; set; }

        public SLL()
        {
            Head = Tail = null;
        }


        public void Add(User value, int index)
        {

            int returnSize = Count();


            if (index < 0 || index > returnSize - 1)
            {
                new IndexOutOfRangeException("Index is negative or larger than list size.");

            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                Node<User> temp1 = FindNode(index - 1);

                Node<User> temp2 = temp1.Next; 
                Node<User> insertedNode = new Node<User>(value); 

                temp1.Next = insertedNode; 
                insertedNode.Next = temp2; 

                Size++;

                if (insertedNode.Next == null)
                {
                    Tail = insertedNode;
                }
            }

        }

  
        public void AddFirst(User value)
        {
            Node<User> newHead = new Node<User>(value);
            newHead.Next = Head; 
            Head = newHead; 

            if (Head.Next == null)
            {
                Tail = Head;
            }

            Size++;
        }

        public void AddLast(User value)
        {
            Node<User> newLastNode = new Node<User>(value);

            if (Size == 0)
            {
                AddFirst(value);
            }
            else
            {
                Tail.Next = newLastNode;
                Tail = newLastNode;
                Size++;
            }

        }

        public void Clear()
        {
            Node<User> currentNode = Head;

            while (currentNode != null)
            {
                Node<User> nextNode = currentNode.Next;
                currentNode.Next = null;
                currentNode = nextNode;
            }

            Head = null;
            Tail = null;

            Size = 0;
        }

        public bool Contains(User value)
        {
            Node<User> currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }


        public int Count()
        {
            if (Head == null)
            {
                return 0;
            }
            return Size;
        }


        public User GetValue(int index)
        {
            Node<User> current = Head;

            if (Head == null || index >= Size || index < 0)
            {
                throw new IndexOutOfRangeException("The list is empty or the index is out of range or the index is less than 0.");
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
        }

        public Node<User> FindNode(int index)  
        {
            Node<User> node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node;
        }


        public int IndexOf(User value)
        {
            Node<User> current = Head;
            int index = 0;

            while (current != null)
            {
                if (current.Data == value)
                {
                    return index;
                }
                else
                {
                    index++;
                }
            }
            return -1;
        }


        public bool IsEmpty()
        {
            if (Head == null)
            {
                return true;
            }
            return false;
        }


        public void Remove(int index)
        {
            int returnSize = Count();

            if (index < 0 || index > returnSize - 1)
            {
                throw new IndexOutOfRangeException("Index is negative or larger than list size.");
            }
            else
            {
                if (index == 0)
                {
                    RemoveFirst();
                }
                else
                {
                    Node<User> current = FindNode(index - 1);

                    current.Next = current.Next.Next;
                    Size--;
                }

            }

        }


        public void RemoveFirst()

        {
            if (Head == null)
            {
                throw new CannotRemoveException("The list is empty");
            }
            else
            {
                Head = Head.Next;
                Size--;
            }

        }


        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new CannotRemoveException("The list is empty");

            }
            else
            {
                Node<User> current = FindNode(Size - 1);

                current.Next = null;
                Tail = current;
                Size--;
            }

        }

 
        public void Replace(User value, int index)
        {
            if (Head == null || index >= Size || index < 0)
            {
                throw new IndexOutOfRangeException("The list is empty, or the index is out of range, or the index is less than zero.");
            }
            else
            {
                Node<User> current = Head;

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }


        public User[] SLLToArray()
        {
            Node<User> toArray = Head;
            User[] array = new User[Size];

            for (int i = 0; i < Size; i++)
            {
                array[i] = toArray.Data;
                toArray = toArray.Next;
            }

            return array;
        }


        public SLL Divided(int index)
        {
            SLL newSll = new SLL(); 
            Node<User> runner = Head; 
            if ((IsEmpty()) || (index < 0 || index >= Count())) 
            {
                throw new IndexOutOfRangeException("Index is negative or larger than list size.");
            }
            else
            {
                for (int i = index; i < Count(); i++)
                {
                    newSll.AddLast(GetValue(i)); 
                }
            }
            newSll.Size = Size - index;

            for (int i = 0; i < index; i++) 
            {
                runner = runner.Next;
            }
            Tail = runner; 
            Size = index;

            return newSll;
        }


        public Node<User> ReverseLinkedList()
        {
            if (Head == null)
            {
                return null;
            }

            Node<User> currentNode = Head;
            Node<User> previousNode = null;
            Node<User> tempNext;

            while (currentNode != null)
            {
                tempNext = currentNode.Next;
                currentNode.Next = previousNode;
                previousNode = currentNode;
                currentNode = tempNext;
            }
            return previousNode;
        }


        public class CannotRemoveException : Exception
        {

            public CannotRemoveException(string message) : base(message) { }

        }
    }

}