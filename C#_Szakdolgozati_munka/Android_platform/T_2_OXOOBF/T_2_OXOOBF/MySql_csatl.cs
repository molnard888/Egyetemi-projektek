using System;
using System.Collections.Generic;
using System.Text;

using MySqlConnector;


namespace T_2_OXOOBF
{
    public class MySql_csatl
    {
        public MySqlConnectionStringBuilder builderMySql = new MySqlConnectionStringBuilder
        {
            Server = "192.168.0.101",
            Database = "test",
            UserID = "root",
            Password = "E.0412",
        };


    }
}
