using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QueueSystem.Models
{
    public class ManHinh
    {
        public int ID { get; set; }
        [Display(Name = "Cổng")]
        public string ManHinhSo { get; set; }
        [Display(Name = "Cổng thông tin điện tử")]
        public int PortInfomaitonElectricID { get; set; }
        public PortInfomaitonElectric PortInfomaitonElectric { get; set; }
    }
}