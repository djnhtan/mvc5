namespace BasicWebsite.Models
{
    using System;
    using System.Security.Principal;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using BasicWebsite.Common;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CompanyModel
    {
        /// <summary>
        /// Company ID.
        /// </summary>
        [Key]
        [Display(Name = "Company ID")]
        [Column("ID", Order = 1)]
        public int ID { get; set; }

        /// <summary>
        /// Company Name.
        /// </summary>
        [Index("NameIndex", IsUnique = true)]
        [Required(ErrorMessage = Common.Constants.Message.Msg1)]
        [MaxLength(255, ErrorMessage = Constants.Message.Msg2), MinLength(2, ErrorMessage = Constants.Message.Msg4)]
        [DataType(DataType.Text)]
        [Display(Name = "Company Name")]
        [Column("Name", Order = 2)]
        public string Name { get; set; }

        /// <summary>
        /// Stock ID of Company.
        /// </summary>
        [MaxLength(255, ErrorMessage = Constants.Message.Msg2), MinLength(2, ErrorMessage = Constants.Message.Msg4)]
        [DataType(DataType.Text)]
        [Display(Name = "Stock ID")]
        [Column("StockId", Order = 3)]
        public string StockId { get; set; }

        /// <summary>
        /// Time create company.
        /// </summary>
        [DataType(DataType.DateTime)]
        [Display(Name = "Founded")]
        [Column("Founded", Order = 4)]
        public DateTime? Founded { get; set; }

        /// <summary>
        /// Director of Company.
        /// </summary>
        [MaxLength(255, ErrorMessage = Constants.Message.Msg2), MinLength(2, ErrorMessage = Constants.Message.Msg4)]
        [DataType(DataType.Text)]
        [Display(Name = "Director")]
        [Column("Director", Order = 5)]
        public string Director { get; set; }

        /// <summary>
        /// Country of Company.
        /// </summary>
        [MaxLength(255, ErrorMessage = Constants.Message.Msg2), MinLength(2, ErrorMessage = Constants.Message.Msg4)]
        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        [Column("Country", Order = 6)]
        public string Country { get; set; }

        /// <summary>
        /// Headquarters of Company.
        /// </summary>
        [MaxLength(255, ErrorMessage = Constants.Message.Msg2), MinLength(2, ErrorMessage = Constants.Message.Msg4)]
        [DataType(DataType.Text)]
        [Display(Name = "Headquarters")]
        [Column("Headquarters", Order = 7)]
        public string Headquarters { get; set; }

        /// <summary>
        /// Company Description.
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Column("Description", Order = 8)]
        public string Description { get; set; }

        /// <summary>
        /// Key word on search.
        /// </summary>
        [StringLength(255, ErrorMessage = Constants.Message.Msg2)]
        [DataType(DataType.Text)]
        [Display(Name = "Tags")]
        [Column("Tags", Order = 9)]
        public string Tags { get; set; }

        /// <summary>
        /// Status of company.
        /// </summary>
        [Display(Name = "Is Active?")]
        [Column("IsActive", Order = 10)]
        public bool IsActive { get; set; }

        /// <summary>
        /// User name create company.
        /// </summary>
        [NotMapped]
        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "Created By")]
        [Column("CreatedBy", Order = 11)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Time create company.
        /// </summary>
        [NotMapped]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created")]
        [Column("Created", Order = 12)]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Last user name modified company.
        /// </summary>
        [NotMapped]
        [StringLength(255)]
        [DataType(DataType.Text)]
        [Display(Name = "Modified By")]
        [Column("ModifiedBy", Order = 13)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Last time modified company.
        /// </summary>
        [NotMapped]
        [DataType(DataType.DateTime)]
        [Display(Name = "Modified")]
        [Column("Modified", Order = 14)]
        public DateTime? Modified {
            get { return DateTime.Now.Date; }
            set { }
        }
    }
}