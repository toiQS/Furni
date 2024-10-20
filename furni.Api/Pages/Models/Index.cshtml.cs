using furni.Application.Interfaces.Service;
using furni.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace furni.api.Models;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IProductService _productService;
    public List<Product> products { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task OnGetAsync()
    {
        products = (await _productService.GetAsync()).ToList();
    }
}
