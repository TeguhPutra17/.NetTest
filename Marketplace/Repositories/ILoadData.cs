using CategoryLoadData.Models.SQLServer;
using CategoryLoadData.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace CategoryLoadData.Repositories
{
    public interface ILoadDataRepo
    {
        Task<(bool status, string msg, List<LoadData_VM> data)> LoadDataCategory();
    }
    public class ILoadData : ILoadDataRepo 
    {
        private readonly MarketplaceDBContext _context;
        
        public ILoadData(MarketplaceDBContext marketplaceDBContext) 
        {
            _context = marketplaceDBContext;
        }

        public async Task<(bool status, string msg, List<LoadData_VM> data)> LoadDataCategory()
        {
            try
            {
                List<LoadData_VM> list = new List<LoadData_VM>();

                list = await _context.Categories
                    .Where(x => x.IsActive == true)
                    .Select(x => new LoadData_VM
                    {
                        CategoryID = x.CategoryId,
                        CategoryName = x.CategoryName,
                        CategoryDescription = x.Description == null? "" : x.Description,
                        IsActive = x.IsActive
                    })
                    .ToListAsync();

                return (true, "", list);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, new List<LoadData_VM>());
            }
        }
    }
}
