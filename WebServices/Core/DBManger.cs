using System.Configuration;
using System.Data;
using System.Data.SqlClient;

    public  class DBManger
    {
        static string strcon;
         static DBManger()
        {
            strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;                 
        }

        public static int ExecuteNonQuery(string query, CommandType type, params SqlParameter[] arr)
        {
            int RowEffected = 0;

            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = type;
            if (arr != null)
                cmd.Parameters.AddRange(arr);
             RowEffected= cmd.ExecuteNonQuery();
         
            con.Close();

            return RowEffected;
        }
        public static object ExecuteScalor(string query,CommandType type,params SqlParameter[]arr)
        {
            object myreturn = 0;

            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = type;
            if (arr.Length!=0)
                cmd.Parameters.AddRange(arr);
            
            myreturn = cmd.ExecuteScalar();
            con.Close();
            return (int)myreturn;

            
        }
        public static DataTable ExecuteDataTable(string query, CommandType type, params SqlParameter[] arr)
        {
            SqlConnection con = new SqlConnection(strcon);
           // con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = type;
            if (arr.Length!=0)
                cmd.Parameters.AddRange(arr);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);

            DataTable td = new DataTable();
            adpt.Fill(td);
           // con.Close();
            return td;
        }
    }
