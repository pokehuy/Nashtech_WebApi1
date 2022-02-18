using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi1.Models;

namespace webapi1.Services
{
    public class TaskService : ITaskService
    {
        public static List<TaskModel> tasks = new List<TaskModel>(){
            new TaskModel{
                 Title = "task 1",
                 IsCompleted = true
            },
            new TaskModel{
                 Title = "task 2",
                 IsCompleted = false
            },
            new TaskModel{
                 Title = "task 3",
                 IsCompleted = false
            }
        };

        public List<TaskModel> GetAll(){
            return tasks;
        }

        public TaskModel Get(Guid id){
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TaskModel task){
            var taskAdd = new TaskModel{
                Title = task.Title,
                IsCompleted = task.IsCompleted
            };
            var check = tasks.Where(t => t.Id == taskAdd.Id).Count();
            if(check == 0){
                tasks.Add(taskAdd);
            }
        }

        public void Update(Guid id, TaskModel task){
            var taskUpdate = tasks.FirstOrDefault(t => t.Id == id);
            if(taskUpdate != null){
                taskUpdate.Title = task.Title;
                taskUpdate.IsCompleted = task.IsCompleted;
            }
        }

        public void Delete(Guid id){
            var taskDelete = tasks.FirstOrDefault(t => t.Id == id);
            if(taskDelete != null){
                tasks.Remove(taskDelete);
            }
        }

        public void Add(List<TaskModel> taskslist){
            foreach(TaskModel taskAdd in taskslist){
                var check = tasks.FirstOrDefault(t => t.Id == taskAdd.Id);
                if(check == null){
                    tasks.Add(taskAdd);
                }
            }
        }

        public void Delete(List<Guid> idlist){
            foreach(Guid id in idlist){
                var taskDelete = tasks.FirstOrDefault(t => t.Id == id);
                if(taskDelete != null){
                    tasks.Remove(taskDelete);
                }
            }
        }    
    
    }
}