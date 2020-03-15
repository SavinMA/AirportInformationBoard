using System;
using System.Collections.Generic;
using System.Text;

namespace AirportInformationBoard.Utils
{
    public static class Serializator<T>
    {    
        ///Сериализация объекта в строку
        static public string SerializeToString(T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, typeof(T), new Newtonsoft.Json.JsonSerializerSettings
            {
                MetadataPropertyHandling = Newtonsoft.Json.MetadataPropertyHandling.ReadAhead,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });
        }

        ///Десериализация объекта из строки
        static public T DeSerializeFromString(string buffer)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(buffer, new Newtonsoft.Json.JsonSerializerSettings
            {
                MetadataPropertyHandling = Newtonsoft.Json.MetadataPropertyHandling.ReadAhead,
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto
            });
        }
    }
}
