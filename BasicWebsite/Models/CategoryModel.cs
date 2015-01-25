namespace BasicWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class CategoryModel
    {
        /// <summary>
        /// Category ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Category Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Status of category.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// User name create category.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Time create category.
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Last user name modified category.
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Last time modified category.
        /// </summary>
        public DateTime? Modified { get; set; }
    }
}