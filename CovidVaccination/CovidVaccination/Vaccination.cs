using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccination
{
    /// <summary>
    /// We include the enum datatype for vaccinetype, properties for vaccination class.
    /// </summary>
    public enum Vaccinetype
    {
        Covisheild = 1,
        covaxine,
        sputnik
    }
    public class Vaccination
    {
        public int id { get; set; }
        public string Vaccinename { get; set; }
        public int dosage { get; set; }
        public DateTime date { get; set; }
    }

}
