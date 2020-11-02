using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalSystem.DAL.Models
{
    public class IncidentReport
    {
        public IncidentReport() { }
        public IncidentReport(int patientNHSNumber, string assignedHospitalID, bool caseClosed, string location)
        {
            PatientNHSNumber = patientNHSNumber;
            AssignedHospitalID = assignedHospitalID;
            CaseClosed = caseClosed;
            Location = location;
        }

        public int IncidentID { get;}
        public int PatientNHSNumber { get; set; }
        public string IncidentDetails { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; }
        public string ActionTaken { get; set; }
        public float WaitingTime { get; set; }
        public string AssignedHospitalID { get; set; }
        public string AssignedAmbulanceID { get; set; }
        public bool CaseClosed { get; set; }

        public override string ToString()
        {
            return "Incident ID: " + IncidentID + "\nPatient NHS Number: " + PatientNHSNumber
                + "\nDetails: " + IncidentDetails + "\nLocation: " + Location +
                "\nActionTaken: " + ActionTaken + "\tWaiting Time: " + WaitingTime +
                "\nAssigned Hospital ID: " + AssignedHospitalID +
                "\nAssigned Ambulance ID: " + AssignedAmbulanceID + "\nCase CLosed: " + CaseClosed;
        }
    }
}
