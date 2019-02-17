using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Task 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "Date")]
        [Index]
        public DateTime DueDate { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
