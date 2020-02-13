﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.Models
{
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [StringLength(25)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }
        
        [StringLength(20)]
        public Jobs Jobs { get; set; }

        public decimal Salary { get; set; }

        public decimal CommissionPCT { get; set; }

        public int ManagerId { get; set; }


        public Departments Departments { get; set; }
    }
}
