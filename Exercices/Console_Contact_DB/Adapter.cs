using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace Console_Contact_DB
{
    internal class Adapter
    {
        private const string DB_CONNECTION = "server=localhost;port=3306;database=clients_db;user=root;password=Malloc33";
        private const string TABLE_NAME = "client";
        MySqlConnection db = new MySqlConnection(DB_CONNECTION);

        public Adapter()
        {
            if (!TestConnection())
            {
                StdMsg.ForcedExit();
                Environment.Exit(10);
            }
        }
        

        private bool TestConnection()
        {
            try
            {
                db.Open();
                db.Close();
                return true;
            }
            catch
            {
                StdMsg.DbConnectionError();
                return false;
            }
        }

        public void Insert(Contact_Model contact)
        {
            string query = $"INSERT INTO {TABLE_NAME} (name, address, phone, age) VALUES ('{contact.Name}', '{contact.Address}', '{contact.Phone}', {contact.Age})";

            try
            {
                db.Open();

                MySqlCommand command = new MySqlCommand()
                {
                    Connection = db,
                    CommandType = CommandType.Text,
                    CommandText = query
                };

                if (command.ExecuteNonQuery() == 1)
                {
                    StdMsg.InsertSuccessful();
                }
                else
                {
                    StdMsg.InsertFailed();
                }
                db.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public List<Contact_Model> Read()
        {
            string query = $"SELECT * FROM client";

            List<Contact_Model> contacts = new ();

            try
            {
                db.Open();

                MySqlCommand command = new MySqlCommand()
                {
                    Connection = db,
                    CommandType = CommandType.Text,
                    CommandText = query
                };

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while( reader.Read())
                    {
                        Contact_Model contact = new Contact_Model(
                                int.Parse(reader["id"].ToString()),
                                reader["name"].ToString(),
                                reader["address"].ToString(),
                                reader["phone"].ToString(),
                                int.Parse(reader["age"].ToString())
                            );
                        contacts.Add(contact);
                    }
                }
                reader.Close();

                db.Close();

                return contacts;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

    }
}
