using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace CCPhus.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static string CalculateTimeAsUser(this DateTime createdDateTime)
        {
            var totalMonths = (DateTime.Now.Year - createdDateTime.Year) * 12 + DateTime.Now.Month - createdDateTime.Month;
            totalMonths += DateTime.Now.Day < createdDateTime.Day ? -1 : 0;

            var years = totalMonths / 12;
            var months = totalMonths % 12;
            var days = DateTime.Now.Subtract(createdDateTime.AddMonths(totalMonths)).Days;

            if (years == 0 && months == 0)
            {
                return $"{days} days";
            }

            if (years == 0)
            {
                return $"{months} months, {days} days";
            }

            return $"{years} years, {months} months, {days} days";
        }
    }
}
