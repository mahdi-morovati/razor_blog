using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Blog.Models;

namespace Razor_Blog.Pages;

public class ArticleDetails : PageModel
{
    public ArticleViewModel Article { get; set; }
    private readonly BlogContext _context;

    public ArticleDetails(BlogContext context)
    {
        _context = context;
    }

    public void OnGet(int id)
    {
        Article = _context.Articles.Select(x => new ArticleViewModel
        {
            Id = x.Id,
            Title = x.Title,
            Body = x.Body,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
        }).FirstOrDefault(x => x.Id == id);
    }
}