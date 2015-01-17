using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicWebsite.Common;

namespace BasicWebsite.Models
{
    public class NewsModel
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }

    }
}