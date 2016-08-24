using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QueueSystem.Models
{
    public class HeThongSo
    {
        public int ID { get; set; }
        [Display(Name = "Số thứ tự gọi")]
        public int STT { get; set; }
        [Display(Name = "Đã được gọi")]
        public Boolean Goi { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Cổng")]
        public int ManHinhID { get; set; }
        [Display(Name = "Đã được xác nhận")]
        public Boolean STTConfirmed { get; set; }
        [Display(Name = "Hẹn giờ")]
        public DateTime Timers { get; set; }
        [Display(Name = "Đặt trước")]
        public Boolean STTOnline { get; set; }
        public ManHinh ManHinh { get; set; }
    }
}