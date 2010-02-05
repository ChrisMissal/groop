using System;
using System.Collections.Generic;

namespace Groop.Data
{
    public interface IXmlRepository
    {
        event EventHandler ItemAddedEventHandler;
        event EventHandler ItemUpdatedEventHandler;
        event EventHandler DataChangedEventHandler;
        T Get<T>(int id) where T : class;
        IList<T> GetAll<T>() where T : class;
        void Add<T>(T obj, Action<T, int> setAction) where T : class;
        void Update<T>(T obj, int id) where T : class;
    }
}