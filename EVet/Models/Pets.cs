using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database.Query;
using System.Threading.Tasks;
using static EVet.Includes.GlobalVariables;
using System.Net;
using System.Reflection;
using Microsoft.Maui.Storage;
using Firebase.Storage;
using System.Reflection.Emit;
using System.Threading.Tasks;
namespace EVet.Models
{
   public class Pets
    {
        public string Images { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        //public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Neutered { get; set; }
        public string Allergies { get; set; }
        public string Weight { get; set; }
        public async Task<bool> AddPet(
            string id,
            string name,
            string breed,
            //string birthday,
            string gender,
            string neutered,
            string allergies,
            string weight,
            FileResult mainimg,
            string flename)
        {
            var _mainimg = await UploadImage(await mainimg.OpenReadAsync(), $"{flename}_mainimg.png");
            var pets = new Pets()
            {
                ID = code,
                Name = name,
                Breed = breed,
                //Birthday = birthday,
                Gender = gender,
               Neutered = neutered,
                Allergies = allergies,
                Images = _mainimg

            };

            await client.Child("Pets").PostAsync(pets);


            return true;

        }
        //public async Task<List<Students>> GetStudents()
        //{
        //    return (await client
        //        .Child("Students")
        //        .OnceAsync<Students>()).Select(item => new Students
        //        {
        //            ID = item.Object.ID,
        //            Firstname = item.Object.Firstname,
        //            Lastname = item.Object.Lastname,
        //            Gender = item.Object.Gender,
        //            Address = item.Object.Address,
        //            ContactNumber = item.Object.ContactNumber
        //        }).ToList();
        //}
        public async Task<bool> GetCode(string _id)
        {
            try
            {
                var evaluateCode = (await client.Child("PetInfo")
                .OnceAsync<Pets>()).FirstOrDefault(a =>
                a.Object.ID == _id);
                if (evaluateCode == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Pets>> GetRecipe()
        {
            return (await client
                .Child("Pets")
                .OnceAsync<Pets>()).Select(item => new Pets
                {
                    Name = item.Object.Name,
                    Breed=item.Object.Breed,
                    //Birthday = item.Object.Birthday,
                    Gender = item.Object.Gender,
                    Neutered=item.Object.Neutered,
                    Allergies=item.Object.Allergies,
                    Weight=item.Object.Weight,

                    //Name = item.Object.RecipeName,
                    //Category = item.Object.Category,
                    //Meal = item.Object.Meal,
                    //Duration = item.Object.Duration,
                    //Code = item.Object.Code,
                    //Ingredient = item.Object.Ingredient,
                    //Instruction = item.Object.Instruction,
                    //Images = item.Object.Images

                }).ToList();
        }
        public async Task<String> GetPetkey(string _id)
        {
            var evaluateCode = (await client.Child("Pets")
                .OnceAsync<Pets>()).FirstOrDefault
                (a => a.Object.ID == _id);
            if (evaluateCode != null)
            {

                petkey = evaluateCode.Key;
                id = evaluateCode.Object.ID;
                name = evaluateCode.Object.Name;
                breed = evaluateCode.Object.Breed;
                //birthday = evaluateCode.Object.Birthday;
                gender = evaluateCode.Object.Gender;
                neutered = evaluateCode.Object.Neutered;
                allergies = evaluateCode.Object.Allergies;
                weight = evaluateCode.Object.Weight;
                //recipekey = evaluateCode.Key;
                //code = evaluateCode.Object.Code;
                //recipename = evaluateCode.Object.RecipeName;
                //catname = evaluateCode.Object.Category;
                //mealnm = evaluateCode.Object.Meal;
                //duration = evaluateCode.Object.Duration;
                //instruction = evaluateCode.Object.Instruction;
                //ingredient = evaluateCode.Object.Ingredient;
                //recipeimage = evaluateCode.Object.Images;
                return evaluateCode.Key;
            }
            return null;
        }

        public async Task<bool> DeleteRecipe(string id)
        {
            try

            {

                var getpetkey = (await client
                    .Child("Pets")
                    .OnceAsync<Pets>()).FirstOrDefault
                    (a => a.Object.ID == id);
                if (getpetkey != null)
                {
                    await client
                        .Child("Pets")
                    .Child(getpetkey.Key)
                        .DeleteAsync();
                    client.Dispose();
                    await storage
                    .Child($"Images/StudentImage/{id}_mainimg.png")
                    .DeleteAsync();
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
        public async Task<bool> EditRecipe( string name, string breed, string birthday, string gender, string neutered, string allergies,string weight, string flename)
        {

            var pets = new Pets()
            {
                
                Name = name,
                Breed = breed,
                //Birthday = birthday,
                Gender = gender,
                Allergies = allergies,
                Weight = weight,
                Images = flename
            };
            await client.Child($"Pets/{petkey}").PatchAsync(pets);
            return true;

        }
        public async Task<string> UploadImage(Stream img, string filename)
        {
            try
            {
                var image = await storage
                    .Child($"Images/PetImage/{filename}")
                    .PutAsync(img);
                return image;
            }
            catch (Exception ex)
            {
                return "false";
            }
        }
        //public async Task<List<Pets>> GetAllRecipe()

        //{

        //    return (await client
        //    .Child("Pets")
        //    .OnceAsync<Pets>()).Select(item => new Pets
        //    {
        //        RecipeName = item.Object.RecipeName,
        //        Category = item.Object.Category,
        //        Meal = item.Object.Meal,
        //        Duration = item.Object.Duration,
        //        Code = item.Object.Code,
        //        Ingredient = item.Object.Ingredient,
        //        Instruction = item.Object.Instruction,
        //        Images = item.Object.Images
        //    }).ToList();
        //}
        //public async Task<List<Pets>> FindRecipe(string fname)
        //{
        //    var queryUsers = await GetAllRecipe();
        //    await client
        //        .Child("Pets")
        //        .OnceAsync<Pets>();
        //    var searchTerms = fname.Split(',');
        //    return queryUsers.Where(a => searchTerms.Any(term => a.RecipeName.ToLower().Contains(term.ToLower()) || a.Category.ToLower().Contains(term.ToLower()) || a.Meal.ToLower().Contains(term.ToLower()) || a.Ingredient.ToLower().Contains(term.ToLower()) || a.Code.ToLower().Contains(term.ToLower())

        //    )).ToList();
        //}
    }
}

