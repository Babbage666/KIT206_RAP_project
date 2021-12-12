using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace KIT206_RAP_Project.Database
{
    class ERDAdapater
    {

        public static MySqlConnection conn { get; set; }
        static string db = "kit206";
        static string user = "kit206";
        static string pass = "kit206";
        static string server = "alacritas.cis.utas.edu.au";


        public List<Research.Researcher> fetchBasicResearcherDetails()
        {
            conn = GetConnection();
            List<Researcher> ResearcherList = new List<Researcher>();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ResearcherList.Add(new Researcher { Name = rdr.GetString(1) + ' ' + rdr.GetString(2), Id = rdr.GetInt32(0) });
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return TestList;

        }

        public Research.Researcher fetchFullResearcherDetails(int id)
        {
            return null;
        }

        public Research.Researcher completeResearcherDetails(Research.Researcher r)
        {
            return null;
        }

        public List<Research.Publication> fetchBasicPublicationDetails(Research.Researcher r)
        {
            conn = GetConnection();
            List<Publication> PubList = new List<Publication>();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select title, year, type, available " +
                 "from publication as pub, researcher_publication as respub " +
                 "where pub.doi = respub.doi and researcher_id=?id", conn);
                cmd.Parameters.AddWithValue("id", Id);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PubList.Add(new Publication
                        { Title = rdr.GetString(0), Year = rdr.GetInt32(1), Mode = Publication.ParseEnum<Publication.OutputType>(rdr.GetString(2)), Certified = rdr.GetDateTime(3)});
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return TestPubList;

            return null;
        }

        public Research.Publication completeResearcherDetails(Research.Publication p)
        {
            return null;
        }

        public List<int> completeResearcherDetails(DateTime from, DateTime to)
        {
            return null;
        }

        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2}; Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

    }
}
