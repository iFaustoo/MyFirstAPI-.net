var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! Creating my first API");

var myTasks = new List<Task>
{
    new Task(1, "Creating an API in C#", true),
    new Task(2, "Migrate the calculator", false),
};

app.MapGet("/tasks", () =>
{
   return myTasks; 
});

app.MapGet("tasks/{id}", (int id) =>
{
    var taskFound = myTasks.FirstOrDefault(t => t.Id == id);

    if (taskFound != null)
    {
        return Results.Ok(taskFound);
    }
    else
    {
        return Results.NotFound("The id you were trying to match does not exist");
    }
});

app.MapPost("/tasks", (Task newTask) =>
{
   myTasks.Add(newTask);
   return myTasks;
});

app.Run();

record Task(int Id, string Description, bool Completed);