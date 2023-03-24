using System;

namespace REIZ_Tech
{
    class Program
    {
        static void Main(string[] args)
        {
            // A single cycle (12 hours) move by the hour hand results in a 360 degree round move.
            // Hence, a one hour move of the hour hand will cover 360/12 = 30 degrees an hour. 
            byte ONE_HOUR_IN_DEGREES = 30;

            // A single cycle (1 hours = 60 minutes) move by the minute hand results in a 360 degree round move.
            // Hence, a one minute move of the minute hand will cover 360/60 = 6 degrees a minute. 
            byte ONE_MINUTE_IN_DEGREES = 6;

            // Define variables to hold values for hour and minute
            byte hours = 12;
            byte minutes = 0;

            // Ask the user to input hour
            Console.Write("Enter hour (1-12): ");
            string inputHour = Console.ReadLine();
            if (byte.TryParse(inputHour, out hours) & (hours <= 12 & hours >= 1))
            {
                // Hour is correct, ask the user to input minutes
                Console.Write("Enter minutes (0-59): ");
                string inputMinutes = Console.ReadLine();
                if (byte.TryParse(inputMinutes, out minutes) & (minutes <= 59 & minutes >= 0))
                {
                    // Both hour and minute are correct
                    // Convert user inputed minute to hours
                    float minutesInHours = (Convert.ToSingle(minutes) / 60); 
                    // Calculate how much degrees the hour hand has moved from 12
                    float hourInDegrees = ((hours * ONE_HOUR_IN_DEGREES) + (minutesInHours * ONE_HOUR_IN_DEGREES));
                    // Calculate how much degrees the minute hand has moved from 00
                    float minutesInDegrees = minutes * ONE_MINUTE_IN_DEGREES;
                    // Calculate the angle difference between the hour and minute hands
                    float angleDifference = Math.Abs(hourInDegrees - minutesInDegrees);
                    float remainingAngle = 360 - angleDifference;
                    // Determine the lesser angle
                    float lesserAngle = angleDifference < remainingAngle ? angleDifference:remainingAngle;
                    Console.WriteLine("The lesser angle between {0} and {1} is {2} degrees.", hours, minutes, lesserAngle);
                }
                else
                {
                    Console.WriteLine("Minutes must be a number in the range (1-59)"); 
                }
            }
            else
            {                
                Console.WriteLine("Hour must be a number in the range (1-12)"); 
            }
        }
    }
}
