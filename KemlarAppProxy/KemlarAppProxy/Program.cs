using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace KemlarAppProxy
{
    static class Program
    {

        static Boolean DebuggingMode = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Uncomment for a user front end.
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13001;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                Boolean KeepLooping = true;


                while (KeepLooping)
                {
                    if (DebuggingMode) Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    if (DebuggingMode) Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        if (DebuggingMode) Console.WriteLine("{0}", data);
                                                
                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        //Pass the message on to extract the data from it
                        extractFieldsFromString(msg);

                        //If database tables don't exsist create them
                        //CreateDatabaseTables();  
                        
                        if(!CheckDatabaseExists("KemlarIn"))
                        {
                            //Create
                        }
                        
                        if (!CheckDatabaseExists("KemlarOut"))
                        {
                            //Create
                        }


                        //Search the In database to see if an entry already exists
                        //searchInDatabase();

                        //If it doesn't exist then create a new entry 
                        insertInToInDatabase();

                        //if it does then create new entry in Out database with the same values and remove from in
                        insertInToOutDatabase();
                        removeFromInDatabase();

                        //Check to see if any entrys in the In database are older than XXX minutes
                        searchInDatabaseForOldRecords();


                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                if (DebuggingMode) Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

        }

        static void extractFieldsFromString(byte[] msg)
        {

        }

        static void CreateDatabaseTables(SqlConnection tmpConn, string databaseName)
        {
            /**
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                tmpConn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");

                sqlCreateDBQuery = string.Format("CREATE KemlarIn FROM sys.databases WHERE Name = '{0}'", databaseName);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        tmpConn.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            if (DebuggingMode) Console.Write(result);
            return result;
            */
        }

        /**
         * A quick search for the license plate in the In Database.
         * Requires the vehicle license plate as that will be the only unique value.
         */
        static Boolean searchInDatabase(string ANPRPlate)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                SqlConnection tmpConn = new SqlConnection();

                tmpConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jamie\Source\Repos\ReportingTool\KemlarAppProxy\KemlarAppProxy\Kemlar.mdf;Integrated Security=True;Connect Timeout=30");

                sqlCreateDBQuery = string.Format("SELECT * FROM KemlarIn WHERE Plate = {0}", ANPRPlate);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        tmpConn.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    

        static void insertInToInDatabase()
        {

        }

        static void removeFromInDatabase()
        {

        }

        static void insertInToOutDatabase()
        {

        }

        static void searchInDatabaseForOldRecords()  // Things older than 15 minutes
        {

        }

        private static bool CheckDatabaseExists(string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                SqlConnection tmpConn = new SqlConnection();
                //tmpConn = new SqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");
                tmpConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jamie\Source\Repos\ReportingTool\KemlarAppProxy\KemlarAppProxy\Kemlar.mdf;Integrated Security=True;Connect Timeout=30"); 

                sqlCreateDBQuery = string.Format("SELECT * FROM {0}", databaseName);
        
                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        tmpConn.Close();

                        result = (databaseID > 0);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            if (DebuggingMode) Console.Write(databaseName + "= " + result + System.Environment.NewLine);
            return result;
        }
    }


}
