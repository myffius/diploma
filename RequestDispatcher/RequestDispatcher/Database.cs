using System;
using Finisar.SQLite;
using System.IO;

namespace RequestDispatcher.Storage
{
    public class SQLiteStorage
    {
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private bool initialized = true;

        public SQLiteStorage(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                File.Create(dbPath);
                initialized = false;
            }
            connection = new SQLiteConnection("DataSource=" + dbPath + ";Version=3;New=False;Compress=True;");
            if (!initialized)
            {
                initializationDb();
            }
        }

        private void initializationDb()
        {
            string sql = "CREATE TABLE handlers (id INT PRIMARY KEY AUTOINCREMENT, title VARCHAR(100))";
            execute(sql);
        }

        public SQLiteDataReader query(string sql)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = sql;
            SQLiteDataReader reader = command.ExecuteReader();
            connection.Close();
            return reader;
        }

        public SQLiteDataReader execute(string sql)
        {
            connection.Open();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = sql;
            SQLiteDataReader reader = command.ExecuteReader();
            connection.Close();
            return reader;
        }

        public object getLastInsertId()
        {
            command.CommandText = "SELECT last_insert_idrow()";
            return command.ExecuteScalar();
        }
    }
}
