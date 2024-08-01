using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Blog.Models;

namespace Razor_Blog.Pages;

public class CreateArticleModel : PageModel
{
    private readonly BlogContext _context;

    public CreateArticleModel(BlogContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        
    }

    public void OnPost(CreateArticle command)
    {
        var article = new Article(command.Title, command.Picture, command.PictureAlt, command.PictureTitle,
            command.ShortDescription, command.Body);
        _context.Articles.Add(article);
        _context.SaveChanges();
        TempData["success"] = "مقاله با موفقیت ذخیره شده";
    }
}