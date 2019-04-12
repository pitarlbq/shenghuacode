
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// The valid validation groups
    /// </summary>
    public static partial class ValidationGroup
	{	
		public const string Required = "Required";
		public const string Length = "Length";
	}
}
