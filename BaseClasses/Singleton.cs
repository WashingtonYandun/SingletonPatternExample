using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExample.BaseClasses
{
    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> instance = new Lazy<T>(
            () => CreateInstance()
            );

        public static T Instance => instance.Value;

        protected Singleton()
        {
        }

        private static T CreateInstance()
        {
            return Activator.CreateInstance(typeof(T), nonPublic: true) as T;
        }
    }

}
