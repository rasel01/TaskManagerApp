using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.UIModels
{
    public class TaskUIModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }
    }
}
