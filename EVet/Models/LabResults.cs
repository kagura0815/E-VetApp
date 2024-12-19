
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static EVet.App;
using Firebase.Database.Query;
using static EVet.Includes.GlobalVariables;
using EVet.Includes;
namespace EVet.Models
{
    public class LabResults
    {
        public string Id { get; set; } // Unique ID for the lab result
        public string PetName { get; set; }
        public string OwnerName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
        public string Range { get; set; }

        // Method to add a lab result to the database
        public async Task<bool> AddLabResultAsync()
        {
            var rid = GlobalVariables.PETID;
            try
            {

                Id = Guid.NewGuid().ToString();

                // Assuming you have a Firebase client or database context set up


                // Add the lab result to the "LabResults" node with the unique ID
                await client
                    .Child($"Users/{IDD}/Pets/{PETID}/LabResults")
                    .Child(Id) // Use the unique ID as the key
                    .PutAsync(this); // 'this' refers to the current instance of LabResult

                return true; // Indicate success
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                Console.WriteLine($"Error adding lab result: {ex.Message}");
                return false; // Indicate failure
            }
        }
    }
    //public async Task<bool> AddLabResults(string idd, string pname,
    //     string oname,string time, string testname)
    //{
    //    var petID = GlobalVariables.PETID; // Assuming IDD is a global variable for user ID
    //    var labResults = new LabResults()
    //    {

    //        RiD = petID,
    //       PetName = pname,
    //        OwnerName = oname,
    //       TestName = testname,
    //       Time = time,
    //       Date = DateTime.Now,
          
           

    //    };
    //    await client.Child("Users").PostAsync(labResults);
    //    return true;
    //}
    //public async Task<bool> GetRID(string _id)
    //{
    //    try
    //    {
    //        var evaluateID =
    //            (await client.Child("Students").OnceAsync<LabResults>()).FirstOrDefault(a =>
    //            a.Object.RiD == _id);
    //        if (evaluateID != null)
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
}
