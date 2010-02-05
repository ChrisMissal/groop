using System;

namespace Groop.Data
{
    public abstract class XmlRepositoryEventArgs<T> : EventArgs
    {
        public readonly T Item;

        protected XmlRepositoryEventArgs(T item)
        {
            Item = item;
        }

        public virtual Type Type { get { return typeof (T); } }
    }
}