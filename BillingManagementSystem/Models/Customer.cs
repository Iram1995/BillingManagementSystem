using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BillingManagementSystem.Models
{
    public class Customer
    {
      
        [Key]
        public int cust_Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string first_Name { get; set; }
        [Display(Name = "Last Name")]
        public string last_Name { get; set; }
        [Required]
        [Display(Name = "Cell Number")]
        public string cell_Number { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
       
        public DateTime createdDate { get; set; }
    }
}