/// TODO Discuter avec Benjamin de la forme de la BDD
/// TODO Préparer la forme en fonction des rows de la BDD


using System;
using System.Data.SqlClient;
using System.Net;
using System.Data;
using Google.Protobuf;
using MySql.Data.MySqlClient;
using Ubiety.Dns.Core;


namespace Projet_Centrale_Beton
{
    public class MySQLConnector
    {
        private string ipServer;
        private string database;
        private string user;
        private string password;
        private string statement,statement2;
        private string databaseString;
        private MySqlConnection db;
        private int index;
        private object[] table;


        /// <summary>
        /// Création de l'objet MySQLConnector. Cet objet permet, au travers de ces méthodes, de se connecter à la BDD
        /// uniquement en MySQL (uniquement en local pour le moment WIP).
        /// </summary>
        /// <param name="ipServer"></param>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public MySQLConnector(string ipServer, string database, string user, string password)
        {
            this.ipServer = ipServer;
            this.database = database;
            this.user = user;
            this.password = password;
            databaseString = "Server=" + ipServer + ";User ID=" + user + ";Password=" + password + ";Database=" +
                             database;
        }

        public MySQLConnector()
        {
        }


        /// <summary>
        /// Connexion à la Base de données et premier test de connexion. Cette méthode, comme la déconnexion, ne peuvent être utilisés
        /// que dans cette classe et ne peuvent être inhérité.
        /// </summary>
        private void Connect()
        {
            try
            {
                db = new MySqlConnection(databaseString);
                db.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }


        /// <summary>
        /// Déconnexion de la Base de Données. Cette méthode, comme la déconnexion, ne peuvent être utilisés
        /// que dans cette classe et ne peuvent être inhérité.
        /// </summary>
        private void Disconnect()
        {
            db.Close();
        }

        public void PremierTest()
        {
            Connect();

            Console.WriteLine("Première statement test :");
            statement = "SELECT * FROM commandes";
            MySqlCommand cmd = new MySqlCommand(statement, db);
            MySqlDataReader reader = cmd.ExecuteReader();
            

            int i = 0;
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + "" + reader[1] + " " + reader[2] + " " + reader[3]);
                i++;
            }


            Disconnect();
        }


        public void CheckDriverUID(string id)
        {
            Connect();

            statement = "SELECT * FROM encours WHERE UID =" + id;
            MySqlCommand cmd = new MySqlCommand(statement, db);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("ID Correct");
                index = reader[0].GetHashCode();
                table = new[] {reader[0],reader[1],reader[2],reader[3],reader[4],reader[5]};
            }
            else
            {
                Console.WriteLine("Fake ID");
            }
            
            TransfertFinishedOrder(table);
            Disconnect();
        }


        private void TransfertFinishedOrder(object[] table)
        {
            Connect();

            statement2 = "INSERT INTO conclus(UID,Nom,Prenom,Montant) VALUES ('" + table[2].ToString() + "','" + table[3].ToString() + "','" + table[4].ToString() + "','" + table[5].ToString() + "')";
            MySqlCommand cmd = new MySqlCommand(statement2, db);
            cmd.ExecuteNonQuery();
            
            Disconnect();
        }

        public void testConnexion()
        {
            Connect();

            statement = "SELECT * FROM utilisateurs";
            MySqlCommand cmd = new MySqlCommand(statement, db);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine(reader[0] + " " + reader[1]);
            }
            
            
            
            Disconnect();
            
            
        }
        
        
    }
}