using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public class DashboardViewModel
    {
        // Stats
        public int TotalStudents { get; set; }
        public int TotalParents { get; set; }
        public int TotalTeachers { get; set; }
        public decimal TotalEarnings { get; set; }

        // Chart Data
        public List<decimal> Collections { get; set; } = new List<decimal>();
        public List<decimal> Fees { get; set; } = new List<decimal>();
        public List<decimal> Expenses { get; set; } = new List<decimal>();

        // Notices
        public List<ModelNotice> Notices { get; set; } = new List<ModelNotice>();

        // Recent Activities
        public List<RecentActivityModel> RecentActivities { get; set; } = new List<RecentActivityModel>();
    }

    //public class Notice
    //{
    //    public DateTime NoticeDate { get; set; }
    //    public string Title { get; set; }
    //    public string Details { get; set; }
    //    public string PostedBy { get; set; }
    //}

    public class RecentActivityModel
    {
        public DateTime Date { get; set; }
        public string Activity { get; set; }
    }
}
