namespace U3DEventFrame
{
    using System;

    public class LinkNode<T>
    {
        private T data;
        private LinkNode<T> next;

        public LinkNode()
        {
            this.data = default(T);
            this.next = null;
        }

        public LinkNode(T obj)
        {
            this.data = obj;
            this.next = null;
        }

        public LinkNode(T obj, LinkNode<T> pNext)
        {
            this.data = obj;
            this.next = pNext;
        }

        public void Dispose()
        {
            this.data = default(T);
            this.next = null;
        }

        public T Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public LinkNode<T> Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }
    }
}

