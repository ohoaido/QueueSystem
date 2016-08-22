using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueSystem.ViewModels
{
    public class InformationViewModels
    {
        public int ID { get; set; }
        public string codePatient { get; set; }
        public string FullName { get; set; }
        public DateTime Age { get; set; }
        public int Status { get; set; }
        public string IDCard { get; set; }
        public string Address { get; set; }
        public bool IsPublic { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DateCreated { get; set; }
    }
}