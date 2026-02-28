using DoctorPatientManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorPatientManagementSystem.BLL
{
    public class DoctorsBLL
    {
        private readonly IDoctorManager _manager;

        public DoctorsBLL(IDoctorManager manager)
        {
            _manager = manager;
        }

        public void AddDoctor()
        {
            _manager.AddDoctor();
        }

        public void ShowDoctors()
        {
            _manager.ListDoctors();
        }
    }
}
