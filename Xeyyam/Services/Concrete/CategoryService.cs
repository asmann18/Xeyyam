using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Xeyyam.Models;
using Xeyyam.Repositories.Abstract;
using Xeyyam.Services.Abstract;
using Xeyyam.ViewModels.CategoryViewModels;

namespace Xeyyam.Services.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CreateAsync(CategoryCreateVM vm, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        Category category = new()
        {
            Name = vm.Name
        };

        await _repository.CreateAsync(category);
        await _repository.SaveChangesAsync();

        return true;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _repository.GetSingleAsync(x => x.Id == id);
        if (category is null)
            return false;

        _repository.Delete(category);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<List<Category>?> GetAllAsync()
    {
        var categories = await _repository.GetAll().ToListAsync();

        return categories;
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        var category = await _repository.GetSingleAsync(x => x.Id == id);

        return category;

    }

    public async Task<CategoryUpdateVM?> GetUpdateVMAsync(int id)
    {
        var category = await _repository.GetSingleAsync(x => x.Id == id);
        if (category is null)
            return null;

        CategoryUpdateVM vm = new() { Id = id, Name = category.Name };

        return vm;
    }

    public async Task<bool?> UpdateAsync(CategoryUpdateVM vm, ModelStateDictionary ModelState)
    {
        var existCategory = await _repository.GetSingleAsync(x => x.Id == vm.Id);
        if (existCategory is null)
            return null;

        if (!ModelState.IsValid)
            return false;


        existCategory.Name=vm.Name;

        _repository.Update(existCategory);
        await _repository.SaveChangesAsync();

        return true;

    }
}
