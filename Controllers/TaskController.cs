using Microsoft.AspNetCore.Mvc;

namespace webapi1.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    private static List<Task> tasks = new List<Task>(){
        new Task{
            Title = "task 1",
            Completed = true
        },
        new Task{
            Title = "task 2",
            Completed = false
        },
        new Task{
            Title = "task 3",
            Completed = false
        }
    };

    public TaskController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<Task> Get(){
        return tasks;
    }

    // [HttpGet("{id}")]
    // public Task Get(Guid id){
    //     return tasks.FirstOrDefault(t => t.Id == id);
    // }

    [HttpGet("{title}")]
    public Task Get(string title){
        //var result = tasks.Where(t => t.Title.Contains(title)).FirstOrDefault();
        var result = tasks.Where(t => String.Equals(t.Title,title)).FirstOrDefault();
        return result;
    }

    [HttpPost]
    public void Add([FromBody] Task task){
        
        // tasks.Add(task);

        var taskAdd = new Task{
                Title = task.Title,
                Completed = task.Completed
            };
        var check = tasks.Where(t => t.Id == taskAdd.Id).Count();
        if(check == 0){
            tasks.Add(taskAdd);
        }
    }

    [HttpPut("{title}")]
    public void Update(string title, [FromBody] Task task){
        var taskUpdate = tasks.Where(t => String.Equals(t.Title,title)).FirstOrDefault();
        if(taskUpdate != null){
            taskUpdate.Title = task.Title;
            taskUpdate.Completed = task.Completed;
        }
    }

    [HttpDelete]
    public void Delete(string title){
        var task = tasks.Where(t => String.Equals(t.Title,title)).FirstOrDefault();
        if(task != null){
            tasks.Remove(task);
        }
    }

    [HttpPost("{addmultiple}")]
    public void Add(bool addmultiple, List<Task> taskslist){
        if(addmultiple == true){
            foreach(Task t in taskslist){
                tasks.Add(t);
            }
        }
    }

    [HttpDelete("{deletemultiple}")]
    public void Delete(bool deletemultiple, List<string> titlelist){
        if (deletemultiple == true){
            foreach(string title in titlelist){
                var task = tasks.Where(t => String.Equals(t.Title,title)).FirstOrDefault();
                if(task != null){
                    tasks.Remove(task);
                }
            }
        }
    }
}
