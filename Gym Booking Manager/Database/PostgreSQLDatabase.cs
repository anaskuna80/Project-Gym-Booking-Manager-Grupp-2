using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Gym_Booking_Manager.Database
{
    internal class PostgreSQLDatabase
    {
        public static Dictionary<string, Type> TypeOfClass { get; } = new Dictionary<string, Type>
        {
            { "Space", typeof(Space) },
            { "Calendar", typeof(Calendar) },
            { "GroupActivity", typeof(GroupActivity) },
            { "LargeEquipment", typeof(LargeEquipment) },
            { "PersonalTrainer", typeof(PersonalTrainer) },
            { "SportsEquipment", typeof(SportsEquipment) },
            { "Staff", typeof(Staff) },
            { "Customer", typeof(Customer) },
            { "Equipment", typeof (Equipment) }
        };
        public static NpgsqlConnection getConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=BenjiBenji9PG;Database=GymDB");
        }
        public static void testConnection()
        {
            using (NpgsqlConnection con = getConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connected");
                }
            }
        }
        public static void createRecord(object theObject)
        {
            using (NpgsqlConnection con = getConnection())
            {
                var type = theObject.GetType();
                var tableName = TypeOfClass.FirstOrDefault(x => x.Value == type).Key;
                string propertyName = string.Empty;
                foreach (var property in type.GetProperties().OrderBy(p => p.Name))
                {
                    if (property.GetValue(theObject) != null)
                    {
                        propertyName = propertyName + property.Name + ",";
                    }
                }
                propertyName = propertyName.TrimEnd(',');
                string query = $@"INSERT INTO {tableName} ({propertyName}) VALUES({theObject.ToString()});";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
            }
        }
        public static object[] readRecord(string typeOfObject, int id)
        {
            using (NpgsqlConnection con = getConnection())
            {
                var query = $"SELECT * FROM {typeOfObject} WHERE ID = {id}";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var dataReader = cmd.ExecuteReader();
                dataReader.Read();
                int columns = dataReader.FieldCount;
                object[] values = new object[columns];
                dataReader.GetValues(values);
                return values;
            }
        }
        public static void readAndPrintAllRecord(string typeOfObject)
        {
            using (NpgsqlConnection con = getConnection())
            {
                var query = $"SELECT * FROM {typeOfObject}";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        object value = dataReader.GetValue(i);
                        Console.Write(Convert.ToString(value) + " ");
                    }
                    Console.WriteLine();
                }

            }
        }

        public static void updateRecord(string tableName, int id, string attributeToEdit, string value)
        {
            Type typeOfObject = TypeOfClass[tableName];
            var TypeOfAttribute = typeOfObject.GetProperty(attributeToEdit);
            object convertedVariable = Convert.ChangeType(value, TypeOfAttribute.PropertyType);
            string query = string.Empty;
            using (NpgsqlConnection con = getConnection())
            {
                if (convertedVariable is string)
                {
                    query = $@"UPDATE {tableName} SET {attributeToEdit} = '{convertedVariable}' WHERE ID = {id};";
                }
                else
                {
                    query = $@"UPDATE {tableName} SET {attributeToEdit} = {convertedVariable} WHERE ID = {id};";
                }
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
            }
        }
        public static void deleteRecord(string tableName, int id)
        {
            using (NpgsqlConnection con = getConnection())
            {
                var query = $@"DELETE FROM {tableName} WHERE ID = {id};";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
            }
        }
    }
}
