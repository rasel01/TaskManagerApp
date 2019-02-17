using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.UIModels
{
    public class SubTaskUIModel
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "Date")]
        public DateTime TaskDueDate { get; set; }

        public string TaskName { get; set; }

    }
}
