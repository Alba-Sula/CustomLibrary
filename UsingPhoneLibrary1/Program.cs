using PhoneLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingPhoneLibrary1
{
    class Program
    {
        static void Main(string[] args)
        {
            String FileName = "libraryJson.json";

            List<PhoneUser> phoneUsers = new List<PhoneUser>()
            {
                new PhoneUser(){
                    FirstName = "Arli",
                    ID = 1,
                    LastName = "Tolo",
                    PhoneNumber = 0698947489,
                    PhoneType = PhoneType.Cellphone
                },
                new PhoneUser(){
                    FirstName = "Alba",
                    ID = 1,
                    LastName = "Tolo",
                    PhoneNumber = 0698947489,
                    PhoneType = PhoneType.Cellphone
                },
                new PhoneUser(){
                    FirstName = "Denis",
                    ID = 1,
                    LastName = "Sula",
                    PhoneNumber = 0699247489,
                    PhoneType = PhoneType.Cellphone
                }
            };
            //Creates the users in the list
            foreach (var item in phoneUsers)
            {
               Console.WriteLine(CRUD.CreatePhoneUser(item, FileName));
            }

            PhoneUser editPhoneUser = new PhoneUser()
            {
                FirstName = "Alba",
                ID = 1,
                LastName = "Sula",
                PhoneNumber = 0670000000,
                PhoneType = PhoneType.Cellphone
            };
            //The iterating tests works with IteratingAlphabeticalOrder(which gives back the list of the 
            //users in an aplhabetical order by firstName and LastName); IteratingByName(gives back the 
            //list of the users that have the same name as the name specified in the constructor);
            //IteratingByLastName(gives back the list of the users that have the last name as the 
            //last name specified in the constructor);
            List<PhoneUser> phUsr = CRUD.IteratingByLastName(FileName, "Sula");
            if (phUsr != null)
            {
                foreach (var item in phUsr)
                {
                    Console.WriteLine(CRUD.ToString(item));
                }
            }
           
            //It Edits the user that has that phone number, same as the user specified in the FileName file
            Console.WriteLine(CRUD.EditPhoneUser(674140006, editPhoneUser,FileName));

            //Deletes the user  that has that phone number
            //Console.WriteLine(CRUD.DeletePhoneUser(674149006, FileName));

            Console.ReadLine();
        }
    }
}
