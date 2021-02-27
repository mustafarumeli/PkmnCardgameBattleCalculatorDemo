using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace BattleCalculatorDemo.AbstractionLayer.Utils
{
    public static class CloneExtension
    {
        public static T DeepClone<T>(this T item) where T : IDeepCloneable
        {
            return new DeepCloneHelper<T>().DeepClone(item);
        }

        public class DeepCloneHelper<T> : IDeepClone<T>
        {
            public T DeepClone(T obj)
            {
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj, Formatting.None, jsonSerializerSettings), jsonSerializerSettings);
            }
        }


        public interface IDeepClone<T>
        {
            T DeepClone(T obj);
        }
    }

  
}