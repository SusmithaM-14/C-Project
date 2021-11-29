using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccination
{
    /// <summary>
    /// We include the enum datatype for Gender, properties for Benificiary class.
    /// </summary>
    public enum Gender
    {
        male = 1,
        female,
        unknown
    }
    //public string Gender(int gender)
    //{
    //    switch (gender)
    //    {
    //        case (int)Gender.male:
    //            return "male";
    //        case (int)Gender.female:
    //            return "Female";
    //        case (int)Gender.unknown:
    //            return "unknown";
    //        default:
    //            return "Invalid Data for Gender";
    //    }
    //}
    public class Benifiery
    {
       
        public int age{ get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string  city { get; set; }
        public long phonenum { get; set; }
        public int gender { get; set; }
    }
    
}
