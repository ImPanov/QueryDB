using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Packet.Shared;
using QueryDB.Models;

namespace QueryDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext db;
        public IEnumerable<ProductAndCategory> Data { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext injectContext)
        {
            db = injectContext;
            _logger = logger;
        }
        public void OnGet()
        {
            Data = db.Products.GroupJoin(
                db.Categories,
                product => product.CategoryId,
                category => category.CategoryId,
                (product, category) => new
                {
                    product, category
                }).SelectMany(x=>x.category.DefaultIfEmpty(),
                (product,category)=> new ProductAndCategory {
                    ProductName=product.product.ProductName,
                    Cost = product.product.Cost,
                    Count = product.product.Count,
                    CategoryName = category.CategoryName ?? "No Category" 
                });
            // v2
            //Data = db.Products.Include(p => p.Category).Select(product => new ProductAndCategory {
            //    ProductName = product.ProductName,
            //    Cost = product.Cost,
            //    Count = product.Count,
            //    CategoryName = product.Category.CategoryName ?? "No Category"
            //});
        }
    }
}