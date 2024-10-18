﻿namespace CivicaBookLibraryMVC.ViewModels
{
    public class UserBookReportViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int IssueId { get; set; }
    }
}