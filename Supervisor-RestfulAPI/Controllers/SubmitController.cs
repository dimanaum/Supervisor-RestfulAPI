using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Web;

namespace Supervisor_RestfulAPI.Controllers
{
  [ApiController]
  public class SubmitController : ControllerBase
  {
    private readonly ILogger<SupervisorController> _logger;

    private void PrintObj(Employee e)
    {
      Console.WriteLine("firstName: " + e.FName);
      Console.WriteLine("lastName: " + e.LName);
      Console.WriteLine("email: " + e.Email);
      Console.WriteLine("phoneNumber: " + e.Phone);
      Console.WriteLine("supervisor: " + e.Supervisor);
    }

    public SubmitController(ILogger<SupervisorController> logger)
    {
      _logger = logger;
    }

    [HttpPost]
    [Route("api/submit")]
    public void Post(Employee e)
    {
      PrintObj(e);

      //TODO: Impliment more than response codes.
      try
      {
        if (e.FName == "" || e.LName == "" || e.Supervisor == "")
        {
          Response.StatusCode = 402;
          return;
        }

        Response.StatusCode = 200;
      }
      catch(Exception f)
      {
        Console.WriteLine("Error encountered while processing POST request: " + f.Message);
      }
    }
  }
}