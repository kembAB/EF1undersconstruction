using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models
{
   
    public class GuessingProperties
    {
        public int difference { get; set; }
        public int randomNumber { get; set; }
        [Required]
        [Range(0, 101, ErrorMessage = "The number is between 0 and 100.")]
        public int EnteredNum { get; set; }
        // perfect guess
        public bool Success { get; set; }
        public int playerGuess { get; set; }
        public bool ShowResult { get; set; }
        public int NumberOfAttempts { get; set; }
        public void GenerateRandomNumber()
        {
            var random = new Random();
            this.randomNumber = random.Next(1, 100);
        }
    }
}
