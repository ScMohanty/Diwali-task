using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31
{
    class Job:IComparable
    {
        private string role;
        private string skillSet;
        private string employmentType;
        private string location;
        private int minExperience;
        private long salary;

        public Job()
        {
        }

        public Job(long salary, string role, string skillSet, string employmentType, string location, int minExperience)
        {
            Salary = salary;
            Role = role;
            SkillSet = skillSet;
            EmploymentType = employmentType;
            Location = location;
            MinExperience = minExperience;
        
        }

        public string Role { get => role; set => role = value; }
        public string SkillSet { get => skillSet; set => skillSet = value; }
        public string EmploymentType { get => employmentType; set => employmentType = value; }
        public string Location { get => location; set => location = value; }
        public int MinExperience { get => minExperience; set => minExperience = value; }
        public long Salary { get => salary; set => salary = value; }

      
        public static Job CreateJob( long salary,string role,string  skillSet,string employmentType,string location,int  minExperience)
        {
            Job j = new Job();
            
            j.Salary = salary;
            j.Role = role;
            j.SkillSet = skillSet;
            j.EmploymentType = employmentType;
            j.Location = location;
            j.MinExperience = minExperience;

            return j;
        }

        public int CompareTo(object obj)
        {
            Job j = (Job)obj;

            return this.MinExperience.CompareTo(j.MinExperience);
        }

        public override bool Equals(object obj)
        {
            Job j2 = (Job)obj;

            return this.MinExperience.Equals(j2.MinExperience);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}     {1}      {2}   {3}",Role,EmploymentType,Location ,MinExperience, Salary);
        }

    }
    class Program
    {

        public static void Main(string[] args)
        {
            int no_Of_Vacency;

            Console.WriteLine("ENTER NUMBER OF VACENCY");
            no_Of_Vacency = Convert.ToInt32(Console.ReadLine());
            Job[] job_Details = new Job[no_Of_Vacency];



            for (int i = 0; i < no_Of_Vacency; i++)
            {
                long salary;
                Console.WriteLine("ENTER SALARY");
                salary = Convert.ToInt64(Console.ReadLine());
                string role;
                Console.WriteLine("ENTER JOB ROLE");
                role = Console.ReadLine();
                Console.WriteLine("ENTER SKILL SET");

                string skillSet = Console.ReadLine();
                Console.WriteLine("ENTER EMPLOYEMENT TYPE");
                string employmentType = Console.ReadLine();
                Console.WriteLine("ENTER THE LOCATION");
                string location = Console.ReadLine();
                Console.WriteLine("ENTER THE EXPERIENCE");
                int minExperience = Convert.ToInt32(Console.ReadLine());
                job_Details[i] = Job.CreateJob(salary, role, skillSet, employmentType, location, minExperience);

            }
            SalaryComparator sort_By_Sal = new SalaryComparator();
            Array.Sort(job_Details, sort_By_Sal);

            foreach (var k in job_Details)
            {
                Console.WriteLine(k);
            }
        }


    }
    class SalaryComparator : IComparer<Job>
    {
        public int Compare(Job x, Job y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }
}
