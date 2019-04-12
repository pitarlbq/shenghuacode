using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace Encript
{
    public class SqlLite
    {
        #region Publish Static Methods

        public static CompanyModel GetMyCompany(string BaseURL, int CompanyID)
        {
            CompanyModel[] results = GetCompanyList();
            var my_company = results.FirstOrDefault(p => p.BaseURL.Equals(BaseURL) && p.CompanyID == CompanyID);
            return my_company;
        }
        public static CompanyModel[] GetCompanyList()
        {
            List<CompanyModel> results = new List<CompanyModel>();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from Company;";
                    System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(ReadCompanyData(reader));
                    }
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Encript.SqlLite", "GetCompanyList", ex);
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return results.ToArray();
        }
        public static void SaveCompany(CompanyModel data)
        {
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "update Company set CompanyName=@CompanyName,IsActive=@IsActive,BaseURL=@BaseURL,UserCount=@UserCount,ServerStartTime=@ServerStartTime,ServerEndTime=@ServerEndTime,IsPay=@IsPay,IsAdmin=@IsAdmin,IsCustomer=@IsCustomer,Login_LogImg=@Login_LogImg,Login_BodyImg=@Login_BodyImg,Home_LogoImg=@Home_LogoImg,VersionCode=@VersionCode where CompanyID=@CompanyID;";
                    cmd.Parameters.Add("CompanyID", DbType.Int32).Value = data.CompanyID;
                    cmd.Parameters.Add("CompanyName", DbType.String).Value = data.CompanyName;
                    cmd.Parameters.Add("IsActive", DbType.Boolean).Value = data.IsActive;
                    cmd.Parameters.Add("BaseURL", DbType.String).Value = data.BaseURL;
                    cmd.Parameters.Add("UserCount", DbType.Int32).Value = data.UserCount;
                    cmd.Parameters.Add("ServerStartTime", DbType.DateTime).Value = data.ServerStartTime;
                    cmd.Parameters.Add("ServerEndTime", DbType.DateTime).Value = data.ServerEndTime;
                    cmd.Parameters.Add("IsPay", DbType.Boolean).Value = data.IsPay;
                    cmd.Parameters.Add("IsAdmin", DbType.Boolean).Value = data.IsAdmin;
                    cmd.Parameters.Add("IsCustomer", DbType.Boolean).Value = data.IsCustomer;
                    cmd.Parameters.Add("Login_LogImg", DbType.String).Value = data.Login_LogImg;
                    cmd.Parameters.Add("Login_BodyImg", DbType.String).Value = data.Login_BodyImg;
                    cmd.Parameters.Add("Home_LogoImg", DbType.String).Value = data.Home_LogoImg;
                    cmd.Parameters.Add("VersionCode", DbType.Int32).Value = data.VersionCode;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Encript.SqlLite", "SaveCompany", ex);
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static void InsertCompany(CompanyModel data)
        {
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Company (CompanyID, CompanyName, IsActive,BaseURL,UserCount,ServerStartTime,ServerEndTime,IsPay,IsAdmin,IsCustomer,Login_LogImg,Login_BodyImg,Home_LogoImg,VersionCode) VALUES (@CompanyID,@CompanyName,@IsActive,@BaseURL,@UserCount,@ServerStartTime,@ServerEndTime,@IsPay,@IsAdmin,@IsCustomer,@Login_LogImg,@Login_BodyImg,@Home_LogoImg,@VersionCode);";
                    cmd.Parameters.Add("CompanyID", DbType.Int32).Value = data.CompanyID;
                    cmd.Parameters.Add("CompanyName", DbType.String).Value = data.CompanyName;
                    cmd.Parameters.Add("IsActive", DbType.Boolean).Value = data.IsActive;
                    cmd.Parameters.Add("BaseURL", DbType.String).Value = data.BaseURL;
                    cmd.Parameters.Add("UserCount", DbType.Int32).Value = data.UserCount;
                    cmd.Parameters.Add("ServerStartTime", DbType.DateTime).Value = data.ServerStartTime;
                    cmd.Parameters.Add("ServerEndTime", DbType.DateTime).Value = data.ServerEndTime;
                    cmd.Parameters.Add("IsPay", DbType.Boolean).Value = data.IsPay;
                    cmd.Parameters.Add("IsAdmin", DbType.Boolean).Value = data.IsAdmin;
                    cmd.Parameters.Add("IsCustomer", DbType.Boolean).Value = data.IsCustomer;
                    cmd.Parameters.Add("Login_LogImg", DbType.String).Value = data.Login_LogImg;
                    cmd.Parameters.Add("Login_BodyImg", DbType.String).Value = data.Login_BodyImg;
                    cmd.Parameters.Add("Home_LogoImg", DbType.String).Value = data.Home_LogoImg;
                    cmd.Parameters.Add("VersionCode", DbType.Int32).Value = data.VersionCode;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Encript.SqlLite", "InsertCompany", ex);
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static void InsertCompanyModule(CompanyModuleModel[] data, int CompanyID)
        {
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    //string cmdtext = "delete from CompanyModule where CompanyID=" + CompanyID + ";";
                    string cmdtext = string.Empty;
                    foreach (var item in data)
                    {
                        cmdtext += "INSERT INTO CompanyModule (CompanyID, ModuleID) VALUES (" + CompanyID.ToString() + "," + item.ModuleID.ToString() + ");";
                    }
                    cmd.CommandText = cmdtext;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Encript.SqlLite", "InsertCompanyModule", ex);
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static void DeleteCompany()
        {
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from CompanyModule;delete from Company";
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Encript.SqlLite", "DeleteCompany", ex);
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static CompanyModuleModel[] GetCompanyModuleList(CompanyModel data)
        {
            List<CompanyModuleModel> results = new List<CompanyModuleModel>();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from CompanyModule where CompanyID=@CompanyID;";
                    cmd.Parameters.Add("CompanyID", DbType.Int32).Value = data.CompanyID;
                    System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(ReadCompanyModuleData(reader));
                    }
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Encript.SqlLite", "DeleteCompany", ex);
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return results.ToArray();
        }
        #endregion
        #region Private Static Methods
        private static SQLiteConnection GetConnection()
        {
            SQLiteConnection conn = null;
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            string password = Utility.Tools.Md5Hash("yongyou_saasyy_!2017");
            string dbFile = path + @"html\mysqllite.db";
            string dbPath = Path.GetDirectoryName(dbFile);
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }
            if (!File.Exists(dbFile))
            {
                try
                {
                    //数据库不存在，则创建
                    SQLiteConnection.CreateFile(dbFile);
                    conn = new SQLiteConnection(string.Format("Data Source={0};Pooling=true;FailIfMissing=false", dbFile));
                    conn.Open();
                    conn.ChangePassword(password);
                    InititalTable(conn);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Utility.LogHelper.WriteError("Encript.SqlLite", "GetConnection.CreateFile", ex);
                }
                finally
                {
                    if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return conn;
            }
            try
            {
                conn = new SQLiteConnection(string.Format("Data Source={0};Pooling=true;FailIfMissing=false", dbFile));
                conn.SetPassword(password);
                conn.Open();
                conn.ChangePassword(password);
                conn.Close();
            }
            catch (Exception ex)
            {
                Utility.LogHelper.WriteError("Encript.SqlLite", "GetConnection.ExistFile", ex);
                conn = new SQLiteConnection(string.Format("Data Source={0};Pooling=true;FailIfMissing=false", dbFile));
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return conn;
        }
        private static void InititalTable(SQLiteConnection conn)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = conn;
            string cmdText = @"CREATE TABLE IF NOT EXISTS CompanyModule(ID INTEGER PRIMARY KEY AUTOINCREMENT,CompanyID INTEGER, ModuleID INTEGER);";
            cmdText += @"CREATE TABLE IF NOT EXISTS Company(ID INTEGER PRIMARY KEY AUTOINCREMENT, CompanyID INTEGER NOT NULL, CompanyName VARCHAR(200), IsActive BOOLEAN, BaseURL VARCHAR(200), UserCount INTEGER, ServerStartTime DATETIME, ServerEndTime  DATETIME, IsPay  BOOLEAN, IsAdmin  BOOLEAN, IsCustomer  BOOLEAN, Login_LogImg  VARCHAR(500), Login_BodyImg VARCHAR(500), Home_LogoImg  VARCHAR(500), VersionCode  INTEGER);";
            cmd.CommandText = cmdText;
            cmd.ExecuteNonQuery();
        }
        private static CompanyModuleModel ReadCompanyModuleData(System.Data.SQLite.SQLiteDataReader reader)
        {
            CompanyModuleModel item = new CompanyModuleModel();
            item.ID = GetInt(reader["ID"]);
            item.CompanyID = GetInt(reader["CompanyID"]);
            item.ModuleID = GetInt(reader["ModuleID"]);
            return item;
        }
        private static CompanyModel ReadCompanyData(System.Data.SQLite.SQLiteDataReader reader)
        {
            CompanyModel item = new CompanyModel();
            item.ID = GetInt(reader["ID"]);
            item.CompanyID = GetInt(reader["CompanyID"]);
            item.CompanyName = GetString(reader["CompanyName"]);
            item.IsActive = GetBool(reader["IsActive"]);
            item.BaseURL = GetString(reader["BaseURL"]);
            item.UserCount = GetInt(reader["UserCount"]);
            item.ServerStartTime = GetTime(reader["ServerStartTime"]);
            item.ServerEndTime = GetTime(reader["ServerEndTime"]);
            item.IsPay = GetBool(reader["IsPay"]);
            item.IsAdmin = GetBool(reader["IsAdmin"]);
            item.IsCustomer = GetBool(reader["IsCustomer"]);
            item.Login_LogImg = GetString(reader["Login_LogImg"]);
            item.Login_BodyImg = GetString(reader["Login_BodyImg"]);
            item.Home_LogoImg = GetString(reader["Home_LogoImg"]);
            item.VersionCode = GetInt(reader["VersionCode"]);
            return item;
        }
        private static string GetString(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            else if (obj is DBNull)
            {
                return null;
            }
            return obj.ToString();
        }
        private static int GetInt(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else if (obj is DBNull)
            {
                return 0;
            }
            return Convert.ToInt32(obj);
        }
        private static DateTime GetTime(object obj)
        {
            if (obj == null)
            {
                return DateTime.MinValue;
            }
            else if (obj is DBNull)
            {
                return DateTime.MinValue;
            }
            return Convert.ToDateTime(obj);
        }
        private static bool GetBool(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is DBNull)
            {
                return false;
            }
            return bool.Parse(obj.ToString());
        }
        #endregion
    }
}
