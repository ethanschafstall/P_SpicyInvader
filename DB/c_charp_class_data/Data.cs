using MySql.Data.MySqlClient;

namespace Data
{
    /// <summary>
    /// class for connecting to the database and read/writing data.
    /// </summary>
    public static class Data
    {

        private static string connectionString;
        /// <summary>
        /// Initialize connection to DB
        /// </summary>
        public static bool Init()
        {
            // connection variables
            string serverAddress = "localhost";
            string databaseName = "db_space_invaders";
            string userID = "root";
            string password = "root";
            string portNumber = "6033";

            // This string works exactly like how you would connect to a mysql DB via a CMD console, where you must into the command containing certain info.

            // The first part is for the server address the DB is hosted on.
            // Second is the mysql username.
            // Third is the user's password.
            // Fourth is the Database to be connected to/used.
            // Fith is the port mysql is using.

            // all of these strings together make the command which connects us to the correct DB, in the correct server IP, with the correct User.
            connectionString = "server=" + serverAddress + ";" +
                                "uid=" + userID + ";" +
                                "pwd=" + password + ";" +
                                "database=" + databaseName + ";" +
                                "port=" + portNumber + ";";

            MySqlConnection connection = new MySqlConnection(connectionString);

            // trys to connect mysql
            try
            {
                Console.Write("Connecting");
                connection.Open();
                return true;
            }
            // if it's unable to connect to mysql
            catch (Exception)
            {

                Console.Write("\nFailed to connect.");
                Thread.Sleep(2000);
                return false;
            }

        }
        /// <summary>
        /// Add player score name and score value to database.
        /// </summary>
        /// <param name="username">player's username.</param>
        /// <param name="score">player's score.</param>
        public static void SetPlayerScore(string username, int score)
        {
            // string for the Write/Instert SQL command + the data to be inserted.
            string mycommand = $"INSERT INTO t_joueur (jouPseudo, jouNombrePoints)VALUES('{username}', {score}); ";

            // connects to the mysql/DB
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // creates the command with insert string and connection variable.
            MySqlCommand command = new MySqlCommand(mycommand, connection);

            // executes the command variable into mysql.
            MySqlDataReader mySqlDataReader = command.ExecuteReader();

        }
        /// <summary>
        /// Display player name and their score.
        /// </summary>
        /// <param name="xpos">x position where to display data</param>
        /// <param name="ypos">y position where to display the data</param>
        /// <param name="ySeparater">amount of space between first and 2nd collumn</param>
        /// /// <param name="alias">alias text based on program language</param>
        /// /// <param name="points">points text based on program language</param>
        /// <param name="byName">Order by name, or by score</param>
        public static void GetPlayerScores(int xpos, int ypos, int ySeparater, string alias, string points,bool byName = false)
        {
            // string for the Read/Select SQL command, based on byName bool which determines if it's ordered by name or by points.
            string mycommand = (byName) ? "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC;" : "SELECT * FROM t_joueur ORDER BY jouPseudo ASC;";

            // connects to the mysql/DB
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // creates the command with insert string and connection variable.
            MySqlCommand command = new MySqlCommand(mycommand, connection);
            // executes the command variable into mysql.
            MySqlDataReader mySqlDataReader = command.ExecuteReader();


            // formating and loops for displaying data with column names and associated data. 
            Console.SetCursorPosition(ypos, xpos);
            Console.Write(alias);
            Console.SetCursorPosition(ypos, xpos);
            Console.Write(points);
            xpos += 2;
            while (mySqlDataReader.Read()/* reads the data from the table */)
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