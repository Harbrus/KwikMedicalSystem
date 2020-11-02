using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalSystem.DAL.Models
{
    public class Patient
    {
        public Patient() { }
        public Patient(int nHSNumber, string firstName, string lastName, 
            DateTime dOB, string address, string medicalCondition)
        {
            NHSNumber = nHSNumber;
            FirstName = firstName;
            LastName = lastName;
            DOB = dOB;
            Address = address;
            MedicalCondition = medicalCondition;
        }

        public int PatientId { get;}
        public int NHSNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string MedicalCondition { get; set; }

        public override string ToString()
        {
            return "PatientID: " + PatientId + "\tNHSNumber: " + NHSNumber
                + "\tFirst Name: " + FirstName + "\tLastName: " + LastName + 
                "\tDOB: " + DOB.ToShortDateString() + "\tAddress: " + Address + "\tMedical Condition: " + MedicalCondition; 
        }
    }
}
