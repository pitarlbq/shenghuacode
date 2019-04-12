
using System;

namespace Foresight.DataAccess.Framework
{
    interface ISavable
    {
        void Save();
        void Save(SqlHelper helper);
    }
}
