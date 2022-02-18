using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi1.Models;

namespace webapi1.Services
{
    public interface ITaskService
    {
        List<TaskModel> GetAll();

        TaskModel Get(Guid id);

        void Add(TaskModel task);

        void Update(Guid id, TaskModel task);

        void Delete(Guid id);

        void Add(List<TaskModel> taskslist);

        void Delete(List<Guid> idlist);
    
    }
}