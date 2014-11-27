using DataHelpers.Objects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms; //temporary debugging use

namespace DataHelpers
{
    public class TicketingDBConnector
    {
        string _TicketingConnection = ConfigurationManager.ConnectionStrings["Ticketing"].ToString();

        public DataTable GetEvents()
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Get_UpcomingEvents", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlAdapter.Fill(dt);
                    }

                    return dt;
                }
            }
        }

        public DataTable GetUnavailableSections(int EventID, int Level, int SectionCapacity = 625)
        { //Not Implemented
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Get_UnavailableSections", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@Level", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaxSectionCount", SqlDbType.Int));
                    sqlCommand.Parameters["@EventID"].Value = EventID;
                    sqlCommand.Parameters["@Level"].Value = Level;
                    sqlCommand.Parameters["@MaxSectionCount"].Value = SectionCapacity;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlAdapter.Fill(dt);
                    }

                    return dt;
                }
            }
        }

        public DataTable GetUnavailableRows(int EventID, int Level, string Section, int SectionCapacity = 25)
        { //Not implemented
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Get_UnavailableRows", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@Level", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@Section", SqlDbType.NChar));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaxRowCapacity", SqlDbType.Int));
                    sqlCommand.Parameters["@EventID"].Value = EventID;
                    sqlCommand.Parameters["@Level"].Value = Level;
                    sqlCommand.Parameters["@Section"].Value = Section;
                    sqlCommand.Parameters["@MaxRowCapacity"].Value = SectionCapacity;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlAdapter.Fill(dt);
                    }

                    return dt;
                }
            }
        }

        public DataTable GetUnavailableSeats(int EventID, int Level, char Section, int Row)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Get_UnavailableSeats", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@Level", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@Section", SqlDbType.NChar));
                    sqlCommand.Parameters.Add(new SqlParameter("@Row", SqlDbType.Int));
                    sqlCommand.Parameters["@EventID"].Value = EventID;
                    sqlCommand.Parameters["@Level"].Value = Level;
                    sqlCommand.Parameters["@Section"].Value = Section;
                    sqlCommand.Parameters["@Row"].Value = Row;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlAdapter.Fill(dt);
                    }

                    return dt;
                }
            }
        }

        public string GenerateTicket(Ticket ticket, ref int rowCount)
        {
            StringBuilder OrderNumber = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < 15; i++ )
            {
                if (rand.Next(2) == 1)
                {
                    OrderNumber.Append(Convert.ToChar(rand.Next(65, 90)));
                }
                else
                {
                    OrderNumber.Append(rand.Next(0, 9).ToString());
                }
                
            }
            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Insert_Ticket", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TicketNumber", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@Level", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@Section", SqlDbType.NChar));
                    sqlCommand.Parameters.Add(new SqlParameter("@Row", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@Seat", SqlDbType.Int));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.NVarChar));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Int));
                    sqlCommand.Parameters["@TicketNumber"].Value = ticket.TicketNo;
                    sqlCommand.Parameters["@EventID"].Value = ticket.EventID;
                    sqlCommand.Parameters["@Level"].Value = ticket.Level;
                    sqlCommand.Parameters["@Section"].Value = ticket.Section;
                    sqlCommand.Parameters["@Row"].Value = ticket.Row;
                    sqlCommand.Parameters["@Seat"].Value = ticket.Seat;
                    sqlCommand.Parameters["@OrderNumber"].Value = OrderNumber.ToString();
                    sqlCommand.Parameters["@ReturnValue"].Direction = ParameterDirection.ReturnValue;

                    sqlCommand.ExecuteNonQuery();

                    rowCount = Convert.ToInt32(sqlCommand.Parameters["@ReturnValue"].Value);

                    return OrderNumber.ToString();
                }
            }
        }

        public void GenerateOrder(Guid ticketNo, string OrderNumber, string cardLastFour)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Insert_Order", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TicketNumber", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.NChar));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastFour", SqlDbType.NChar));
                    sqlCommand.Parameters["@TicketNumber"].Value = ticketNo;
                    sqlCommand.Parameters["@OrderNumber"].Value = OrderNumber;
                    sqlCommand.Parameters["@LastFour"].Value = cardLastFour;

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        #region Code added by Judson for things he needs the DBC to do - none of this actually works
        public bool kill(string userName)
        {
            //updates DB to kill session associated with userName
            //assuming table "session" with columns "userID", "userName", "dateTime", "sessionCurrent"

            //my thinking:  update record containing userName to indicate sessionCurrent binary value of false? no idea how this is supposed to work, sorry
            string query = "UPDATE session SET sessionCurrent = @killed WHERE userName = " + userName;
            using (SqlConnection connection = new SqlConnection(_TicketingConnection))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@killed", SqlDbType.Bit).Value = false;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return true;
        }
        public string getPass(string userName)
        {
            string mPass = "TemporaryPassword";
            //execute query to set mPass based on userName -- get username's stored password from DB
            //assuming table "users" with columns "userID", "user", "pass"
            using (SqlConnection connection = new SqlConnection(_TicketingConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM users WHERE user = " + userName, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        mPass = reader.GetString(reader.GetOrdinal("pass"));
                    }
                }
                connection.Close();

            }
            return mPass; //mPass should be the password retrieved from the DB

        }
        public void setSession(string userName)
        { 
            //updates DB entry to create session based on userName
            //assuming table "session" with columns "userID", "userName", "dateTime", "sessionCurrent"
            DateTime mDate = DateTime.Now;

            string query = "INSERT INTO session (userName, dateTime, sessionCurrent) VALUES (@userName, @dateTime, @session)";
            using (SqlConnection connection = new SqlConnection(_TicketingConnection))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;
                    command.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = mDate;
                    command.Parameters.Add("@session", SqlDbType.Bit).Value = true;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public bool save(Event e) //**** It looks like you started to try what I had done. Mine are stored procedures where the code is handled database side.
        {                         //**** In the database -> Programmability -> Stored Procedures. You can look at what I did by right clicking one and selecting
                                  //**** Script As -> Create To -> New Window. After you look at it you can clear mine out and use it to write yours. 
                                  //**** I've fixed to code below to work with one so that way you'll have less to sort out your first time.

            //updates DB to include passed in Event from AddEventController
            //assuming table "events" with columns "EventID", "Name", "Date", "Floor", "Level1", "Level2", "BasePrice", "MaxPrice"

            //string query = "INSERT INTO events (EventID, Name, Date, Floor, Level1, Level2, BasePrice, MaxPrice) VALUES (@EventID, @Name, @Date, @Floor, @Level1, @Level2, @BasePrice, @MaxPrice)";
            using (SqlConnection connection = new SqlConnection(_TicketingConnection))
            {
                connection.Open(); //The connection has to happen first for reasons I forget
                using (SqlCommand command = new SqlCommand("Your Stored Procedure Name Here", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@EventID", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NChar));
                    command.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@Floor", SqlDbType.Bit));
                    command.Parameters.Add(new SqlParameter("@Level1", SqlDbType.Bit));
                    command.Parameters.Add(new SqlParameter("@Level2", SqlDbType.Bit));
                    command.Parameters.Add(new SqlParameter("@BasePrice", SqlDbType.Decimal));
                    command.Parameters.Add(new SqlParameter("@MaxPrice", SqlDbType.Decimal));
                    //command.Parameters.Add("@EventID", SqlDbType.Int).Value = e.ID; // I'm not certain as to whether you can daisy chain the
                                                                                        // addition to the parameter list and the value assignment.
                    command.Parameters["@EventID"].Value = e.ID;
                    command.Parameters["@Name"].Value = e.Name;
                    command.Parameters["@Date"].Value = e.Date;
                    command.Parameters["@Floor"].Value = e.Floor;
                    command.Parameters["@Level1"].Value = e.Level1;
                    command.Parameters["@Level2"].Value = e.Level2;
                    command.Parameters["@BasePrice"].Value = e.BasePrice;
                    command.Parameters["@MaxPrice"].Value = e.MaxPrice;

                    command.ExecuteNonQuery();
                    //connection.Close(); The using block will dispose of the connection for you
                }
            }
            
            return true;
        }
        #endregion
    }
}
