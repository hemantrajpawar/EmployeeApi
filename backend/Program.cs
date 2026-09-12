using Backend.Services;
using Backend.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Backend.DbContext;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // tells that register the controller related service with asp.net core dependency injection container

builder.Services.AddScoped<IUserService, UserService>(); //ASP.NET Core DI container, whenever somebody asks for UserService, you know how to create/provide one.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);


var app=builder.Build();
app.MapControllers(); // tells that link to controller folder 


// app.MapGet("/",(HttpContext Context)=>{
//     // await Context.Response.WriteAsJsonAsync("Hello Raj");
//     return "Hello";
// });

// app.MapGet("/user",(string?name,int? age)=>{
//     return $"I am a new User - {name} & having age {age}";
// });

// app.MapGet("/user/id/{id}",(int id)=>{
//     return $"user having id : {id}";
// });

// app.MapGet("/user/name/{name}",(string name)=>{
//     return $"user having name : {name}";
// });

// app.MapGet("/getuser",()=>{
//     return Results.Ok(UserReg.GetUser());
// });

// app.MapPost("/user", (User user) =>
// {
//     UserReg.AddUser(user);

//     return Results.Created($"/user/{user.Id}", user);
// });

// app.MapPost("/user/{id}",(int id ,User user)=>{
//     return $"User having id - {id} address by name -{user.Name} ";
// });

app.Run();

// class User
// {
//     public int Id { get; set; }
//     public string Name { get; set; } = "";
//     public int Age { get; set; }
// }

// static class UserReg{
//     public static List<User>user=new List<User>();
//     public static void AddUser(User u){
//         user.Add(u);
//     }
//     public static List<User> GetUser(){
//         return user;
//     }
// }