using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCWebApp.Models;
namespace MVCWebApp.Models.GuessingGame
{
    /// <summary>
    /// Gets the proper Result value based on values entereed
    /// </summary>
    /// <param name="randomNumber,playerGuess"></param>
    /// <returns></returns>
    public class comparePlyerRandomNum
    {
      
            public static int GenerateRandomNumber()
            {
                Random rnd = new Random();
                int randomNumber = rnd.Next(1, 101);
                return randomNumber;
            }
            public static bool CheckSucess(int playerGuess, int randomNumber)
            {
                if (playerGuess == randomNumber)
                    return true;
                return false;
            }
            public static string Compare(int playerGuess, int randomNumber)
            {
                if (playerGuess > randomNumber)
                    return "Tip:Your Guess"+playerGuess+" is greater than the random Number: go lower";
                else
                    return "Tip:Your Guess"+ playerGuess + " is less than the random Number: go higher";
            }
        

    }
}

