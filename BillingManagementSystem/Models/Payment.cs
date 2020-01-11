using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BillingManagementSystem.Models
{
    public class Payment
    {
       
        [Key]
        public int payment_Id { get; set; }
       
        [Required]
        [Display(Name = "Paid  By")]
        public string paid_By { get; set; }
        [Required]
        [Display(Name = "Payment  Amount")]
        public double payment_Amount { get; set; }

       
        [Required]
        [Display(Name = "Payment For")]
        public DateTime payment_For { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string employee_Name { get; set; }
        [Required]
        [Display(Name = "Payment Date")]
        public DateTime payment_Date { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        [ForeignKey("Customer")]
        public int cust_Id { get; set; }
        public virtual Customer Customer { get; set; }

    }
   
}