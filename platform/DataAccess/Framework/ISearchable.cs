
using System;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Interface.  Used by base classes to read entity information
    /// </summary>
    public interface ISearchable
    {
        EntityBaseReadOnly GetEntityById(string uniqueIdentifier);
    }
}
