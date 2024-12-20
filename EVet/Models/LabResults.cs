
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
        public async Task<bool> AddLabResultAsync( string pName,string oName,string testres,string testtype)
        {
           

            try
            {
                var rid = GlobalVariables.PETID;
                var currentTime = DateTime.Now;
                var labResults = new LabResults();
                {
                    Id = rid;
                    PetName = pName;
                    OwnerName = oName;
                    Date = DateTime.Now;
                    Time = currentTime.ToString();
                    TestName = testtype;
                    Result = testres;

                }
                // Assuming you have a Firebase client or database context set up


                // Add the lab result to the "LabResults" node with the unique ID
                await client
                    .Child($"Users/{IDD}/Pets/{PETID}/LabResults")
                    .Child(Id) // Use the unique ID as the key
                    .PostAsync(labResults); // 'this' refers to the current instance of LabResult

                return true; // Indicate success
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                Console.WriteLine($"Error adding lab result: {ex.Message}");
                return false; // Indicate failure
            }
        }
        public async Task<List<LabResults>> GetLabResults()
        {
            var currentTime = DateTime.Now;
            return (await client
                .Child($"LabResults")
                .OnceAsync<LabResults>()).Select(item => new LabResults
                {

                    PetName = item.Object.PetName,
                    OwnerName = item.Object.OwnerName,
                    Date = DateTime.Now,
                    Time = currentTime.ToString(),
                     Id = item.Object.Id,
                         Range = item.Object.Range,
                          Result = item.Object.Result,
                           TestName = item.Object.TestName
                    
                   




                }).ToList();
        }
        public async Task<List<LabResults>> GetAllLabResults()
        {
            var appointment = await client
               .Child("LabResults")
               .OnceAsync<LabResults>();

            return appointment
               .Select(item => new LabResults
               {
                   PetName = item.Object.PetName,
                   OwnerName = item.Object.OwnerName,
                   Date = DateTime.Now,
                   Id = item.Object.Id,
                   Range = item.Object.Range,
                   Result = item.Object.Result,
                   TestName = item.Object.TestName


               })
               .ToList();
        }
        public async Task<List<LabResults>> FindAppointment(string fname)
        {
            var queryVisitor = await GetAllLabResults();
            await client
                .Child("LabResults")
                .OnceAsync<LabResults>();
            var searchTerms = fname.Split(' ');
            return queryVisitor.Where(a => searchTerms.Any(term => a.PetName.ToLower().Contains(term.ToLower())
            || a.OwnerName.ToLower().Contains(term.ToLower())
         
            
            || a.TestName.ToLower().Contains(term.ToLower())))
                .ToList();

        }
        public async Task<bool> DeleteAppointment(string id)
        {
            try
            {
                var getstudentkey = (await client
                    .Child("LabResults")
                    .OnceAsync<LabResults>()).FirstOrDefault
                    (a => a.Object.Id == id);
                if (getstudentkey != null)
                {
                    await client
                        .Child("LabResults")
                    .Child(getstudentkey.Key)
                        .DeleteAsync();
                    client.Dispose();
                    return true;
                }

                client.Dispose();
                return false;
            }
            catch
            {
                client.Dispose();
                return false;
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
