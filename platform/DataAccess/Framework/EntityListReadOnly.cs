
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Read List of entities
    /// </summary>
    /// <typeparam name="T">EntityBaseReadOnly type</typeparam>
    public partial class EntityListReadOnly<T> : EntityListBase<T> where T : EntityBaseReadOnly
    {

	}
}
