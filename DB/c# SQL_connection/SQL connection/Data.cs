using MySql.Data.MySqlClient;

namespace SQL_connection
{
    public static class Data
    {
        private static string connectionString;
        /// <summary>
        /// Initialize connection to DB
        /// </summary>
        public static void Init()
        {
            string serverAddress = "localhost";
            string databaseName = "db_space_invaders";
            string userID = "root";
            string password = "root";
            string portNumber = "6033";
            
            connectionString = "server=" + serverAddress + ";" +
                                "uid=" + userID + ";" +
                                "pwd=" + password + ";" +
                                "database=" + databaseName + ";" +
                                "port=" + portNumber + ";";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.Write("Connection Successful");
            }
            catch (Exception)
            {
                Console.Write("Connection failed");
                throw;
            }

        }
        /// <summary>
        /// Add player score name and score value to database.
        /// </summary>
        /// <param name="username">player's username.</param>
        /// <param name="score">player's score.</param>
        public static void SetPlayerScore(string username, int score)
        {
            string mycommand = $"INSERT INTO t_joueur (jouPseudo, jouNombrePoints)VALUES('{username}', {score}); ";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(mycommand, connection);
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
        }
        /// <summary>
        /// Display player name and their score.
        /// </summary>
        /// <param name="xpos">x position where to display data</param>
        /// <param name="ypos">y position where to display the data</param>
        /// <param name="ySeparater">amount of space between first and 2nd collumn</param>
        /// <param name="byName">Order by name, or by score</param>
        public static void GetPlayerScores(int xpos, int ypos, int ySeparater, bool byName = false)
        {
            string mycommand = (byName) ? "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC;" : "SELECT * FROM t_joueur ORDER BY jouPseudo ASC;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(mycommand, connection);
            MySqlDataReader mySqlDataReader = command.ExecuteReader();

            Console.SetCursorPosition(ypos, xpos);
            Console.Write("jouPseudo");
            Console.SetCursorPosition(ypos + ySeparater, xpos);
            Console.Write("jouNombrePoints");
            xpos += 2;
            while (mySqlDataReader.Read())
            {
                Console.SetCursorPosition(ypos, xpos);
                if (string.IsNullOrEmpty(mySqlDataReader["jouPseudo"].ToString()))
                {
                    Console.Write("NULL" + new String(' ', ySeparater - 7) + ":  ");
                }
                else
                {
                Console.Write(mySqlDataReader["jouPseudo"] + new String(' ', ySeparater - 3 - (mySqlDataReader["jouPseudo"].ToString()).Length) + ":  ");

                }
                Console.SetCursorPosition(ypos + ySeparater, xpos);
                Console.Write(mySqlDataReader["jouNombrePoints"]);
                xpos++;
            }
        }
    }
}