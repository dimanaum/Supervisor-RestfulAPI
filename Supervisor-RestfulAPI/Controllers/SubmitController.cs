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
      System.Diagnostics.Debug.WriteLine("firstName: " + e.FName);
      System.Diagnostics.Debug.WriteLine("lastName: " + e.LName);
      System.Diagnostics.Debug.WriteLine("email: " + e.Email);
      System.Diagnostics.Debug.WriteLine("phoneNumber: " + e.Phone);
      System.Diagnostics.Debug.WriteLine("supervisor: " + e.Supervisor);
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