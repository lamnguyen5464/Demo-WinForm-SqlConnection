using System;
using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp1.Repositories
{
    class CompanyDatabase
    {
        private static CompanyDatabase instance = null;
        SqlConnection connection;

        private CompanyDatabase()
        {

        }

        public static CompanyDatabase getIntance()
        {
            if (CompanyDatabase.instance == null)
            {
                CompanyDatabase.instance = new CompanyDatabase();
            }
            return CompanyDatabase.instance;
        }

        public void doConnect()
        {
            this.connection = new SqlConnection();
            this.connection.ConnectionString = @"Data Source=LAMNGUYEN5464\SQLEXPRESS;Initial Catalog=Company;Integrated Security=True";
            this.connection.Open();
        }

        public void doDisconnect()
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

        public DataSet queryData(String sqlCommand)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
            DataSet datasetResult = new DataSet();
            adapter.Fill(datasetResult);
            return datasetResult;
        }
    }
}
