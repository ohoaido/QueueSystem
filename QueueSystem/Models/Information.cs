using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QueueSystem.Models
{
    public class Information
    {
        public int ID { get; set; }
        public string codePatient { get; set; }
        public string FullName { get; set; }
        public DateTime Age { get; set; }
        [Display(Name = "Loại bệnh nhân")]
        public int Status { get; set; }
        public string IDCard { get; set; }
        public string Address { get; set; }
        [Display(Name = "Xác nhận")]
        public bool IsPublic { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime DateCreated { get; set; }
        [Display(Name = "Cổng thông tin điện tử")]
        public int PortInfomaitonElectricID { get; set; }
        public PortInfomaitonElectric PortInfomaitonElectric { get; set; }
    }
}