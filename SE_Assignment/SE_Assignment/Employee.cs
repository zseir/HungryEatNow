﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Assignment
{
    abstract class Employee
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string nric;

        public string NRIC
        {
            get { return nric; }
            set { nric = value; }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string contactNumber;

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        private DateTime dateJoined;

        public DateTime DateJoined
        {
            get { return dateJoined; }
            set { dateJoined = value; }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public void ProcessOrder() { }

    }
}