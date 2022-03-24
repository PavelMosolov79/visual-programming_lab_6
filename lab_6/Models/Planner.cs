using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6.Models
{
    public class Planner
    {
        public string Title 
        { 
            get; set; 
        }
        public string Description 
        { 
            get; set; 
        }
        public Planner(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}
