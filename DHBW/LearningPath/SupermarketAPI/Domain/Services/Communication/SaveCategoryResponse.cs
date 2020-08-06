using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category Category { get; set; }

        private SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            Category = category;
        }

        /// <summary>
        /// Success Message
        /// </summary>
        /// <param name="category">Gespeicherte Kategorie</param>
        public SaveCategoryResponse(Category category) : this(true, string.Empty, category)
        {

        }

        /// <summary>
        /// Error Message
        /// </summary>
        /// <param name="message">Fehlernachricht</param>
        public SaveCategoryResponse(string message) : this(false, message, null)
        {

        }
    }
}
