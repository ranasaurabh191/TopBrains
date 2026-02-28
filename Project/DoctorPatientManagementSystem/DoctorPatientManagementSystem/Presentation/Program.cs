using DoctorPatientManagementSystem.BLL;
using DoctorPatientManagementSystem.DAL;
using DoctorPatientManagementSystem.Interfaces;

class Program
{
    static void Main()
    {
        IDoctorManager doctorDAL = new DoctorManager();
        IPatientManager patientDAL = new PatientManager();

        DoctorsBLL doctorBLL = new DoctorsBLL(doctorDAL);
        PatientsBLL patientBLL = new PatientsBLL(patientDAL);

        while (true)
        {
            Console.WriteLine("\n1.Add Doctor\n2.List Doctors\n3.Add Patient\n4.List Patients\n5.Exit");
            int choice = int.Parse(Console.ReadLine()??"");

            switch (choice)
            {
                case 1:
                    doctorBLL.AddDoctor();
                    break;

                case 2:
                    doctorBLL.ShowDoctors();
                    break;

                case 3:
                    Console.Write("Doctor Id: ");
                    int did = int.Parse(Console.ReadLine()??"");
                    patientBLL.AddPatient(did);
                    break;

                case 4:
                    patientBLL.ShowPatients();
                    break;

                case 5:
                    return;
            }
        }
    }
}