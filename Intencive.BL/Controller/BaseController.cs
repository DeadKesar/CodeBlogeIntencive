using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Intencive.BL.Controller
{
    public abstract class BaseController 
    {
        protected void Save(string fileName, object item) 
        {
           var bin = new BinaryFormatter();
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                bin.Serialize(file, item);
            }
        }
        protected T Load<T> (string fileName)
        {
            var bin = new BinaryFormatter();
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (file.Length > 1 && bin.Deserialize(file) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
