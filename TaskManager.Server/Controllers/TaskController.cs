using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;
using TaskManager.Service;
using TaskManager.UIModels;

namespace TaskManager.Server.Controllers
{
    public class TaskController : ApiController
    {

        TaskService service = new TaskService();
        public ResponseModel Get()
        {

            ResponseModel response;

            try
            {
                List<TaskUIModel> tasks = service.GetAll();
                response = new ResponseModel(tasks);
            }
            catch (Exception exception)
            {

                response = new ResponseModel(null, false, "Error Occurred", exception);
            }

            return response;
        }

        public ResponseModel Get(int id)
        {
            ResponseModel response;
            try
            {
                Task task = service.GetById(id);

                response = new ResponseModel(task);
            }
            catch (Exception exception)
            {

                response = new ResponseModel(null, false, "Error Occurred", exception);
            }
            return response;

        }

        //public ResponseModel Post(Task taskObj)
        //{
        //    ResponseModel response;

        //    try
        //    {
        //        int id = service.Save(taskObj);
        //        response = id > 0 ? new ResponseModel(id) : new ResponseModel(null, false, "Couldn't Save");
        //    }
        //    catch (Exception exception)
        //    {
        //        response = new ResponseModel(null, false, exception.Message, exception);

        //    }
        //    return response;
        //}

        public ResponseModel Post(Task task)
        {
            ResponseModel response = null;
            try
            {
                int id = service.Save(task);
                response = id > 0 ? new ResponseModel(id) : new ResponseModel(null, false, "Couldn't Save");

            }
            catch (Exception exception)
            {
                response = new ResponseModel(null, false, exception.Message, exception);
            }

            return response;

        }

        public ResponseModel Delete(int id)
        {
            ResponseModel response = null;
            try
            {
                bool delete = service.Delete(id);
                response = delete ? new ResponseModel(id) : new ResponseModel(null, false, "Couldn't Delete");

            }
            catch (Exception exception)
            {
                response = new ResponseModel(null, false, exception.Message, exception);
            }

            return response;
        }


    }
}
