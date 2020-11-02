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
    }
}
