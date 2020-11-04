using Dapper;
using KwikMedicalSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalSystem.DAL
{
    public class DatabaseOperations
    {
        public static Patient SearchPatient(int nhsNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KwikMedicalDB")))
            {
                var patient = connection.Query<Patient>($"select * from Patients where NHSNumber='{nhsNumber}'");
                
                if(patient != null)
                {
                    return patient.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }

        public static void AddNewPatient(Patient patient)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KwikMedicalDB")))
            {
                string sql = "INSERT INTO Patients (NHSNumber, FirstName, LastName, DOB, Address, MedicalCondition) " +
                    "Values (@NHSNumber, @FirstName, @LastName, @DOB, @Address, @MedicalCondition);";
                connection.Execute(sql, patient);
            }
        }

        public static void AddNewIncident(IncidentReport incident)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KwikMedicalDB")))
            {
                string sql = "INSERT INTO IncidentReports (PatientNHSNumber, IncidentDate, Location, AssignedHospitalID, CaseClosed) " +
                    "Values (@PatientNHSNumber, @IncidentDate, @Location, @AssignedHospitalID, @CaseClosed);";
                connection.Execute(sql, incident);
            }
        }

        public static List<IncidentReport> GetAllIncidentsList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KwikMedicalDB")))
            {
                var incidentsList = connection.Query<IncidentReport>($"select * from IncidentReports");

                if (incidentsList != null)
                {
                    return incidentsList.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static void UpdateIncidentReportRecord(IncidentReport incidentReport)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KwikMedicalDB")))
            {
                string updateQuery = @"UPDATE IncidentReports SET IncidentDetails = @IncidentDetails, Location = @Location,
                                     IncidentDate = @IncidentDate, ActionTaken = @ActionTaken, WaitingTime = @WaitingTime,
                                     AssignedAmbulanceID = @AssignedAmbulanceID, PatientNHSNumber = @PatientNHSNumber
                                     WHERE IncidentID = @IncidentID";

                connection.Execute(updateQuery, incidentReport);
            }
        }

        public static IncidentReport SearchIncident(string assignedAmbulanceID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KwikMedicalDB")))
            {
                var incident = connection.Query<IncidentReport>($"select * from IncidentReports where AssignedAmbulanceID='{assignedAmbulanceID}' AND CaseClosed = 0");

                if (incident != null)
                {
                    return incident.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }

        public static void UpdatePatientRecord(Patient patient)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("KwikMedicalDB")))
            {
                string updateQuery = @"UPDATE Patients SET NHSNumber = @NHSNumber, FirstName = @FirstName,
                                     LastName = @LastName, DOB = @DOB, Address = @Address,
                                     MedicalCondition = @MedicalCondition
                                     WHERE PatientID = @PatientID";

                connection.Execute(updateQuery, patient);
            }
        }
    }
}
