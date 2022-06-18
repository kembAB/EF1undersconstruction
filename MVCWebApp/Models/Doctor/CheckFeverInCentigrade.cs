using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Doctor
{
    public class CheckFeverInCentigrade
    {
        public static string FeverCheck(int patientTemp)
        {
         
            //Temprature is defined as integer in centigrade 
            if (patientTemp >= 38)
            {
                return "Your body temprature is  " + patientTemp + "°C You have Fever!";
            }
            else if (patientTemp < 0)
            { 
                return "Your body temprature is  " + patientTemp + "°C which means you are frozen!!!"; 
            }

            else 
            {

             return "Your body temprature is  " + patientTemp + "°C You do not have Fever."; 
            }
              
        }
    }
}
