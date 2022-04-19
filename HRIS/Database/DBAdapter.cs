using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using HRIS.Entities;

namespace HRIS.Database
{
    public class DBAdapter
    {
        private const string db = "hris";
        private const string user = "kit206g14a";
        private const string pass = "group14a";
        private const string server = "alacritas.cis.utas.edu.au";

		private static MySqlConnection conn = null;

		private static MySqlConnection GetConnection()
		{
			if (conn == null)
			{
				//Note: This approach is not thread-safe
				string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
				conn = new MySqlConnection(connectionString);
			}
			return conn;
		}
		

		// Convert string to enum
		public static T ParseEnum<T>(string value)
		{
			return (T)Enum.Parse(typeof(T), value, true);
		}


		public static List<Unit> GetUnitDetails()
		{
			MySqlDataReader rdr = null;
			MySqlConnection conn = GetConnection();
			var unit = new List<Unit>();

			try
			{
				conn.Open();
				var command = new MySqlCommand("SELECT code, title, coordinator FROM unit", conn);
				rdr = command.ExecuteReader();

				while (rdr.Read())
				{

					// fill in additional data
					unit.Add(new Unit
					{	
						Code = rdr.GetString(0),
						Title = rdr.GetString(1),
						Coordinator = rdr.GetInt32(2)

					});


				}
					
			}
			finally
			{
				rdr.Close();
				conn.Close();
			}

			return unit;
		}

		public static List<Staff> GetStaffDetails()
		{
			MySqlDataReader rdr = null;
			MySqlConnection conn = GetConnection();

			var staff = new List<Staff>();

			try
			{
				conn.Open();
				var command = new MySqlCommand("SELECT id, given_name, family_name, title, campus FROM staff", conn);
				rdr = command.ExecuteReader();

				while (rdr.Read())
				{

					// fill in additional data
					staff.Add(new Staff
					{	
						ID = rdr.GetInt32(0),
						GivenName = rdr.GetString(1),
						FamilyName = rdr.GetString(2),
						Title = rdr.GetString(3),
						Campus = ParseEnum<Campus>(rdr.GetString(4))
				

					});

				}

			}
			finally
			{
				rdr.Close();
				conn.Close();
			}

			return staff;


		}

		public static List<Consultation> GetConsultationDetails()
		{
			MySqlDataReader rdr = null;
			MySqlConnection conn = GetConnection();
			var consult = new List<Consultation>();

			try
			{
				conn.Open();
				var command = new MySqlCommand("SELECT staff_id, day, start, end FROM consultation", conn);
				rdr = command.ExecuteReader();

				while (rdr.Read())
				{

					// fill in additional data
					consult.Add(new Consultation
					{
						ID = rdr.GetInt32(0),
						Day = ParseEnum<DayOfWeek>(rdr.GetString(1)),
						Start = rdr.GetTimeSpan(2),
						End = rdr.GetTimeSpan(3)

					});


				}

			}
			finally
			{
				rdr.Close();
				conn.Close();
			}

			return consult;
		}

		public static List<UnitClass> GetClassDetails()
        {
			MySqlDataReader rdr = null;
			MySqlConnection conn = GetConnection();

			var classList = new List<UnitClass>();

			try
			{
				conn.Open();
				var command = new MySqlCommand("SELECT unit_code, campus, day, start, end, type, room FROM class", conn);
				rdr = command.ExecuteReader();

				while (rdr.Read())
				{

					// fill in additional data
					classList.Add(new UnitClass
					{
						UnitCode = rdr.GetString(0),
						Campus = ParseEnum<Campus>(rdr.GetString(1)),
						Day = ParseEnum<DayOfWeek>(rdr.GetString(2)),
						Start = rdr.GetTimeSpan(3),
						End = rdr.GetTimeSpan(4),
						Type = ParseEnum<ClassType>(rdr.GetString(5)),
						Room = rdr.GetString(6)



					});

				}

			}
			finally
			{
				rdr.Close();
				conn.Close();
			}

			return classList;


		}		
	}
}