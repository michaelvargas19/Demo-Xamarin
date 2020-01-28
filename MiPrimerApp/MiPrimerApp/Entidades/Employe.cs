using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimerApp.Entidades
{
    public class Employe
    {

        private int id;
        public int Id
        {
            get{ return id;}
            set{ id = value; }
        }

        private string employee_name;
        public string Employee_name
        {
            get { return employee_name; }
            set { employee_name = value; }
        }

        private string employee_salary;
        public string Employee_salary
        {
            get { return employee_salary; }
            set { employee_salary = value; }
        }

        private string employee_age;
        public string Employee_age
        {
            get { return employee_age; }
            set { employee_age = value; }
        }

        private string profile_image;
        public string Profile_image
        {
            get { return profile_image; }
            set { profile_image = value; }
        }

        public override string ToString()
        {
            return employee_name;
        }
    }
    
}
