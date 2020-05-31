using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneLibrary1
{
    public class PhoneUser
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="The first name is required")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Required(ErrorMessage ="The last name is requeired")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        [Required(ErrorMessage ="The phone type is requeired")]
        [Display(Name = "Phone Type")]
        public PhoneType PhoneType { get; set; }
        [Required(ErrorMessage ="phone number is required")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        public static String ToString(PhoneUser phoneUser)
        {
            return "User: \nFirst Name:\t" + phoneUser.FirstName +
                "\nLast Name:\t" + phoneUser.LastName + "\nPhone Type:\t" + phoneUser.PhoneType
                + "\nPhone Number:\t" + phoneUser.PhoneNumber;
        }
    }

    public enum PhoneType
    {
        Work,
        Cellphone,
        Home,
    }
}
