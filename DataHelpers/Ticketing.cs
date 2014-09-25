using DataHelpers.Objects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataHelpers
{
    public class Ticketing
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
        {
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
        {
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

        public DataTable GetUnavailableSeats(int EventID, int Level, string Section, int Row)
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
    }
}
