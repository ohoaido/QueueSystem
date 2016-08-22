using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueSystem.Models
{
    public class HeThongSo
    {
        public int ID { get; set; }
        public int STT { get; set; }
        public Boolean Goi { get; set; }
        public DateTime DateCreated { get; set; }
        public int ManHinhID { get; set; }
        public int STTConfirmed { get; set; }
        public DateTime Timer { get; set; }
        public ManHinh ManHinh { get; set; }
    }
}