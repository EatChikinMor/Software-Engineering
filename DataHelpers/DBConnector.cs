using DataHelpers.Objects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms; //temporary debugging use

namespace DataHelpers
{
    public class DBConnector
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

        #region Code added by Judson for things he needs the DBC to do
        public string getPass(string userName) //get user's password from db
        {
            string mPass = "TemporaryPassword";

            using (SqlConnection connection = new SqlConnection(_TicketingConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("getPass", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar));

                    command.Parameters["@userName"].Value = userName;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        mPass = reader.GetString(0);
                    }
                }
            }            
            return mPass;
        }

        public bool setSession(string userName, bool truths) //update session table with login/out info
        { 
            DateTime mDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(_TicketingConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("setSession", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@userID", SqlDbType.UniqueIdentifier));
                    command.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@dateAndTime", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@sessionCurrent", SqlDbType.Bit));

                    command.Parameters["@userID"].Value = getUserID(userName);
                    command.Parameters["@userName"].Value = userName;
                    command.Parameters["@dateAndTime"].Value = mDate;
                    command.Parameters["@sessionCurrent"].Value = truths;

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
        private Guid getUserID(string userName) //get user's ID from db for session information
        {
            Guid mUserID = Guid.Empty;

            using (SqlConnection connection = new SqlConnection(_TicketingConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("getUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@userName", SqlDbType.NVarChar));

                    command.Parameters["@userName"].Value = userName;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        mUserID = (Guid)reader.GetValue(0);
                    }
                }
            }
            return mUserID;
        }
        public bool save(Event e) //save event to db
        {
            using (SqlConnection connection = new SqlConnection(_TicketingConnection))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("saveEvent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@eID", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@Floor", SqlDbType.Bit));
                    command.Parameters.Add(new SqlParameter("@Level1", SqlDbType.Bit));
                    command.Parameters.Add(new SqlParameter("@Level2", SqlDbType.Bit));
                    command.Parameters.Add(new SqlParameter("@BasePrice", SqlDbType.Decimal));
                    command.Parameters.Add(new SqlParameter("@MaxPrice", SqlDbType.Decimal));
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));

                    command.Parameters["@eID"].Value = e.ID;
                    command.Parameters["@Date"].Value = e.Date;
                    command.Parameters["@Floor"].Value = e.Floor;
                    command.Parameters["@Level1"].Value = e.Level1;
                    command.Parameters["@Level2"].Value = e.Level2;
                    command.Parameters["@BasePrice"].Value = e.BasePrice;
                    command.Parameters["@MaxPrice"].Value = e.MaxPrice;
                    command.Parameters["@Name"].Value = e.Name;

                    command.ExecuteNonQuery();
                }
            }            
            return true;
        }
        #endregion

        public void StoreRequestReturns(Guid ticketNo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_RequestReturns", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ticketNo", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@ticketNo"].Value = ticketNo;

                    sqlCommand.ExecuteNonQuery();
                }
                
            }
        }

        public DataTable GetTickets()
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Get_Requested_Returns", sqlConnection))
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

        public void StoreApprovedRequest(Guid approve_ticket)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Approve_Returns", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ticketNo", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@ticketNo"].Value = approve_ticket;

                    sqlCommand.ExecuteNonQuery();
                }

            }
        }

        public void StoreRejectRequest(Guid reject_ticket)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(_TicketingConnection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("USP_Reject_Returns", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ticketNo", SqlDbType.UniqueIdentifier));
                    sqlCommand.Parameters["@ticketNo"].Value = reject_ticket;

                    sqlCommand.ExecuteNonQuery();
                }

            }
        }

    }
}
