﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace MainPage
{
    class CaseDAO
    {
        private string connectionString;


        public CaseDAO() {
           connectionString = ConfigurationManager.ConnectionStrings["MainPage.Properties.Settings.LocalDBConnectionString"].ConnectionString;
        }


        public Boolean checkIfCaseName(String caseName) {
            Boolean checker = false;

            using (SqlConnection myConnection = new SqlConnection(connectionString)) {
                string query = "SELECT COUNT(*) from Cases where C_Name=@caseName";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@caseName", caseName);
                myConnection.Open();

                int CaseNameExist = (int)cmd.ExecuteScalar();

                if (CaseNameExist > 0)
                {
                    checker = false;
                }
                else {
                    checker = true;
                }

            }

            return checker;


        }



        public Boolean addCaseToTable(String caseName, String caseDesc, ArrayList authors) {
            Boolean checker = false;

            Random rnd = new Random();
            int number = rnd.Next(1, 9999);
            String APath = "C:\\Users\\Public]Documents\\S" + number + ".txt";

            
            using (StreamWriter write = File.CreateText(@"C:\Users\Public\Documents\S" + number + ".txt"))
            {
             JsonSerializer serializer = new JsonSerializer();
             serializer.Serialize(write, authors);
                    
                    
             }

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {

            string query = "INSERT INTO Cases (C_Name,C_Authors_Path,C_Description) VALUES (@CaseName,@CAuthors,@CaseDesc)";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            cmd.Parameters.AddWithValue("@CaseName", caseName);
            cmd.Parameters.AddWithValue("@CAuthors", APath);
            cmd.Parameters.AddWithValue("@CaseDesc", caseDesc);
                   
             myConnection.Open();
             cmd.ExecuteScalar();
             myConnection.Close();

             checker = true;

             }

            
            


            return checker;
        }

        public Boolean deleteCaseFromTable(String caseName) {
            Boolean checker = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionString)) {

                    string query = "DELETE FROM Cases WHERE C_Name = @cName";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@cName", caseName);

                    myConnection.Open();
                    cmd.ExecuteScalar();
                    myConnection.Close();

                    checker = true;
                }


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);

            }


            return checker;

        }

        public Boolean updateToTable(Case cName, String PrevName) {
            Boolean checker = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Cases SET C_Name = @newName, C_Description = @newDesc where C_Name = @prevName";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@newName", cName.C_Name);
                    cmd.Parameters.AddWithValue("@newDEsc", cName.C_Desc);
                    cmd.Parameters.AddWithValue("@prevName", PrevName);

                    myConnection.Open();
                    cmd.ExecuteScalar();
                    myConnection.Close();

                    checker = true;

                }



            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


            return checker;

        }



    }
}