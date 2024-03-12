using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xeyyam.Models;
using Xeyyam.ViewModels.CategoryViewModels;

namespace Xeyyam.Services.Abstract;

public interface ICategoryService
{
    Task<bool> CreateAsync(CategoryCreateVM vm, ModelStateDictionary ModelState);
    Task<bool?> UpdateAsync(CategoryUpdateVM vm, ModelStateDictionary ModelState);
    Task<CategoryUpdateVM?> GetUpdateVMAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<Category?> GetByIdAsync(int id);
    Task<List<Category>?> GetAllAsync();
}
