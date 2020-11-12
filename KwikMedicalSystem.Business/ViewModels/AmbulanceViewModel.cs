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
    public class AmbulanceViewModel : BaseViewModel
    {
        private string incidentDetails;
        private string waitingTime;
        private string assignedAmbulanceID;
        private string actionTaken;
        private DateTime incidentDate;
        private string location;
        private bool caseClosed;

        public IncidentReport Incident { get; set; }

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
        public bool CaseClosed
        {
            get => caseClosed;
            set
            {
                caseClosed = value;
                OnChanged(nameof(CaseClosed));
            }
        }

        public ICommand SearchIncident { get; private set; }
        public ICommand ClearIncident { get; private set; }
        public ICommand SendDetails { get; private set; }

        public AmbulanceViewModel()
        {
            Incident = new IncidentReport();
            SearchIncident = new RelayCommand(SearchIncidentButtonClick);
            ClearIncident = new RelayCommand(ClearIncidentButtonClick);
            SendDetails = new RelayCommand(SendDetailsButtonClick);
        }

        private void SendDetailsButtonClick()
        {
            if (Incident != null)
            {
                Incident.IncidentDetails = IncidentDetails;
                Incident.Location = Location;
                Incident.ActionTaken = ActionTaken;
                Incident.WaitingTime = float.Parse(WaitingTime);
                Incident.IncidentDate = IncidentDate;
                Incident.CaseClosed = CaseClosed;

                DatabaseOperations.UpdateIncidentReportRecord(Incident);

                ClearIncidentButtonClick();

            }
        }

        private void SearchIncidentButtonClick()
        {
            Incident = DatabaseOperations.SearchIncident(AssignedAmbulanceID);

            if(Incident != null)
            {
                IncidentDetails = Incident.IncidentDetails;
                Location = Incident.Location;
                ActionTaken = Incident.ActionTaken;
                WaitingTime = Incident.WaitingTime.ToString();
                IncidentDate = Incident.IncidentDate;
                CaseClosed = Incident.CaseClosed;
            }
        }

        private void ClearIncidentButtonClick()
        {
            AssignedAmbulanceID = string.Empty; 
            IncidentDetails = string.Empty;
            Location = string.Empty; ;
            ActionTaken = string.Empty; ;
            WaitingTime = string.Empty; ;
            IncidentDate = default;
            CaseClosed = false;
            Incident = null;
        }
    }
}
