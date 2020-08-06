using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                if (category.Id < 1)
                {
                    throw new KeyNotFoundException($"Fehlerhafte ID vergeben: {category.Id}");
                }
                return new SaveCategoryResponse(category);
            }
            catch(KeyNotFoundException e2)
            {
                return new SaveCategoryResponse($"Es ist ein Fehler aufgetreten: {e2.Message}");
            }
            catch (Exception e1)
            {
                return new SaveCategoryResponse($"Es ist ein Fehler beim Speichern der Kategorie aufgetreten: {e1.Message}");
            }
        }
    }
}
