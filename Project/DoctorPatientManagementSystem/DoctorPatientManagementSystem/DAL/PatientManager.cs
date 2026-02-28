using DoctorPatientManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
namespace DoctorPatientManagementSystem.DAL
{
    public class PatientManager : IPatientManager
    {
        string connStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public void AddPatientToDB(int doctorId)
        {
            Console.Write("Patient Name: ");
            string name = Console.ReadLine()??"";

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine()??"");

            Console.Write("Condition: ");
            string condition = Console.ReadLine()??"";

            using SqlConnection con = new SqlConnection(connStr);
            string query = @"INSERT INTO Patients 
                         VALUES(@n,@a,@c,GETDATE(),@d)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@a", age);
            cmd.Parameters.AddWithValue("@c", condition);
            cmd.Parameters.AddWithValue("@d", doctorId);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Patient added.");
        }

        public void ListPatientsFromDB()
        {
            using SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Patients", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["PatientId"]} - {dr["Name"]} - DoctorId:{dr["DoctorId"]}");
            }
        }

        public void DeletePatientFromDB()
        {
            Console.Write("PatientId: ");
            int id = int.Parse(Console.ReadLine()??"");

            using SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("DELETE FROM Patients WHERE PatientId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Patient deleted.");
        }

       
        public void AddPatient(int doctorId) => AddPatientToDB(doctorId);
        public void EditPatient() { }
        public void DeletePatient() => DeletePatientFromDB();
        public void ListPatients() => ListPatientsFromDB();
        public void FindPatient(string name) { }
        public void EditPatientInDB() { }
    }
}
