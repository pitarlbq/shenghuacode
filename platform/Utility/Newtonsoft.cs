using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class JsonConvert
    {
        public static string SerializeObject(object value)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }
        public static T DeserializeObject<T>(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }
    }
}
