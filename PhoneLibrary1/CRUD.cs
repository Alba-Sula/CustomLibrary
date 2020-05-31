using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneLibrary1
{
    public class CRUD
    {

        /// <summary>
        /// This is a method that iterates in the file provided in alphabetical order
        /// </summary>
        /// <param name="FileName">
        /// The file in which we iterate for the phone users
        /// </param>
        /// <returns>
        /// Returns a phone user
        /// </returns>
        public static List<PhoneUser> IteratingAlphabeticalOrder(String FileName)
        {
            List<PhoneUser> phoneUsers = new List<PhoneUser>();

            if (FileName == null || FileName.Length == 0)
            {
                Console.WriteLine("The file name that you provided is invalid; it's either null or empty");
            }
            else
            {
                FileInfo fileInfo = new FileInfo(FileName);
                if (!fileInfo.Exists)
                {
                    Console.WriteLine(FileName + " file does not exist");
                }
                else
                {
                    if (fileInfo.Length == 2)
                    {
                        Console.WriteLine(FileName + " file is empty, you do not have users to edit");
                    }
                    else
                    {
                        if (isJson(FileName))
                        {
                            String jsonDeserialize = File.ReadAllText(FileName);
                            phoneUsers = JsonConvert.DeserializeObject<List<PhoneUser>>(jsonDeserialize);
                            var users = phoneUsers.
                                        OrderBy(u => u.FirstName).
                                        ThenBy(u => u.LastName).
                                        ToList();
                            if(users != null)
                            {
                                return users;
                            }
                            else
                            {
                                Console.WriteLine(FileName + " file that you provided is empty");
                            }

                        }
                        else
                        {
                            Console.WriteLine(FileName + " file that you provided is not a .json file");
                        }

                    }
                }
            }
            return null;
        }
        /// <summary>
        /// This is a method that iterates in the file provided by name provided by user
        /// </summary>
        /// <param name="FileName">
        /// Name of the.json file where we want to iterate for the phone users
        /// </param>
        /// <param name="Name">
        /// Name of the users we want
        /// </param>
        /// <returns>
        /// Phone User
        /// </returns>
        public static List<PhoneUser> IteratingByName(String FileName, String Name)
        {
            List<PhoneUser> phoneUsers = new List<PhoneUser>();

            if (FileName == null || FileName.Length == 0)
            {
                Console.WriteLine("The file name that you provided is invalid; it's either null or empty");
            }
            else
            {
                FileInfo fileInfo = new FileInfo(FileName);
                if (!fileInfo.Exists)
                {
                    Console.WriteLine(FileName + " file does not exist");
                }
                else
                {
                    if (fileInfo.Length == 2)
                    {
                        Console.WriteLine(FileName + " file is empty, you do not have users iterate by name");
                    }
                    else
                    {
                        if (isJson(FileName))
                        {
                            String jsonDeserialize = File.ReadAllText(FileName);
                            phoneUsers = JsonConvert.DeserializeObject<List<PhoneUser>>(jsonDeserialize);
                            List<PhoneUser> phoneUsersByName = new List<PhoneUser>();
                            if (phoneUsers.Count > 1)
                            {
                                phoneUsersByName = phoneUsers.FindAll(phUser => phUser.FirstName == Name);
                                if (phoneUsersByName.Count == 0)
                                {
                                    Console.WriteLine("There is no user called " + Name);
                                }
                                else
                                {
                                    return phoneUsersByName.
                                        OrderBy(u => u.FirstName).
                                        ThenBy(u => u.LastName).
                                        ToList();
                                }
                            }
                            else
                            {
                                Console.WriteLine("The file is empty");
                            }

                        }
                        else
                        {
                            Console.WriteLine(FileName + " file that you provided is not a .json file");
                        }

                    }
                }
            }
            return null;
        }
        /// <summary>
        /// This is a method that iterates by last name provided by the user
        /// </summary>
        /// <param name="FileName">
        /// Name of the .json file where you want to iterate for phone users
        /// </param>
        /// <param name="LastName">
        /// Last Name of the users that we want
        /// </param>
        /// <returns>
        /// PhoneUser
        /// </returns>
        public static List<PhoneUser> IteratingByLastName(String FileName, String LastName)
        {
            List<PhoneUser> phoneUsers = new List<PhoneUser>();

            if (FileName == null || FileName.Length == 0)
            {
                Console.WriteLine("The file name that you provided is invalid; it's either null or empty");
            }
            else
            {
                FileInfo fileInfo = new FileInfo(FileName);
                if (!fileInfo.Exists)
                {
                    Console.WriteLine(FileName + " file does not exist");
                }
                else
                {
                    if (fileInfo.Length == 2)
                    {
                        Console.WriteLine(FileName + " file is empty, you do not have users iterate by last name");
                    }
                    else
                    {
                        if (isJson(FileName))
                        {
                            String jsonDeserialize = File.ReadAllText(FileName);
                            phoneUsers = JsonConvert.DeserializeObject<List<PhoneUser>>(jsonDeserialize);
                            List<PhoneUser> phoneUsersByLastName = new List<PhoneUser>();
                            
                            if (phoneUsers.Count > 1)
                            {
                                phoneUsersByLastName = phoneUsers.FindAll(phUser => phUser.LastName == LastName);
                                if (phoneUsersByLastName.Count == 0)
                                {
                                    Console.WriteLine("There is no user called " + LastName);
                                }
                                else
                                {
                                    return phoneUsersByLastName.
                                        OrderBy(u => u.FirstName).
                                        ThenBy(u => u.LastName).
                                        ToList();
                                }
                            }
                            else
                            {
                                Console.WriteLine("The file is empty");
                            }
                            

                        }
                        else
                        {
                            Console.WriteLine(FileName + " file that you provided is not a .json file");
                        }

                    }
                }
            }
            return null;
        }
        /// <summary>
        /// This method is used to create a phone user 
        /// </summary>
        /// <param name="phoneUser">
        /// This is the parameter that cames from the user of type PhoneUser
        /// </param>
        /// <param name="FileName">
        /// This is the name of the .json file that you want either to create or to write a new phone user on it
        /// </param>
        public static String CreatePhoneUser(PhoneUser phoneUser, String FileName)
        {
            List<PhoneUser> phoneUsers = new List<PhoneUser>();
            String output = null;
            if (FileName == null || FileName.Length == 0)
            {
                FileInfo fileInfo = new FileInfo(FileName);
                if (!fileInfo.Exists || fileInfo.Length == 2)
                {
                    phoneUsers.Add(phoneUser);
                    String jsonSerialize = JsonConvert.SerializeObject(phoneUsers);
                    File.WriteAllText(FileName, jsonSerialize);
                    output = "Hurrayyy this is the first user that you are creating, keep it up with your connections";
                }

            }
            else
            {
                if (isJson(FileName))
                {
                    String jsonDeserialize = File.ReadAllText(FileName);
                    phoneUsers = JsonConvert.DeserializeObject<List<PhoneUser>>(jsonDeserialize);
                    phoneUsers.Add(phoneUser);
                    String jsonSerialize = JsonConvert.SerializeObject(phoneUsers);
                    File.WriteAllText(FileName, jsonSerialize);
                    output = "The new user with "+phoneUser.PhoneNumber+" phone number is now added";
                }
                else
                {
                    output = "The file that you provided is not a .json file, the user is not added";
                }
                
            }

            return output;
        }
        /// <summary>
        /// This method edits the user in the file that you provided
        /// </summary>
        /// <param name="phoneNumber">
        /// The user that you want to edit
        /// 
        /// </param>
        /// <param name="phoneUser">
        /// The updated version of the user
        /// </param>
        /// <param name="FileName">
        /// The file that you want the user to edit
        /// </param>
        /// <returns>
        /// The action that got executed
        /// </returns>
        public static String EditPhoneUser (int phoneNumber,PhoneUser phoneUser, String FileName)
        {
            List<PhoneUser> phoneUsers = new List<PhoneUser>();

            if (FileName == null || FileName.Length == 0)
            {
                return "The file name that you provided is invalid; it's either null or empty";
            }
            else
            {
                FileInfo fileInfo = new FileInfo(FileName);
                if (!fileInfo.Exists)
                {
                    return FileName + " file does not exist";
                }
                else
                {
                    if (fileInfo.Length == 2)
                    {
                        return FileName + " file is empty, you do not have users to edit";
                    }
                    else
                    {
                        if (isJson(FileName))
                        {
                            String jsonDeserialize = File.ReadAllText(FileName);
                            phoneUsers = JsonConvert.DeserializeObject<List<PhoneUser>>(jsonDeserialize);
                            PhoneUser phone = phoneUsers.Find(phUser => phUser.PhoneNumber == phoneNumber);
                            if (phone != null)
                            {
                                phone.FirstName = phoneUser.FirstName;
                                phone.LastName = phoneUser.LastName;
                                phone.PhoneNumber = phoneUser.PhoneNumber;
                                phone.PhoneType = phoneUser.PhoneType;
                                String jsonSerialize = JsonConvert.SerializeObject(phoneUsers);
                                File.WriteAllText(FileName, jsonSerialize);
                                return "The user got edited";

                            }
                            
                            else
                            {
                                phoneUsers.Add(phone);
                                String jsonSerialize = JsonConvert.SerializeObject(phoneUsers);
                                File.WriteAllText(FileName, jsonSerialize);
                                return "The user does not exist; created it";
                            } 

                        }
                        else
                        {
                            return FileName + " file that you provided is not a .json file";
                        }

                    }
                }
            }
        }
        /// <summary>
        /// This method deletes the phone user in the file name that you provided
        /// </summary>
        /// <param name="phoneUser">
        /// This is the phoneuser that you want to delete from the file
        /// </param>
        /// <param name="FileName">
        /// This is the file in which you want to delete the user from
        /// </param>
        /// <returns>
        /// Returns a string that gives you information about the current state of the method
        /// </returns>
        public static String DeletePhoneUser(int phoneNumber, String FileName)
        {
            List<PhoneUser> phoneUsers = new List<PhoneUser>();

            if (FileName==null || FileName.Length == 0)
            {
                return "The file name that you provided is invalid; it's either null or empty";
            }
            else
            {
                FileInfo fileInfo = new FileInfo(FileName);
                if (!fileInfo.Exists)
                {
                    return FileName + " file does not exist";
                }
                else 
                {
                    if(fileInfo.Length == 2)
                    {
                        return FileName + " file is empty, you do not have users to delete";
                    }
                    else
                    {
                        if (isJson(FileName))
                        {
                            String jsonDeserialize = File.ReadAllText(FileName);
                            phoneUsers = JsonConvert.DeserializeObject<List<PhoneUser>>(jsonDeserialize);
                            if (phoneUsers.Count >1)
                            {
                                PhoneUser phone = phoneUsers.Find(phUser => phUser.PhoneNumber == phoneNumber);
                                if (phone != null)
                                {
                                    phoneUsers.Remove(phone);
                                    String jsonSerialize = JsonConvert.SerializeObject(phoneUsers);
                                    File.WriteAllText(FileName, jsonSerialize);
                                    return "The user " + phone.FirstName + " " + phone.LastName + " with phone number " + phone.PhoneNumber + " got deleted";
                                }
                                else
                                {
                                    return "The phone user with " + phoneNumber + " phone number does not exist in " + FileName + " file";
                                }
                            }
                            else
                            {
                                return "The file is empty";
                            }
                            
                        }
                        else
                        {
                            return FileName + " file that you provided is not a .json file";
                        }
                    }
                        
                }
            }
        }

        /// <summary>
        /// This method checks if the file is .json file 
        /// </summary>
        /// <param name="FileName">
        /// The name of the file
        /// </param>
        /// <returns>
        /// true if the file is json file
        /// false if the file is not json file
        /// </returns>
        public static bool isJson(String FileName)
        {
            String extStr = @"\.json$";
            Regex regex = new Regex(extStr);
            if (regex.IsMatch(FileName))
            {
                return true;
            }
            return false;
        }
        public static String ToString(PhoneUser phoneUser)
        {
            return "User: \nFirst Name:\t" + phoneUser.FirstName +
                "\nLast Name:\t" + phoneUser.LastName + "\nPhone Type:\t" + phoneUser.PhoneType
                + "\nPhone Number:\t" + phoneUser.PhoneNumber;
        }

    }
}
