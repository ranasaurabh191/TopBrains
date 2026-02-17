using System.Collections.Generic;
using System.Linq;

public class EmergencyQueueManager
{
    private const int MAX_QUEUE_SIZE = 5;

    private SortedDictionary<int, Queue<Patient>> queues = new SortedDictionary<int, Queue<Patient>>();

    public void AddPatient(Patient patient)
    {
        if (!queues.ContainsKey(patient.Severity)) queues[patient.Severity] = new Queue<Patient>();

        if (queues[patient.Severity].Count >= MAX_QUEUE_SIZE) throw new QueueOverflowException($"Queue full for severity {patient.Severity}");

        queues[patient.Severity].Enqueue(patient);
    }

    public Patient GetNextPatient()
    {
        if (queues.Count == 0) throw new PatientNotFoundException("No patients available");

        foreach (var queue in queues.Values)
        {
            if (queue.Count > 0) return queue.Dequeue();
        }

        throw new PatientNotFoundException("No patients available");
    }

    public void RemovePatient(string patientId)
    {
        foreach (var queue in queues.Values)
        {
            var patient = queue.FirstOrDefault(p => p.Id == patientId);
            if (patient != null)
            {
                var tempQueue = new Queue<Patient>();

                while (queue.Count > 0)
                {
                    var p = queue.Dequeue();
                    if (p.Id != patientId)
                        tempQueue.Enqueue(p);
                }

                while (tempQueue.Count > 0)
                    queue.Enqueue(tempQueue.Dequeue());

                return;
            }
        }

        throw new PatientNotFoundException("Patient not found");
    }
}
