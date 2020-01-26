using BillingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagementSystem.ViewModel
{
    public class CustomerDetailViewModel
    {
        public Customer customer { get; set; }

 
        public List<CheckBoxListItem> months { get; set; }
        public CustomerDetailViewModel()
        {
            months = new List<CheckBoxListItem>();
        }

    }
}