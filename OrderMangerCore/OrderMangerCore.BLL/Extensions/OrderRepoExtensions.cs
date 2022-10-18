using OrderMangerCore.DAL.Repositories;

namespace OrderMangerCore.BLL.Extensions;

public static class OrderRepoExtensions
{
    public static int GetFirstId(this OrderRepo repo)
    {
        return repo.Table.OrderBy(o => o.Id).First().Id;
    }
}