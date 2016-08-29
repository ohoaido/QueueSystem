using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QueueSystem.Models
{
    public class PortInfomaitonElectricViewModels
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Datecreated { get; set; }
        public Boolean IsPublic { get; set; }
        public string UserID { get; set; }
        public string Email { get; set; }
    }
}