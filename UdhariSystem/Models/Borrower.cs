using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UdhariSystem.Models
{
    public class Borrower
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public String Address {  get; set; }
        public decimal AmountOwed { get; set; }
    }
}