using DoctorPatientManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatientManagementSystem.BLL
{
    public class PatientsBLL
    {
        private readonly IPatientManager _manager;

        public PatientsBLL(IPatientManager manager)
        {
            _manager = manager;
        }

        public void AddPatient(int doctorId)
        {
            if (doctorId <= 0)
            {
                Console.WriteLine("Invalid Doctor Id");
                return;
            }
            _manager.AddPatient(doctorId);
        }

        public void ShowPatients()
        {
            _manager.ListPatients();
        }
    }
}
