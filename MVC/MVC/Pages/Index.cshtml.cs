using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Models;
using MVC.Models.Interface;

namespace MVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly InventoryManager _iManager;

        public IndexModel(InventoryManager iManger)
        {
            _iManager = iManger;
        }

        public IEnumerable<Inventory> ProductList { get; set; }
        public async Task OnGet()
        {
            ProductList = await _iManager.GetInventories();

        }
    }
}
