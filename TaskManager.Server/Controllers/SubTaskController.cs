using System;
using System.Collections.Generic;
using System.Web.Http;
using TaskManager.Models;
using TaskManager.Service;
using TaskManager.UIModels;

namespace TaskManager.Server.Controllers
{
    public class SubTaskController : ApiController
    {
        private readonly SubTaskService _service = new SubTaskService();
        public ResponseModel Get(int taskId)
        {

            ResponseModel response;

            try
            {
               
                List<SubTaskUIModel> subTasks = taskId == 0 ? _service.GetAll() : _service.GetAllByTask(taskId);
                response = new ResponseModel(subTasks);
            }
            catch (Exception exception)
            {

                response = new ResponseModel(null, false, "Error Occurred", exception);
            }

            return response;
        }


        public ResponseModel GetDetail(int id)
        {
            ResponseModel response = null;
            try
            {
                if (id > 0)
                {
                   SubTask subTask=  _service.GetById(id);
                    response = new ResponseModel(subTask);
                }
                else
                {
                    response = new ResponseModel(isSuccess:false,message:"Id cannot be zero");
                }
            }
            catch (Exception exception)
            {
               response = new ResponseModel(null,false,"Error Occured",exception);
            }
            return response;
        }

        public ResponseModel Post(SubTask subTask)
        {
            ResponseModel response = null;
            try
            {
                subTask.task = null;
                int id = _service.Save(subTask);
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
                bool delete = _service.Delete(id);
                response = delete ? new ResponseModel(id) : new ResponseModel(null, false, "Couldn't Delete");
            }
            catch (Exception exception)
            {
                response = new ResponseModel(null, false, "Error Occurred", exception);
            }
            return response ;
        }





    }
}
