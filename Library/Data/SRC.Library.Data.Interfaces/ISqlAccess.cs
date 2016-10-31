using System;
using System.Data;
using System.Data.SqlClient;
namespace SRC.Library.Data.Interfaces
{
    public interface ISqlAccess : IDisposable
    {
        DataSet ExecuteDataSet(string query);
        int ExecuteNonQuery(string query);
        int ExecuteNonQuery(string query, params SqlParameter[] parameters);
        object ExecuteScalar(string query);
        object ExecuteScalar(string query, params SqlParameter[] parameters);
        DataTable GetDataTable(string query);
        DataTable GetDataTable(string query, params SqlParameter[] parameters);
        DataTable GetDataTableSP(string spName, params SqlParameter[] parameters);
    }
}
