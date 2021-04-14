using BibleVerseApp.Models;
using BibleVerseApp.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Data
{
    public class VerseDAO : VerseDataInterface
    {
        //Connection string to the database
        string Connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleVerseDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.Delete</see>
         */
        public int Delete(int Id)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.Delete \n With Parameter: " + Id);
            int rowsAffected = -1;

            //Create SQL Statament
            string SqlStatment = "DELETE FROM dbo.Verse WHERE Id = @id";

            //Create connection object for the database
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Making the full command with the SQL Statment and connection
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                //Adding Parameters to the command
                sqlCommand.Parameters.AddWithValue("@Id", Id);

                try
                {
                    //Run the command
                    connection.Open();

                    //Return the rows Afftected
                    rowsAffected = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    //If there is an error: log it to the log file and console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.Delete \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            //Return rows affected
            MyLogger.GetInstance().Info("Leaving VerseDAO.Delete \n With Parameter: " + rowsAffected);
            return rowsAffected;
        }


        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.Get</see>
         */
        public List<VerseModel> Get()
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.Get");
            List<VerseModel> products = new List<VerseModel>();

            //Create SQL Statment
            string SqlStatment = "SELECT * FROM dbo.Verse";

            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Create Command with the SQL Statment and connection
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                try
                {
                    //Run the Command
                    connection.Open();

                    //Get all the rows returned
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //Create Verse Objects from the database 
                    while (reader.Read())
                    {
                        products.Add(new VerseModel { Id = (int)reader[0], 
                                                      Testament = (string)reader[1], 
                                                      Book = (string)reader[2], 
                                                      ChapNum = (int)reader[3], 
                                                      VerseNum = (int)reader[4], 
                                                      Text = (string)reader[5] 
                                                    });

                    }
                }
                catch (Exception ex)
                {
                    //If there is an error log it to the console and the log file
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.Get \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            //Return a list of vereses
            MyLogger.GetInstance().Info("Leaving VerseDAO.Get \n With Paramenter: " + products.ToString());
            return products;
        }

        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.GetById</see>
         */
        public VerseModel GetById(int Id)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.GetById \n With Parameter: " + Id);
            VerseModel Verse = null;

            //Create SQL Statment
            string SqlStatment = "SELECT * FROM dbo.Verse WHERE Id = @Id";

            //Create connection to the database
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Create the command with the statment and connection
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                //Add parameters to the sql statment
                sqlCommand.Parameters.AddWithValue("@Id", Id);

                try
                {
                    //Opends connection
                    connection.Open();

                    //Runs the command
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //With all the rows returned creates Verse Objects and adds them to a list
                    while (reader.Read())
                    {
                        Verse = new VerseModel {
                                                    Id = (int)reader[0], 
                                                    Testament = (string)reader[1], 
                                                    Book = (string)reader[2], 
                                                    ChapNum = (int)reader[3], 
                                                    VerseNum = (int)reader[4], 
                                                    Text = (string)reader[5]
                                                };

                    }
                }
                catch (Exception ex)
                {
                    //If there is an error it will be logged to the log file and console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.GetById \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            //Return the list of Verses
            MyLogger.GetInstance().Info("Leaving VerseDAO.GetById \n With Parameter: " + Verse.ToString());
            return Verse;
        }

        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.Insert</see>
         */
        public int Insert(VerseModel Verse)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.Insert \n With Parameter: " + Verse.ToString());
            int result = -1;

            //Creates a SQL Statment    
            string SqlStatment = "INSERT INTO dbo.Verse (TESTAMENT, BOOK, CHAPTER_NUM, VERSE_NUM, VERSE_TEXT) VALUES (@Testament, @Book, @ChapNum, @VerseNum, @Text)";

            //Creates a connection to the database
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Create the command to run the sql statment with the conneciton
                SqlCommand command = new SqlCommand(SqlStatment, connection);

                //Adds all parameters in to the command
                command.Parameters.AddWithValue("@Testament", Verse.Testament);
                command.Parameters.AddWithValue("@Book", Verse.Book);
                command.Parameters.AddWithValue("@ChapNum", Verse.ChapNum);
                command.Parameters.AddWithValue("@VerseNum", Verse.VerseNum);
                command.Parameters.AddWithValue("@Text", Verse.Text);

                try
                {
                    //Opens the connection
                    connection.Open();

                    //Runs the command on the database
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    //If there is an error it will be logged in the log file and the console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.Insert \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            //Return the number of rows affected
            MyLogger.GetInstance().Info("Leaving VerseDAO.Insert \n With Parameter: " + Verse.ToString());
            return result;
        }

        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.Serach</see>
         */
        public List<VerseModel> Search(string Book, int Chapter, int Verse)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.Serach \n With Parameter: " + Book + " " + Chapter + " " + Verse);
            List<VerseModel> Verses = new List<VerseModel>();

            //Creates a SQL Statment
            string SqlStatment = "SELECT * FROM dbo.Verse WHERE BOOK LIKE @book AND CHAPTER_NUM = @chapter AND VERSE_NUM = @verse";

            //Creates a connection to the database with the connection string
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Creates a command with the statment and connections
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                //Adds Parameters to the command
                sqlCommand.Parameters.AddWithValue("@book", "%" + Book + "%");
                sqlCommand.Parameters.AddWithValue("@chapter", Chapter);
                sqlCommand.Parameters.AddWithValue("@verse", Verse);

                try
                {
                    //Opens the connection
                    connection.Open();

                    //Exectues the Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //Grabs all returned rows and creats Verses object adding them to a list
                    while (reader.Read())
                    {
                        Verses.Add(new VerseModel {
                                                        Id = (int)reader[0],
                                                        Testament = (string)reader[1],
                                                        Book = (string)reader[2],
                                                        ChapNum = (int)reader[3],
                                                        VerseNum = (int)reader[4],
                                                        Text = (string)reader[5]
                                                    });

                    }
                }
                catch (Exception ex)
                {
                    //If there is an error it will be logged to the lof file and console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.Search \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            //Returns the list of Verses
            MyLogger.GetInstance().Info("Leaving VerseDAO.Serach \n With Parameter: " + Verses.ToString());
            return Verses;
        }

        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.Update</see>
         */
        public VerseModel Update(VerseModel Verse)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.Update \n With Parameter: " + Verse.ToString());
            int newIdNumber = -1;

            //Creates SQL Statment
            string SqlStatment = "UPDATE dbo.Verse SET TESTAMENT = @Testament, BOOK = @Book, CHAPTER_NUM = @ChapNum, VERSE_NUM = @VerseNum, VERSE_TEXT = @Text WHERE Id = @id";

            //Creates connection to the databse
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Creates a command with the statment and connections
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                //Adds Parameters to the command
                sqlCommand.Parameters.AddWithValue("@Testament", Verse.Testament);
                sqlCommand.Parameters.AddWithValue("@Book", Verse.Book);
                sqlCommand.Parameters.AddWithValue("@ChapNum", Verse.ChapNum);
                sqlCommand.Parameters.AddWithValue("@VerseNum", Verse.VerseNum);
                sqlCommand.Parameters.AddWithValue("@Text", Verse.Text);

                try
                {
                    //Opens the connection
                    connection.Open();

                    newIdNumber = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    //If there is an error it will be logged to the lof file and console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.Update \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            MyLogger.GetInstance().Info("Leaving VerseDAO.Update \n With Parameter: " + Verse.ToString());
            return Verse;
        }

        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.SearchTestament</see>
         */
        public List<VerseModel> SearchTestament(string SerachParam)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.SearchTestament \n With Parameter: " + SerachParam);
            List<VerseModel> Verses = new List<VerseModel>();

            //Creates SQL Statment
            string SqlStatment = "SELECT * FROM dbo.Verse WHERE TESTAMENT LIKE @param";

            //Creates connection to the databse
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Creates a command with the statment and connections
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                //Adds Parameters to the command
                sqlCommand.Parameters.AddWithValue("@param", "%" + SerachParam + "%");

                try
                {
                    //Opens the connection
                    connection.Open();

                    //Executes Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //Grabs all returned rows and creats Verses object adding them to a list
                    while (reader.Read())
                    {
                        Verses.Add(new VerseModel
                        {
                            Id = (int)reader[0],
                            Testament = (string)reader[1],
                            Book = (string)reader[2],
                            ChapNum = (int)reader[3],
                            VerseNum = (int)reader[4],
                            Text = (string)reader[5]
                        });

                    }
                }
                catch (Exception ex)
                {
                    //If there is an error it will be logged to the lof file and console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.SearchTestament \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            MyLogger.GetInstance().Info("Leaving VerseDAO.SerachTestament \n With Parameter: " + Verses.ToString());
            return Verses;
        }

        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.SearchChapter</see>
         */
        public List<VerseModel> SearchChapter(int SerachParam)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.SearchChapter \n With Parameter: " + SerachParam);
            List<VerseModel> Verses = new List<VerseModel>();

            //Creates SQL Statment
            string SqlStatment = "SELECT * FROM dbo.Verse WHERE CHAPTER_NUM = @param";

            //Creates connection to the databse
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Creates a command with the statment and connections
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                //Adds Parameters to the command//Adds Parameters to the command
                sqlCommand.Parameters.AddWithValue("@param", SerachParam);

                try
                {
                    //Opens the connection
                    connection.Open();

                    //Executes Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //Grabs all returned rows and creats Verses object adding them to a list
                    while (reader.Read())
                    {
                        Verses.Add(new VerseModel
                        {
                            Id = (int)reader[0],
                            Testament = (string)reader[1],
                            Book = (string)reader[2],
                            ChapNum = (int)reader[3],
                            VerseNum = (int)reader[4],
                            Text = (string)reader[5]
                        });

                    }
                }
                catch (Exception ex)
                {
                    //If there is an error it will be logged to the lof file and console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.SearchChapter \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            MyLogger.GetInstance().Info("Leaving VerseDAO.SerachChapter \n With Parameter: " + Verses.ToString());
            return Verses;
        }
        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.SearchBook</see>
         */
        public List<VerseModel> SearchBook(string SerachParam)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.SearchBook \n With Parameter: " + SerachParam);
            List<VerseModel> Verses = new List<VerseModel>();

            //Creates SQL Statment
            string SqlStatment = "SELECT * FROM dbo.Verse WHERE BOOK LIKE @param";

            //Creates connection to the databse
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Creates a command with the statment and connections
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                //Adds Parameters to the command
                sqlCommand.Parameters.AddWithValue("@param", "%" + SerachParam + "%");

                try
                {
                    //Opens the connection
                    connection.Open();

                    //Executes Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //Grabs all returned rows and creats Verses object adding them to a list
                    while (reader.Read())
                    {
                        Verses.Add(new VerseModel
                        {
                            Id = (int)reader[0],
                            Testament = (string)reader[1],
                            Book = (string)reader[2],
                            ChapNum = (int)reader[3],
                            VerseNum = (int)reader[4],
                            Text = (string)reader[5]
                        });

                    }
                }
                catch (Exception ex)
                {
                    //If there is an error it will be logged to the lof file and console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.SerachBook \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            MyLogger.GetInstance().Info("Leaving VerseDAO.SerachBook \n With Parameter: " + Verses.ToString());
            return Verses;
        }
        /**
         * <see>BibleVerseApp.Data.VerseDataInterface.SearchVerse</see>
         */
        public List<VerseModel> SearchVerse(int SerachParam)
        {
            MyLogger.GetInstance().Info("Entering VerseDAO.SearchVerse \n With Parameter: " + SerachParam);
            List<VerseModel> Verses = new List<VerseModel>();

            //Creates SQL Statment
            string SqlStatment = "SELECT * FROM dbo.Verse WHERE VERSE_NUM = @param";

            //Creates connection to the databse
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                //Creates a command with the statment and connections
                SqlCommand sqlCommand = new SqlCommand(SqlStatment, connection);

                //Adds Parameters to the command
                sqlCommand.Parameters.AddWithValue("@param", SerachParam);

                try
                {
                    //Opens the connection
                    connection.Open();

                    //Executes Command
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    //Grabs all returned rows and creats Verses object adding them to a list
                    while (reader.Read())
                    {
                        Verses.Add(new VerseModel
                        {
                            Id = (int)reader[0],
                            Testament = (string)reader[1],
                            Book = (string)reader[2],
                            ChapNum = (int)reader[3],
                            VerseNum = (int)reader[4],
                            Text = (string)reader[5]
                        });

                    }
                }
                catch (Exception ex)
                {
                    //If there is an error it will be logged to the lof file and console
                    MyLogger.GetInstance().Error("SQL Error within VerseDAO.SearchVerse \n With Error Message: " + ex.Message);
                    Console.WriteLine("SQL Error within ProductsDAO.GetAll(): " + ex.Message);
                }
            }

            MyLogger.GetInstance().Info("Leaving VerseDAO.SerachVerse \n With Parameter: " + Verses.ToString());
            return Verses;
        }
    }
}
