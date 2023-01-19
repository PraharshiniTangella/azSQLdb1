using System.Data.SqlClient;
using azSQLdb1.Models;

namespace azSQLdb1.Services
{
    public class PersonServivce
    {
        public static string sqldb_source = "azdb0001.database.windows.net";
        public static string sqldb_username = "azdbuser";
        public static string sqldb_password = "Azurepassword1!";
        public static string sqldb_database = "azdb";

        private SqlConnection GetSqlConnection()
        {
            var sql_con= new SqlConnectionStringBuilder();
            sql_con.DataSource = sqldb_source;
            sql_con.UserID = sqldb_username;
            sql_con.Password = sqldb_password;
            sql_con.InitialCatalog = sqldb_database;

            return new SqlConnection(sql_con.ConnectionString);
        }

        public List<Person> GetPersons()
        {
            SqlConnection con = GetSqlConnection();
            List<Person> person_list = new List<Person>();
            string statement = "SELECT * FROM aztable1";

            SqlCommand cmd = new SqlCommand(statement, con);
            con.Open();

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Person person= new Person();
                    {
                        person.Id = reader.GetInt32(0);
                        person.Name = reader.GetString(1);
                        person.Age = reader.GetInt32(2);
                        person.Role = reader.GetString(3);
                    }
                    person_list.Add(person);
                }
                con.Close();
            }
            return person_list;

        }

    }
}
