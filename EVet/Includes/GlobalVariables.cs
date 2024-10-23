using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Storage;
namespace EVet.Includes
{
    internal class GlobalVariables
    {
        public static FirebaseClient client = new("https://e-vet-52356-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public static FirebaseStorage storage = new("e-vet-52356.appspot.com");

        public static string id, name,  gender,breed, birthday,neutered,allergies,weight, images, petkey;
        public static string code, stat, searchtext, recipename, rk, userkey, catname, mealnm, duration, instruction, ingredient, recipekey, recipeimage, username, usernamepass, firstname, lastname, status, userimage, labeling, stat1, usernamepass1, username1, firstname1, lastname1, status1, userimage1, userkey1;
    }   
}
