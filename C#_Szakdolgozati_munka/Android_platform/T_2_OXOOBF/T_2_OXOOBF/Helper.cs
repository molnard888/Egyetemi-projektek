using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace T_2_OXOOBF
{
    public static class Helper
    {
        public static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "192.168.0.105",
            Database = "raktarkezelo",
            UserID = "root",
            Password = "E.0412",
        };

        public static List<string> SelectedItems = new List<string>();
        public static string EladasokSelectedItems;
    }
}
