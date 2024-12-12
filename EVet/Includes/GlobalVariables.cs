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
        public static string IDD, Fullname,uid;
        public static string info, id, name,  gender,breed, birthday,neutered,allergies,weight, images, petkey;
       
    }   
}
