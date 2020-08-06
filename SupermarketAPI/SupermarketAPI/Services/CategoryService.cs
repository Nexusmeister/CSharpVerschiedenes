using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new KeyNotFoundException($"ID darf nicht kleiner 1 sein -> {id}");
                }

                var existingCat = await _categoryRepository.FindCategory(id);
                if (existingCat == null)
                {
                    return new CategoryResponse($"Keine Kategorie gefunden (ID = {id}).");
                }

                _categoryRepository.Remove(existingCat);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCat);
            }
            catch (Exception e1)
            {
                return new CategoryResponse($"Es ist ein Fehler beim Löschen einer Kategorie aufgetreten: {e1.Message}");
            }
            

        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                if (category.Id < 1)
                {
                    throw new KeyNotFoundException($"Fehlerhafte ID vergeben: {category.Id}");
                }

                return new CategoryResponse(category);
            }
            catch(KeyNotFoundException e2)
            {
                return new CategoryResponse($"Es ist ein Fehler aufgetreten: {e2.Message}");
            }
            catch (Exception e1)
            {
                return new CategoryResponse($"Es ist ein Fehler beim Speichern der Kategorie aufgetreten: {e1.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            try
            {
                
                // Unzulässige IDs dürfen nicht angegeben werden
                if (id < 1)
                {
                    throw new KeyNotFoundException("ID darf nicht kleiner 1 sein");
                }

                var existingCategory = await _categoryRepository.FindCategory(id);

                if (existingCategory == null)
                {
                    return new CategoryResponse("Category nicht gefunden.");
                }

                // Wir brauchen nichts aktualisieren, wenn der Name gleich ist
                if (existingCategory.Name.Equals(category.Name))
                {
                    throw new DuplicateNameException("Der Name darf nicht gleich sein.");
                }

                existingCategory.Name = category.Name;

                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return  new CategoryResponse(existingCategory);
            }
            catch (Exception e1)
            {
                return new CategoryResponse($"Es ist ein Fehler beim Updaten einer Kategorie aufgetaucht: {e1.Message}");
            }
        }
    }
}
