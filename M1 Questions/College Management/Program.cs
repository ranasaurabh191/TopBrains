// Q) Make a collage management system which has the following function 

// 1. addStudent(string studentId, string subject, int marks) -> This function should add a entry for the student in with subject and marks. If student is already registered for that subject update entry only if marks are greater than the previous marks.

// 2. removeStudent(string studentId) -> This function should remove respective student details

// 3. topSubject(string subject) -> This function should return the topper of that subject. If there is an tie then display the students in the order they were inserted.

// 4. result() -> This function should print all the student's average marks across all the subject.

// Sample Input:

// ADD S1 Math 80
// ADD S2 Math 90
// ADD S3 Math 90
// ADD S1 Phy 90
// TOP Math
// RESULT
// REMOVE S1

// Sample Output:

// S2 90
// S3 90
// S1 85.00
// S2 90.00
// S3 90.00



public class Program
{
    class CollageManagement
    {
        Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();


        Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        public int AddStudent(string studentId, string subject, int marks)
        {
            if (!studentRecords.ContainsKey(studentId))
            {
                studentRecords[studentId] = new Dictionary<string, int>();
                studentSubjectsOrder[studentId] = new LinkedList<KeyValuePair<string, int>>();
            }
            if (!studentRecords[studentId].ContainsKey(subject))
            {
                studentRecords[studentId][subject] = marks;
                studentSubjectsOrder[studentId].AddLast(
                    new KeyValuePair<string, int>(subject, marks));
            }
            else if (marks > studentRecords[studentId][subject])
            {
                studentRecords[studentId][subject] = marks;

                var node = studentSubjectsOrder[studentId].First;
                while (node != null)
                {
                    if (node.Value.Key == subject)
                    {
                        node.Value = new KeyValuePair<string, int>(subject, marks);
                        break;
                    }
                    node = node.Next;
                }
            }

            if (!subjectsRecords.ContainsKey(subject))
            {
                subjectsRecords[subject] = new Dictionary<string, int>();
                subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();
            }

            if (!subjectsRecords[subject].ContainsKey(studentId))
            {
                subjectsRecords[subject][studentId] = marks;
                subjectsStudentsOrder[subject].AddLast(
                    new KeyValuePair<string, int>(studentId, marks));
            }
            else if (marks > subjectsRecords[subject][studentId])
            {
                subjectsRecords[subject][studentId] = marks;

                var node = subjectsStudentsOrder[subject].First;
                while (node != null)
                {
                    if (node.Value.Key == studentId)
                    {
                        node.Value = new KeyValuePair<string, int>(studentId, marks);
                        break;
                    }
                    node = node.Next;
                }
            }

            return 1;
        }

        public int RemoveStudent(string studentId)
        {
            if (!studentRecords.ContainsKey(studentId))
                return 0;

            foreach (var subject in studentRecords[studentId].Keys)
            {
                subjectsRecords[subject].Remove(studentId);

                var node = subjectsStudentsOrder[subject].First;
                while (node != null)
                {
                    if (node.Value.Key == studentId)
                    {
                        subjectsStudentsOrder[subject].Remove(node);
                        break;
                    }
                    node = node.Next;
                }
            }

            studentRecords.Remove(studentId);
            studentSubjectsOrder.Remove(studentId);

            return 1;
        }

        public string TopStudent(string subject)
        {
            if (!subjectsRecords.ContainsKey(subject))
                return "";

            int maxMarks = subjectsRecords[subject].Values.Max();
            List<string> res = new();

            foreach (var kv in subjectsStudentsOrder[subject])
            {
                if (kv.Value == maxMarks)
                    res.Add($"{kv.Key} {kv.Value}");
            }

            return string.Join("\n", res);
        }

        public string Result()
        {
            List<string> res = new();

            foreach (var student in studentSubjectsOrder)
            {
                double avg = student.Value.Average(x => x.Value);
                res.Add($"{student.Key} {avg:F2}");
            }

            return string.Join("\n", res);
        }
    }

    public static void Main()
    {
        CollageManagement cm = new();
        string input;

        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            string[] parts = input.Split(' ');
            string command = parts[0];

            switch (command)
            {
                case "ADD":
                    cm.AddStudent(parts[1], parts[2], int.Parse(parts[3]));
                    break;

                case "REMOVE":
                    cm.RemoveStudent(parts[1]);
                    break;

                case "TOP":
                    Console.WriteLine(cm.TopStudent(parts[1]));
                    break;

                case "RESULT":
                    Console.WriteLine(cm.Result());
                    break;
            }
        }
    }
}