using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Models;
using TaskManager.UIModels;
using SubTask = TaskManager.Models.SubTask;

namespace TaskManager.Service
{
    public class SubTaskService
    {
        private readonly TaskManagerContext _db = new TaskManagerContext();

        public List<SubTaskUIModel> GetAll()
        {
            var dbset = _db.SubTasks.AsQueryable();
            return dbset.Select(x => new SubTaskUIModel() { Id = x.Id, Name = x.Name, Description = x.Description, TaskDueDate = x.task.DueDate, TaskName = x.task.Name }).ToList();


        }


        public int Save(SubTask subTask)
        {
            //subTask.EntryDate = DateTime.Now;
            //subTask.ModifiedDate = DateTime.Now;
            //var result = _db.SubTasks.Add(subTask);
            //_db.SaveChanges();
            //return result.Id;



            SubTask dbSubTask;
            if (subTask.Id > 0)
            {
                dbSubTask = _db.SubTasks.Find(subTask.Id);
                if (dbSubTask != null)
                {
                    dbSubTask.Name = subTask.Name;
                    dbSubTask.ModifiedDate = DateTime.Now;
                    dbSubTask.Description = subTask.Description;
                    dbSubTask.taskId = subTask.taskId;



                }
            }
            else
            {
                subTask.EntryDate = DateTime.Now;
                subTask.ModifiedDate = DateTime.Now;
                dbSubTask = _db.SubTasks.Add(subTask);
            }


            _db.SaveChanges();
            return dbSubTask.Id;

        }

        public List<SubTaskUIModel> GetAllByTask(int taskId)
        {
            var dbset = _db.SubTasks.Where(x => x.taskId == taskId).AsQueryable();
            return dbset.Select(x => new SubTaskUIModel() { Id = x.Id, Name = x.Name, Description = x.Description, TaskDueDate = x.task.DueDate })
                .ToList();
        }

        public SubTask GetById(int id)
        {
            SubTask subTask = _db.SubTasks.Find(id);
            return subTask;
        }

        public bool Delete(int id)
        {
            SubTask subTask = _db.SubTasks.Find(id);
            if (subTask != null)
            {
                _db.SubTasks.Remove(subTask);
                _db.SaveChanges();

            }

            return true;
        }
    }
}
