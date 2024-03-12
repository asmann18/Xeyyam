using Microsoft.AspNetCore.Mvc;
using Xeyyam.Repositories.Abstract;
using Xeyyam.ViewModels.CategoryViewModels;

namespace Xeyyam.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryRepository _repository;

    public HomeController(ICategoryRepository repository)
    {
        _repository = repository;
    }


  
}
