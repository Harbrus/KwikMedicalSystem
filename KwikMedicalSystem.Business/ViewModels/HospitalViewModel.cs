using KwikMedicalSystem.Business.Commands;
using KwikMedicalSystem.DAL;
using KwikMedicalSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KwikMedicalSystem.Business.ViewModels
{
    public class HospitalViewModel : BaseViewModel
    {
        private bool debug = false;

        private Patient patient;
        private IncidentReport selectedIncident;

        private ObservableCollection<IncidentReport> incidentLists;
        private string patientNHSNumber;
        private string incidentDetails;
        private string waitingTime;
        private string assignedAmbulanceID;
        private string actionTaken;
        private DateTime incidentDate;
        private string location;
        private string nhsNumber;
        private string firstName;
        private string lastName;
        private DateTime dob;
        private string address;
        private string medicalCondition;

        public Patient Patient
        {
            get => patient;
            set
            {
                patient = value;

                if (!debug)
                {
                    OnChanged(nameof(Patient));
                }
            }
        }
        public IncidentReport IncidentReport { get; set; }

        public IncidentReport SelectedIncident
        {
            get => selectedIncident;
            set
            {
                selectedIncident = value;

                if (selectedIncident != null)
                {
                    PatientNHSNumber = selectedIncident.PatientNHSNumber.ToString();
                    IncidentDetails = selectedIncident.IncidentDetails;
                    WaitingTime = selectedIncident.WaitingTime.ToString();
                    AssignedAmbulanceID = selectedIncident.AssignedAmbulanceID;
                    IncidentDate = selectedIncident.IncidentDate;
                    Location = selectedIncident.Location;
                    ActionTaken = selectedIncident.ActionTaken;

                    Patient = DatabaseOperations.SearchPatient(selectedIncident.PatientNHSNumber);
                    NHSNumber = Patient.NHSNumber.ToString();
                    FirstName = Patient.FirstName;
                    LastName = Patient.LastName;
                    DOB = Patient.DOB;
                    Address = Patient.Address;
                    MedicalCondition = Patient.MedicalCondition;
                }

                if (!debug)
                {
                    OnChanged(nameof(SelectedIncident));
                }
            }
        }

        public ObservableCollection<IncidentReport> IncidentsList
        {
            get => incidentLists;
            set
            {
                incidentLists = value;
            }
        }

        public void PopulateIncidentsList()
        {
            List<IncidentReport> incidents = DatabaseOperations.GetAllIncidentsList();

            IncidentsList.Clear();

            foreach (var incident in incidents)
            {
                IncidentsList.Add(incident);
            }

            incidents.Clear();
        }

        public string PatientNHSNumber
        {
            get => patientNHSNumber;
            set
            {
                patientNHSNumber = value;
                OnChanged(nameof(PatientNHSNumber));
            }
        }
        public string IncidentDetails
        {
            get => incidentDetails;
            set
            {
                incidentDetails = value;
                OnChanged(nameof(IncidentDetails));
            }
        }
        public string WaitingTime
        {
            get => waitingTime;
            set
            {
                waitingTime = value;
                OnChanged(nameof(WaitingTime));
            }
        }
        public string AssignedAmbulanceID
        {
            get => assignedAmbulanceID;
            set
            {
                assignedAmbulanceID = value;
                OnChanged(nameof(AssignedAmbulanceID));
            }
        }
        public string ActionTaken
        {
            get => actionTaken;
            set
            {
                actionTaken = value;
                OnChanged(nameof(ActionTaken));
            }
        }
        public DateTime IncidentDate
        {
            get => incidentDate;
            set
            {
                incidentDate = value;
                OnChanged(nameof(IncidentDate));
            }
        }
        public string Location
        {
            get => location;
            set
            {
                location = value;
                OnChanged(nameof(Location));
            }
        }

        public string NHSNumber
        {
            get => nhsNumber;
            set
            {
                nhsNumber = value;
                OnChanged(nameof(NHSNumber));
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnChanged(nameof(NHSNumber));
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnChanged(nameof(NHSNumber));
            }
        }
        public DateTime DOB
        {
            get => dob;
            set
            {
                dob = value;
                OnChanged(nameof(NHSNumber));
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnChanged(nameof(NHSNumber));
            }
        }
        public string MedicalCondition
        {
            get => medicalCondition;
            set
            {
                medicalCondition = value;
                OnChanged(nameof(NHSNumber));
            }
        }

        public ICommand SendAmbulance { get; private set; }
        public ICommand ClearIncident { get; private set; }
        public ICommand RefreshIncidentsList { get; private set; }
        public ICommand UpdatePatient { get; private set; }

        public HospitalViewModel()
        {
            IncidentsList = new ObservableCollection<IncidentReport>();
            SendAmbulance = new RelayCommand(SendAmbulanceButtonClick);
            ClearIncident = new RelayCommand(ClearIncidentButtonClick);
            RefreshIncidentsList = new RelayCommand(RefreshIncidentListButtonClick);
            UpdatePatient = new RelayCommand(UpdatePatientButtonClick);
            PopulateIncidentsList();
        }

        private void UpdatePatientButtonClick()
        {
            if(Patient == null)
            {
                return;
            }

            Patient.NHSNumber = Convert.ToInt32(NHSNumber);
            Patient.FirstName = FirstName;
            Patient.LastName = LastName;
            Patient.DOB = DOB;
            Patient.Address = Address;
            Patient.MedicalCondition = MedicalCondition;

            DatabaseOperations.UpdatePatientRecord(Patient);

            NHSNumber = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            DOB = default;
            Address = string.Empty;
            MedicalCondition = string.Empty;

            OnChanged(nameof(NHSNumber));
        }

        private void RefreshIncidentListButtonClick()
        {
            PopulateIncidentsList();
        }

        private void ClearIncidentButtonClick()
        {
            PatientNHSNumber = string.Empty;
            IncidentDetails = string.Empty;
            Location = string.Empty;
            IncidentDate = default;
            ActionTaken = string.Empty;
            WaitingTime = string.Empty;
            AssignedAmbulanceID = string.Empty;
            SelectedIncident = null;
        }

        private void SendAmbulanceButtonClick()
        {
            if (SelectedIncident != null && !SelectedIncident.CaseClosed)
            {
                IncidentReport = SelectedIncident;

                IncidentReport.PatientNHSNumber = Convert.ToInt32(PatientNHSNumber);
                IncidentReport.IncidentDetails = IncidentDetails;
                IncidentReport.Location = Location;
                IncidentReport.IncidentDate = IncidentDate;
                IncidentReport.ActionTaken = ActionTaken;
                IncidentReport.WaitingTime = float.Parse(WaitingTime);
                IncidentReport.AssignedAmbulanceID = AssignedAmbulanceID;

                DatabaseOperations.UpdateIncidentReportRecord(IncidentReport);

                ClearIncidentButtonClick();
            }
        }
    }
}
