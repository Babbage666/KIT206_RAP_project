﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using KIT206_RAP_Project.Research;
using KIT206_RAP_Project.Control;
using KIT206_RAP_Project.Database;

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
                    ResearcherList.Add(new Researcher { GivenName = rdr.GetString(1), FamilyName=rdr.GetString(2), Id = rdr.GetInt32(0) });
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

            foreach (Researcher r1 in ResearcherList)
            {
                Console.WriteLine(r1);
                string PauseNow = Console.ReadLine();
                
            }

            return ResearcherList;

        }

        public Research.Researcher fetchFullResearcherDetails(int id)
        {
            return null;
        }

        public Research.Researcher completeResearcherDetails(Research.Researcher r)
        {
            return null;
        }

        

        public Research.Publication completePublicationDetails(Research.Publication p)
        {
            return null;
        }

        public List<int> PublicationDetails(DateTime from, DateTime to)
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
