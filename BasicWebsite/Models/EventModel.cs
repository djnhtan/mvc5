using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using BasicWebsite.Common;

namespace BasicWebsite.Models
{
    public class EventModel
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }

        [Display(Name = "Event Status")]
        public string Status { get; set; }

        [Required(ErrorMessage=Constants.Message.Msg1)]
        [StringLength(255,ErrorMessage=Constants.Message.Msg2,MinimumLength=10)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = Constants.Message.Msg1)]
        [StringLength(255, ErrorMessage = Constants.Message.Msg2, MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string Organizer { get; set; }

        [Required(ErrorMessage = Constants.Message.Msg1)]
        [DataType(DataType.Text)]
        public string Type { get; set; }

        [Required(ErrorMessage = Constants.Message.Msg1)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = Constants.Message.Msg1)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }

    public class BasicWebDbContext : DbContext
    {
        public BasicWebDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<EventModel> EvenModels { get; set; }

        public DbSet<NewsModel> NewsModels { get; set; }

        public DbSet<CompanyModel> CompanyModels { get; set; }
    }
}