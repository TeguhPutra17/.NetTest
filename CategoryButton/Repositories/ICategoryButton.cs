using CategoryButton.Models.SQLServer;
using CategoryButton.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace CategoryButton.Repositories
{
    public interface ICategoryButtonRepo
    {
        Task<ServiceResponseOutput> CreateCategory(RequestCreateCategory req);
        Task<ServiceResponseOutput> DeleteCategory(RequestDeleteCategory req);
        Task<ServiceResponseOutput> UpdateCategory(RequestUpdateCategory req);
    }

    public class ICategoryButton : ICategoryButtonRepo
    {
        private readonly MarketplaceDBContext _context;
        public ICategoryButton(MarketplaceDBContext context)
        {
            _context = context;
        }


        //Create Category
        public async Task<ServiceResponseOutput> CreateCategory(RequestCreateCategory req)
        {
            ServiceResponseOutput res = new ServiceResponseOutput();
            try
            {
                int code = 0; ;
                string msg = "";
                bool status = false;

                Category trans = new Category();

                using (TransactionScope trx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var getUniqueFields = await _context.Categories.Where(x => x.CategoryName == req.CategoryName && x.Description == req.CategoryDescription && x.IsDelete == false).FirstOrDefaultAsync().ConfigureAwait(false);
                    if (getUniqueFields == null)
                    {
                        trans.CategoryName = req.CategoryName;
                        trans.Description = req.CategoryDescription;
                        trans.IsActive = true;
                        trans.IsDelete = false;
                        trans.CreatedTime = DateTime.Now;

                        await _context.Categories.AddAsync(trans).ConfigureAwait(false);
                        await _context.SaveChangesAsync().ConfigureAwait(false);

                        code = 1;
                        msg = "Berhasil Create Data";
                        status = true;
                    }
                    else
                    {
                        code = -1;
                        status = false;
                        msg = "Data Sudah Ada!";
                    }
                    trx.Complete();
                }
                res.Code = code;
                res.Status = status;
                res.Message = msg;
            }
            catch (Exception ex)
            {
                res.Code = -1;
                res.Status = false;
                res.Message = ex.Message;
            }
            return res;
        }
        
        //Delete Category
        public async Task<ServiceResponseOutput> DeleteCategory(RequestDeleteCategory req)
        {
            ServiceResponseOutput res = new ServiceResponseOutput();
            try
            {
                int code = 0; ;
                string msg = "";
                bool status = false;

                using(TransactionScope trx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var category = await _context.Categories.Where(x => x.CategoryId == req.CategoryId).FirstOrDefaultAsync().ConfigureAwait(false);
                    category.IsDelete = true;
                    category.DeletedTime = DateTime.Now;

                    _context.Entry(category).State = EntityState.Modified;
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    trx.Complete();
                }
                res.Code = 1;
                res.Status = true;
                res.Message = "Berhasil Menghapus Data";
            }
            catch(Exception ex)
            {
                res.Code = -1;
                res.Status = false;
                res.Message = ex.Message;
            }
            return res;
        }
    
        //UpdateCategory
        public async Task<ServiceResponseOutput> UpdateCategory(RequestUpdateCategory req)
        {
            ServiceResponseOutput res = new ServiceResponseOutput();
            try
            {
                int code = 0; ;
                string msg = "";
                bool status = false;

                using (TransactionScope trx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var category = await _context.Categories.Where(x => x.CategoryId == req.CategoryId).FirstOrDefaultAsync().ConfigureAwait(false);
                    category.CategoryName = req.CategoryName;
                    category.Description = req.CategoryDescription;
                    category.UpdatedTime = DateTime.Now;

                    _context.Entry(category).State = EntityState.Modified;
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    trx.Complete();
                }
                res.Code = code;
                res.Status = status;
                res.Message = msg;
            }
            catch (Exception ex)
            {
                res.Code = -1;
                res.Status = false;
                res.Message = ex.Message;
            }
            return res;
        }

    }
}

