using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.UIModels;
using Task = TaskManager.Models.Task;

namespace TaskManager.Service
{

    public class TaskService
    {
        private readonly TaskManagerContext _db = new TaskManagerContext();

        public List<TaskUIModel> GetAll()
        {
            var dbset = _db.Tasks.AsQueryable();
            return dbset.Select(x => new TaskUIModel() { Id = x.Id, Name = x.Name, DueDate = x.DueDate }).ToList();


        }


        public int Save(Task task)
        {
            Task dbTask;
            if (task.Id > 0)
            {
                dbTask = _db.Tasks.Find(task.Id);
                if (dbTask != null)
                {
                    dbTask.Name = task.Name;
                    dbTask.ModifiedDate = DateTime.Now;
                    dbTask.DueDate = task.DueDate;



                }
            }
            else
            {
                task.EntryDate = DateTime.Now;
                task.ModifiedDate = DateTime.Now;
                dbTask = _db.Tasks.Add(task);
            }


            _db.SaveChanges();
            return dbTask.Id;

        }

        public Task GetById(int id)
        {
            var task = _db.Tasks.Find(id);

            Task result = new Task()
            {
                DueDate = task.DueDate.Date,
                EntryDate = task.EntryDate,
                Id = task.Id,
                ModifiedDate = task.ModifiedDate,
                Name = task.Name
            };
            return result;
        }


        public bool Delete(int id)
        {
            Task task = _db.Tasks.Find(id);

            if (task != null)
            {
                _db.Tasks.Remove(task);
                _db.SaveChanges();
            }
            return true;
        }
    }
}
