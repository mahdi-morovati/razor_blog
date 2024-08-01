using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Blog.Models;

namespace Razor_Blog.Pages;

public class IndexModel : PageModel
{
    public List<ArticleViewModel> Articles { get; set; }
    private readonly BlogContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, BlogContext context)
    {
        _logger = logger;
        _context = context;
    }

    // public IActionResult OnGetLoad()
    // {
    //     return RedirectToPage("./index");
    //     return Page();
    // }

    public void OnGet()
    {
        Articles = _context.Articles.Select(x => new ArticleViewModel
        {
            Id = x.Id,
            Title = x.Title,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            ShortDescription = x.ShortDescription,
            // Body = x.Body,
            // CreationDate = x.CreationDate,
        }).OrderByDescending(x => x.Id).ToList();
    }
}