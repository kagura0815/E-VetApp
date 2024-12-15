
using Firebase.Database.Query;
using System.Threading.Tasks;
using static EVet.Includes.GlobalVariables;
using System.Net;

using Microsoft.Maui.Storage;
using Firebase.Storage;
using System.Reflection.Emit;
using System.Threading.Tasks;
using EVet.Includes;
using System;
namespace EVet.Models
{
    public class Appointment
    {
        public string BId { get; set; }
        public string PetName { get; set; }
        public string OwnerName { get; set; }
        public DateOnly AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }
        // Constructor
        public Appointment()
        {
        }

        // Method to add an appointment
        public async Task<bool> AddAppointments(string bid, string petName, string ownerName, DateOnly appointmentDate, TimeSpan appointmentTime)
        {
            // Simulate adding an appointment (e.g., saving to a database)
            try
            {
                var appt = new Appointment()
                {
                    BId = bid,
                    PetName = petName,
                    OwnerName = ownerName,
                    AppointmentDate = appointmentDate,
                    AppointmentTime = appointmentTime

                };
                await client.Child("Appointments").PostAsync(appt);
                return true;
                // Here you would typically add your logic to save the appointment to a database
                // For example:
                // await Database.SaveAppointmentAsync(new Appointment { Id = id, PetName = petName, OwnerName = ownerName, AppointmentDate = appointmentDate });

                // Simulate a delay to mimic database operation
                await Task.Delay(500); // Simulate some work

                // If successful, return true
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                // Return false if there was an error
                return false;
            }
        }
    }

}

