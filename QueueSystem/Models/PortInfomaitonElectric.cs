using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueSystem.Models
{
    public class PortInfomaitonElectric
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Datecreated { get; set; }
        public Boolean IsPublic { get; set; }

    }
}