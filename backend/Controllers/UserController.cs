using Microsoft.AspNetCore.Mvc;

using Backend.DTOs;
using Backend.Interfaces.Services;


[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        var user = await _userService.CreateUser(dto);

        return Created("/api/users", user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute]int id)
    {
        var user = await _userService.GetUser(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok( await _userService.GetUsers());
    }
}

//Model Binding : which helps to know the apicontroller that from where the parameter comes from like from body , from header , from query or from route
// that's why we use model binders i.e. 
// Attribute	 Gets data from	  Example
// [FromRoute]	 URL route	       /users/25
// [FromQuery]	 Query string      /api/user?name=Raj
// [FromBody]	 Request body	   { "name":"Raj" }
// [FromHeader]	 HTTP headers	   Authorization: ...


// ControllerBase is a base class provided by asp.net for api controllers 

// it gives things like: 
// Ok()
// BadRequest()
// NotFound()
// Created()
// NoContent()
// Unauthorized()
// Forbid()
// instead of return Results.Ok() ,, use return Ok()