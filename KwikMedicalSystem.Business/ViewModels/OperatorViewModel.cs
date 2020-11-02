using KwikMedicalSystem.Business.Commands;
using KwikMedicalSystem.DAL;
using KwikMedicalSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KwikMedicalSystem.Business.ViewModels
{
    public class OperatorViewModel : BaseViewModel
    {
        private bool debug = false;

        private Patient patient;
        private IncidentReport incident;
        private string patientNHSNumber;
        
        public Patient Patient
        {
            get => patient;
            set
            {
                patient = value;

                if(!debug)
                {
                    OnChanged(nameof(Patient));
                }
            }
        }       
        
        public IncidentReport Incident
        {
            get => incident;
            set
            {
                incident = value;

                if(!debug)
                {
                    OnChanged(nameof(Incident));
                }
            }
        }

        public string NHSNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string MedicalCondition { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; }
        public string AssignedHospitalID { get; set; }

        public string PatientNHSNumber
        { 
            get => patientNHSNumber; 
            set
            {
                patientNHSNumber = value;

                if (!debug)
                {
                    OnChanged(nameof(PatientNHSNumber));
                }
            }
        }

        public ICommand SearchAddPatient { get; private set; }
        public ICommand SendIncident { get; private set; }
        public ICommand ClearIncident { get; private set; }

        public OperatorViewModel()
        {
            SearchAddPatient = new RelayCommand(SearchAddingPatientButtonClick);
            SendIncident = new RelayCommand(SendIncidentButtonClick);
            ClearIncident = new RelayCommand(ClearIncidentButtonClick);
        }

        private void SearchAddingPatientButtonClick()
        {
            Patient = DatabaseOperations.SearchPatient(Convert.ToInt32(NHSNumber));

            if (Patient == null)
            {
                Patient = new Patient(Convert.ToInt32(NHSNumber), FirstName, LastName, DOB, Address, MedicalCondition);
                DatabaseOperations.AddNewPatient(Patient);
                PatientNHSNumber = patient.NHSNumber.ToString();
            }

            NHSNumber = Patient.NHSNumber.ToString();
            FirstName = Patient.FirstName;
            LastName = Patient.LastName;
            DOB = Patient.DOB;
            Address = Patient.Address;
            MedicalCondition = MedicalCondition;
            PatientNHSNumber = patient.NHSNumber.ToString();
            IncidentDate = DateTime.Now;

            OnChanged(nameof(NHSNumber));
            OnChanged(nameof(FirstName));
            OnChanged(nameof(LastName));
            OnChanged(nameof(DOB));
            OnChanged(nameof(Address));
            OnChanged(nameof(MedicalCondition));
            OnChanged(nameof(PatientNHSNumber));
            OnChanged(nameof(IncidentDate));
        }

        private void ClearIncidentButtonClick()
        {
            NHSNumber = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            DOB = default;
            Address = string.Empty;
            MedicalCondition = string.Empty;
            Location = string.Empty;
            PatientNHSNumber = string.Empty;
            AssignedHospitalID = string.Empty;

            OnChanged(nameof(NHSNumber));
            OnChanged(nameof(FirstName));
            OnChanged(nameof(LastName));
            OnChanged(nameof(DOB));
            OnChanged(nameof(Address));
            OnChanged(nameof(MedicalCondition));
            OnChanged(nameof(Location));
            OnChanged(nameof(PatientNHSNumber));
            OnChanged(nameof(AssignedHospitalID));
        }

        private void SendIncidentButtonClick()
        {
            Incident = new IncidentReport(Convert.ToInt32(PatientNHSNumber), AssignedHospitalID, false, Location);
            IncidentDate = DateTime.Now;
            Incident.IncidentDate = IncidentDate;
            DatabaseOperations.AddNewIncident(Incident);
            ClearIncidentButtonClick();
        }

    }
}
