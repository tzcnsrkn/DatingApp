using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            // ST: We need to remove them if we want to undo adding element to the headers. These header 
            // modifications are permanent, unless we remove the elements.
            // response.Headers.Remove("Application-Error");
            // response.Headers.Remove("Access-Control-Expose-Headers");
            // response.Headers.Remove("Access-Control-Allow-Origin");

            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}