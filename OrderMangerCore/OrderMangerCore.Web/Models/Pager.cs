namespace OrderMangerCore.Web.Models;

public class Pager
{
    public Pager() { }

    public Pager(int itemsCount, int page, int itemsPerPage)
    {
        ItemsCount = itemsCount;
        ItemsPerPage = itemsPerPage;
        PagesCount = (int) Math.Ceiling((decimal) itemsCount / (decimal) itemsPerPage);
        CurrentPage = page;
        StartPage = CurrentPage - 5;
        EndPage = CurrentPage + 4;

        if (StartPage <= 0)
        {
            EndPage = EndPage - (StartPage - 1);
            StartPage = 1;
        }

        if (EndPage > PagesCount)
        {
            EndPage = PagesCount;
            if (EndPage > 10)
            {
                StartPage = EndPage - 9;
            }
        }
    }

    public int ItemsCount { get; set; }
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int PagesCount { get; set; }
    public int StartPage { get; set; }
    public int EndPage { get; set; }
}