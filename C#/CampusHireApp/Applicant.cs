using System;

namespace CampusHireApp
{
    [Serializable]
    public class Applicant
    {
        public string ApplicantId { get; set; }
        public string Name { get; set; }
        public string CurrentLocation { get; set; }
        public string PreferredLocation { get; set; }
        public string CoreCompetency { get; set; }
        public int PassingYear { get; set; }

        public override string ToString()
        {
            return $"ID: {ApplicantId}, Name: {Name}, Current: {CurrentLocation}, " +
                   $"Preferred: {PreferredLocation}, Skill: {CoreCompetency}, Year: {PassingYear}";
        }
    }
}
