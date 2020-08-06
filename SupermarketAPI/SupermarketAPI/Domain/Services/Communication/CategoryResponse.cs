using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; set; }

        private CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        /// <summary>
        /// Success Message
        /// </summary>
        /// <param name="category">Gespeicherte Kategorie</param>
        public CategoryResponse(Category category) : this(true, string.Empty, category)
        {

        }

        /// <summary>
        /// Error Message
        /// </summary>
        /// <param name="message">Fehlernachricht</param>
        public CategoryResponse(string message) : this(false, message, null)
        {

        }
    }
}
