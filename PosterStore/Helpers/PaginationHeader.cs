namespace PosterStore.Helpers
{
    public class PaginationHeader // это наш htpp response header
    { 
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems,  int totalPages)
        {
            this.CurrentPage = CurrentPage;
            this.ItemsPerPage = itemsPerPage;
            this.TotalPages = totalPages;
            this.TotalItems = totalItems;

        }

    }
}