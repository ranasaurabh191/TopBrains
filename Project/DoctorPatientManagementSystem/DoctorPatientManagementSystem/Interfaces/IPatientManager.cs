using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatientManagementSystem.Interfaces
{
    public interface IPatientManager
    {
        void AddPatient(int doctorId);
        void EditPatient();
        void DeletePatient();
        void ListPatients();
        void FindPatient(string patientName);

        // DB operations
        void AddPatientToDB(int doctorId);
        void EditPatientInDB();
        void DeletePatientFromDB();
        void ListPatientsFromDB();
    }
}
