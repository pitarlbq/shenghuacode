using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Foresight.DataAccess.Framework;

namespace Foresight.DataAccess
{
	/// <summary>
	/// This object represents the properties and methods of a ProjectOrderNumber.
	/// </summary>
	public partial class ProjectOrderNumber : EntityBase
	{
        public static void DeleteProjectOrderNumberOrderNumberID(int OrderNumberID)
        {
            using (SqlHelper helper = new SqlHelper())
            {
                try
                {
                    helper.BeginTransaction();
                    string commandText = @"
DELETE FROM [dbo].[ProjectOrderNumber]
WHERE [OrderNumberID] = @OrderNumberID";

                    System.Collections.Generic.List<SqlParameter> parameters = new System.Collections.Generic.List<SqlParameter>();
                    parameters.Add(new SqlParameter("@OrderNumberID", OrderNumberID));

                    helper.Execute(commandText, CommandType.Text, parameters);
                    helper.Commit();
                }
                catch
                {
                    helper.Rollback();
                    throw;
                }
            }
        }
	}
}
