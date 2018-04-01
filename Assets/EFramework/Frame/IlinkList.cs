namespace U3DEventFrame
{
    using System;
    using UnityEngine;

    public class IlinkList<T>
    {
        private LinkNode<T> head;

        public IlinkList()
        {
            this.head = null;
        }

        public IlinkList(T obj)
        {
            this.head = new LinkNode<T>(obj);
        }

        public void Append(T obj)
        {
            if (this.head == null)
            {
                this.head = new LinkNode<T>(obj);
                Debug.Log("11==" + obj.ToString());
            }
            else if (this.head.Next == null)
            {
                this.head.Next = new LinkNode<T>(obj);
                Debug.Log("22=" + obj.ToString());
            }
            else
            {
                LinkNode<T> head = this.head;
                while (head.Next != null)
                {
                    head = head.Next;
                }
                head.Next = new LinkNode<T>(obj);
            }
        }

        public void Clear()
        {
            if (!this.IsEmpty())
            {
                this.head = null;
            }
        }

        public virtual void Dispose()
        {
            if (!this.IsEmpty())
            {
                LinkNode<T> head = this.head;
                while (head.Next != null)
                {
                    LinkNode<T> next = head.Next;
                    head = head.Next;
                    next.Dispose();
                }
                if (this.head != null)
                {
                    this.head.Dispose();
                }
            }
        }

        public T GetElemAt(int i)
        {
            if (!this.IsEmpty())
            {
                int num = 0;
                LinkNode<T> head = new LinkNode<T>();
                head = this.head;
                while ((head.Next != null) && (num < i))
                {
                    head = head.Next;
                    num++;
                }
                if (num == i)
                {
                    return head.Data;
                }
            }
            return default(T);
        }

        public int GetLenght()
        {
            if (this.IsEmpty())
            {
                return -1;
            }
            int num = 0;
            LinkNode<T> head = new LinkNode<T>();
            head = this.head;
            while (head.Next != null)
            {
                head = head.Next;
                num++;
            }
            return (num + 1);
        }

        public void Insert(T obj, int i)
        {
            if (!this.IsEmpty())
            {
                int lenght = this.GetLenght();
                if ((i < 0) || (i >= (lenght - 1)))
                {
                    Debug.Log("position error");
                }
                else
                {
                    int num2 = 0;
                    LinkNode<T> head = new LinkNode<T>();
                    LinkNode<T> node2 = new LinkNode<T>(obj);
                    head = this.head;
                    do
                    {
                        if (i == num2)
                        {
                            node2.Next = head.Next;
                            head.Next = node2;
                            break;
                        }
                        num2++;
                        head = head.Next;
                    }
                    while ((head.Next != null) && (num2 < (lenght - 1)));
                }
            }
        }

        public bool IsEmpty()
        {
            return (this.head == null);
        }

        public int Locate(T value)
        {
            if (this.IsEmpty())
            {
                return -1;
            }
            int num = 0;
            LinkNode<T> head = new LinkNode<T>();
            head = this.head;
            while (!head.Data.Equals(value) && (head.Next != null))
            {
                head = head.Next;
                num++;
            }
            return num;
        }

        public void Remove(int i)
        {
            if (!this.IsEmpty())
            {
                int lenght = this.GetLenght();
                if ((i < 0) || (i > (lenght - 1)))
                {
                    Debug.Log("error point");
                }
                else
                {
                    LinkNode<T> head = new LinkNode<T>();
                    head = this.head;
                    if (i == 0)
                    {
                        this.head = this.head.Next;
                    }
                    else
                    {
                        int num2;
                        if (i == (lenght - 1))
                        {
                            for (num2 = 0; num2 < (lenght - 1); num2++)
                            {
                                head = head.Next;
                            }
                            head.Next = null;
                        }
                        else
                        {
                            for (num2 = 1; num2 < (lenght - 1); num2++)
                            {
                                if (num2 == i)
                                {
                                    head.Next = head.Next.Next;
                                    break;
                                }
                                head = head.Next;
                            }
                        }
                    }
                }
            }
        }

        public void ShowMe()
        {
            if (!this.IsEmpty())
            {
                int num = 0;
                LinkNode<T> head = new LinkNode<T>();
                head = this.head;
                while (head.Next != null)
                {
                    Debug.Log(head.Data);
                    head = head.Next;
                    num++;
                }
            }
        }

        public LinkNode<T> Head
        {
            get
            {
                return this.head;
            }
            set
            {
                this.head = value;
            }
        }
    }
}

