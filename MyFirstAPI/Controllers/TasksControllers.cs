using Microsoft.AspNetCore.Mvc;
using MyFirstApi;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static readonly List<Tarea> MyTasks = new()
    {
        new Tarea(1, "Learning C#", true),
        new Tarea(2, "Migrate the calculator", false)
    };
    [HttpGet]
    public IActionResult ObtainAll()
    {
        return Ok(MyTasks);
    }
}