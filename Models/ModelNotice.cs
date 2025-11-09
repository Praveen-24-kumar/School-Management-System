using System;

namespace SchoolManagement.Models
{
    public class ModelNotice
    {
        public int NoticeId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string PostedBy { get; set; }
        public DateTime NoticeDate { get; set; }
    }
    public class NoticeBoardViewModel
    {
        public ModelNotice NoticeForm { get; set; } = new ModelNotice();
        public List<ModelNotice> NoticeList { get; set; } = new List<ModelNotice>();
    }
}
