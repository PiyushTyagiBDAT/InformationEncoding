using System;
using System.Collections.Generic;
using System.Text;

namespace FTPApp.Models
{
    class Student
    {
        public string StudentId { get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string ImageData { get; set; }
        public bool MyRecord { get; set; }

        public void FromDirectory(string dir) {

            
            string[] dp = dir.Split(" ", StringSplitOptions.None);
            StudentId = dp[0];
           FirstName = dp[1];
            LastName = dp[2];
        }
        public override string ToString()
        {
            return $"{StudentId} {LastName}{FirstName}";
        }
    }
}
