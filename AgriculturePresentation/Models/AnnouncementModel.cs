using System;

namespace AgriculturePresentation.Models
{
    public class AnnouncementModel
    {
        public int AnnouncementIdm { get; set; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementContent { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public bool AnnouncementStatus { get; set; }
        public string AnnouncementImage { get; set; }
    }
}
