var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World! Creating my first API");

var myTasks = new List<Task>
{
    new Task(1, "Creating an API in C#", true),
    new Task(2, "Migrate the calculator", false),
    new Task(3, "Go to the gym", true),
    new Task(4, "Take a walk", true),
    new Task(5, "Study important C# concepts", false)
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

app.MapDelete("/tasks/{id}", (int id) =>
{
    var taskToDelete = myTasks.FirstOrDefault(t => t.Id == id);

    if (taskToDelete == null)
    {
        return Results.NotFound("The task you are trying to eliminate was not found");
    }

    myTasks.Remove(taskToDelete);
    return Results.Ok(myTasks);
});

app.MapPut("/tasks/{id}", (int id, Task newTask) =>
{
    var taskForReplace = myTasks.FirstOrDefault(t => t.Id == id);

    if (taskForReplace == null)
    {
        return Results.NotFound("The task you are trying to replace was not found");
    }

    var index = myTasks.IndexOf(taskForReplace);
    myTasks[index] = newTask;
    return Results.Ok(myTasks);
});

app.Run();

record Task(int Id, string Description, bool Completed);