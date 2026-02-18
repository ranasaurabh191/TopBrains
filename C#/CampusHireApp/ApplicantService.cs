using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusHireApp
{
    public class ApplicantService
    {
        private List<Applicant> applicants;

        public ApplicantService()
        {
            applicants = FileStorage.Load();
        }

        public void AddApplicant(Applicant applicant)
        {
            ValidateApplicant(applicant);

            if (applicants.Any(a => a.ApplicantId == applicant.ApplicantId))
                throw new Exception("Applicant ID already exists.");

            applicants.Add(applicant);
            FileStorage.Save(applicants);
        }

        public List<Applicant> GetAllApplicants() => applicants;

        public Applicant SearchById(string id)
        {
            return applicants.FirstOrDefault(a => a.ApplicantId == id);
        }

        public void UpdateApplicant(Applicant updated)
        {
            var existing = SearchById(updated.ApplicantId);
            if (existing == null)
                throw new Exception("Applicant not found.");

            ValidateApplicant(updated);

            existing.Name = updated.Name;
            existing.CurrentLocation = updated.CurrentLocation;
            existing.PreferredLocation = updated.PreferredLocation;
            existing.CoreCompetency = updated.CoreCompetency;
            existing.PassingYear = updated.PassingYear;

            FileStorage.Save(applicants);
        }

        public void DeleteApplicant(string id)
        {
            var applicant = SearchById(id);
            if (applicant == null)
                throw new Exception("Applicant not found.");

            applicants.Remove(applicant);
            FileStorage.Save(applicants);
        }

        private void ValidateApplicant(Applicant a)
        {
            if (string.IsNullOrWhiteSpace(a.ApplicantId) ||
                string.IsNullOrWhiteSpace(a.Name) ||
                string.IsNullOrWhiteSpace(a.CurrentLocation) ||
                string.IsNullOrWhiteSpace(a.PreferredLocation) ||
                string.IsNullOrWhiteSpace(a.CoreCompetency))
                throw new Exception("All fields are mandatory.");

            if (!a.ApplicantId.StartsWith("CH") || a.ApplicantId.Length != 8)
                throw new Exception("Applicant ID must start with 'CH' and be 8 characters long.");

            if (a.Name.Length < 4 || a.Name.Length > 15)
                throw new Exception("Applicant Name must be 4–15 characters.");

            if (a.PassingYear > DateTime.Now.Year)
                throw new Exception("Passing year cannot be greater than current year.");
        }
    }
}
