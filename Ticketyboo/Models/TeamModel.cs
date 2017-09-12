using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCP.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}