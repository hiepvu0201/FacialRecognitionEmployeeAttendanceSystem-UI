﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionEmployeeAttendanceSystem_UI.Models
{
    class Payslips
    {
        [System.ComponentModel.DisplayName("Id")]
        public long id { get; set; }

        [System.ComponentModel.DisplayName("Payment Date")]
        public DateTime payDate { get; set; }

        [System.ComponentModel.DisplayName("Working Salary")]
        public double workingSalary { get; set; }

        [System.ComponentModel.DisplayName("Public Salary")]
        public double publicSalary { get; set; }

        [System.ComponentModel.DisplayName("Other Salary")]
        public double otherSalary { get; set; }

        [System.ComponentModel.DisplayName("Anual Leave Salary")]
        public double annualLeaveSalary { get; set; }

        [System.ComponentModel.DisplayName("Overtime Salary")]
        public double overtimeSalary { get; set; }

        [System.ComponentModel.DisplayName("Allowance")]
        public double allowance { get; set; }

        [System.ComponentModel.DisplayName("Bonus")]
        public double bonus { get; set; }

        [System.ComponentModel.DisplayName("Tax")]
        public double tax { get; set; }

        [System.ComponentModel.DisplayName("User Id")]
        public long userId { get; set; }

        public Users users { get; set; }

        [System.ComponentModel.DisplayName("Deduction Salary")]
        public double deductionSalary { get; set; }

        [System.ComponentModel.DisplayName("Created At")]
        public DateTime createdAt { get; set; }

        [System.ComponentModel.DisplayName("Is Disabled")]
        public bool isDisabled { get; set; }

        private static Payslips _instance;
        public static Payslips GetInstance()
        {
            if (_instance == null)
                _instance = new Payslips();
            return _instance;
        }
    }
}
