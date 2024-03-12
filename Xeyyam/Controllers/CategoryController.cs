using Microsoft.AspNetCore.Mvc;
using Xeyyam.Services.Abstract;
using Xeyyam.ViewModels.CategoryViewModels;

namespace Xeyyam.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.GetAllAsync();
        if (result is null)
            return NotFound();
        return View(result);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateVM vm)
    {
        var result = await _service.CreateAsync(vm, ModelState);

        if (!result)
            return View(vm);

        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await _service.GetUpdateVMAsync(id);
        if (result is null)
            return NotFound();

        return View(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(CategoryUpdateVM vm)
    {
        var result=await _service.UpdateAsync(vm, ModelState);

        if (result is null)
            return NotFound();
        else if (result is false)
            return View(vm);

        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Delete(int id)
    {
        var result=await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return RedirectToAction("Index");
    }




}
