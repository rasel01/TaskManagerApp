using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class SubTask
    {
        public int Id { get; set; }

       
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "Date")]
        [Index]
        public DateTime Timeline { get; set; }

        public int taskId { get; set; }

        [ForeignKey("taskId")]
        public virtual  Task task { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
