
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Read / Write List of entities
    /// </summary>
    /// <typeparam name="T">EntityBaseReadOnly type</typeparam>
    public partial class EntityList<T> : EntityListReadOnly<T> where T : EntityBaseReadOnly
    {

	}
}