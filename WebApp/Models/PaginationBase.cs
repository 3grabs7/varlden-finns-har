using System;

namespace WebApp.Models
{
    public class PaginationBase
    {
        public const int PAGE_SIZE = 10;

        public int CurrentPage { get; set; }
        public string SortBy { get; set; }
        public int Count { get; set; }
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PAGE_SIZE));

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;

    }
}
