using Microsoft.AspNetCore.Mvc;
using webapi1.Services;
using webapi1.Models;

namespace webapi1.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    private ITaskService _taskservice;

    public TaskController(ILogger<TaskController> logger, ITaskService taskservice)
    {
        _logger = logger;
        _taskservice = taskservice;
    }

    [HttpGet]
    public List<TaskModel> Get(){
        return _taskservice.GetAll();
    }

    [HttpGet("{id}")]
    public TaskModel Get(Guid id){
       return _taskservice.Get(id);
    }

    [HttpPost]
    public void Add([FromBody] TaskModel task){
        _taskservice.Add(task);
    }

    [HttpPut("{id}")]
    public void Update(Guid id, [FromBody] TaskModel task){
        _taskservice.Update(id, task);
    }

    [HttpDelete("{id}")]
    public void Delete(Guid id){
        _taskservice.Delete(id);
    }

    [HttpPost("Add/Multiple")]
    public void Add(List<TaskModel> taskslist){
        _taskservice.Add(taskslist);
    }

    [HttpDelete("Delete/Multiple")]
    public void Delete(List<Guid> idlist){
       _taskservice.Delete(idlist);
    }
}
