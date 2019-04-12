
using System;

namespace Foresight.DataAccess.Framework
{
	/// <summary>
	/// A custom attribute used to identify the database column name of a property of a custom business object.
	/// </summary>
	public class DatabaseColumnAttribute : Attribute
	{
		public DatabaseColumnAttribute(string name)
		{
			_name = name;
		}
		
		public DatabaseColumnAttribute()
		{
			
		}

		private string _name = string.Empty;
        /// <summary>
        /// The database column name
        /// </summary>
		public string Name
		{
			get { return _name; }
		}
	}
}
