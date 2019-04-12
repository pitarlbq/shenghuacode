
using System;
using System.Collections.Generic;
using System.Text;

namespace Foresight.DataAccess.Framework
{
    public class EntityFinder : System.Collections.Specialized.NameObjectCollectionBase
    {
        public void Add(string propertyName, object propertyValue)
        {
            this.BaseAdd(propertyName, propertyValue);
        }

        public string GetKey(int index)
        {
            return base.BaseGetKey(index);
        }

        public object GetValue(int index)
        {
            return base.BaseGet(index);
        }
    }
}
