﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KevinMaM17_Lab2_Ex2
{
    public partial class SimpleRegistrationUserControl : UserControl
    {
        //declared regex obj to validate password
        Regex regExp = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        bool validForm = true;  //true until proven guilty


        public SimpleRegistrationUserControl()
        {
            InitializeComponent();
        }

        //Public Properties to expose the text property of the constituent controls in this custom user control
        //properties for group box title
        public string GroupBoxTitle
        {
            get { return this.registrationGroupBox.Text; }
            set { this.registrationGroupBox.Text = value; }
        }

        //READ-ONLY PROPERTIES
        public string Username
        {
            get { return this.usrnameTB.Text; }
        }

        public string Password
        {
            get { return this.pwdTB.Text; }
        }

        public string ConfirmPassword
        {
            get { return this.confirmPwdTB.Text; }
        }

        //PUBLIC METHODS
        public void ClearAll()
        {
            this.usrnameTB.Clear();
            this.pwdTB.Clear();
            this.confirmPwdTB.Clear();
            this.usrnameTB.BackColor = Color.White;
            this.pwdTB.BackColor = Color.White;
            this.confirmPwdTB.BackColor = Color.White;
        }

        public bool SubmitForm()
        {
            //validate the three textboxes
            if (!this.validateUsernameTB())
                validForm = false;
            if (!this.validatePasswordTB())
                validForm = false;
            if (!this.validateConfirmPasswordTB())
                validForm = false;
            return validForm;
        }

        //PRIVATE METHODS
        private bool validateConfirmPasswordTB()
        {
            //confirm pwd must match pwd textbox
            if (!this.ConfirmPassword.Equals(this.Password) || this.ConfirmPassword.Length == 0)
            {
                this.confirmPwdTB.BackColor = Color.Red;
                return false;
            }
            else
            {
                this.confirmPwdTB.BackColor = Color.White;
                return true;
            }
        }


        private bool validatePasswordTB()
        {
            //validates password for following criteria:
            //at least on capital, at least one lowercase, at least one digit, at least one special char, at least 8 characters length

            if (!regExp.IsMatch(this.Password))
            {
                this.pwdTB.BackColor = Color.Red;
                return false;
            }
            else
            {
                this.pwdTB.BackColor = Color.White;
                return true;
            }
        }

        private bool validateUsernameTB()
        {
            //checks for empty string
            if (this.Username.Length == 0)
            {
                this.usrnameTB.BackColor = Color.Red;
                return false;
            }
            else
            {
                this.usrnameTB.BackColor = Color.White;
                return true;
            }
        }
    }
}
