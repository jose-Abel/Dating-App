namespace API.Helpers
{
  public class PaginationHeader
  {
    public PaginationHeader(int currentPage, int itemsPerPage, int totalIems, int totalPages)
    {
      CurrentPage = currentPage;
      ItemsPerPage = itemsPerPage;
      TotalIems = totalIems;
      TotalPages = totalPages;
    }

    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalIems { get; set; }
    public int TotalPages { get; set; }
  }
}