using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CampusHireApp
{
    public static class FileStorage
    {
        private static readonly string filePath = "Applicants.json";

        public static void Save(List<Applicant> applicants)
        {
            var json = JsonSerializer.Serialize(applicants, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }

        public static List<Applicant> Load()
        {
            if (!File.Exists(filePath))
                return new List<Applicant>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Applicant>>(json) ?? new List<Applicant>();
        }
    }
}
