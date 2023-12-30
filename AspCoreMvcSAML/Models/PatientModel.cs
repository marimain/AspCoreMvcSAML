using System;
using System.Collections.Generic;

namespace AspCoreMvcSAML.Models
{
    public class PatientViewModel
    {
        public PatientViewModel()
        {
            Patients = new List<PatientModel>()
            {

                new PatientModel { PatientID = 100, FirstName = "John", LastName = "Smith", DOB = Convert.ToDateTime("2/1/2022") } ,
                new PatientModel { PatientID = 200, FirstName = "Trinity", LastName = "Lin", DOB = Convert.ToDateTime("12/24/1987") },
                new PatientModel { PatientID = 300, FirstName = "Muhammed", LastName = "Church", DOB = Convert.ToDateTime("5/4/1997") },
                new PatientModel { PatientID = 400, FirstName = "Maisy", LastName = "George", DOB = Convert.ToDateTime("6/15/1954") }

            };
        }

        public IEnumerable<PatientModel> Patients { get; set; }

    }
    public class PatientModel
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
}
