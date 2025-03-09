using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryPerformance.Helpers
{
    public class PaginatedList<T> : List<T>
    {
        public IEnumerable<T> Items { get; private set; }
        public int PageIndex        { get; private set; }
        public int TotalPages       { get; private set; }
        public int RecordsPerPage   { get; private set; }
        public int TotalRecords     { get; private set; }
        public int GroupSize        { get; private set; }
        public int StartPage        { get; private set; }
        public int EndPage          { get; private set; }
        
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage     => PageIndex < TotalPages;

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int recordsPerPage, int groupSize)
        {
            PageIndex      = pageIndex;
            TotalRecords   = count;
            RecordsPerPage = recordsPerPage;
            TotalPages     = (int)Math.Ceiling(count / (double)recordsPerPage);
            GroupSize      = groupSize;
            Items          = items;

            int groupIndex = (pageIndex - 1) / groupSize;
            StartPage      = groupIndex * groupSize + 1;
            EndPage        = Math.Min(StartPage + groupSize - 1, TotalPages);
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int recordsPerPage, int groupSize)
        {
            int count         = source.Count();
            var items = source.Skip((pageIndex - 1) * recordsPerPage).Take(recordsPerPage).ToList();
            return new PaginatedList<T>(items, count, pageIndex, recordsPerPage, groupSize);
        }
    }
}
