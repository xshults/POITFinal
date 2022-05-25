using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using SkuskaApp.DTOs;
using SkuskaApp.Services;

namespace SkuskaApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController : Controller
{

    private readonly ILogger<MainController> _logger;
    private ICOMService comService;
    private IFileService fileService;
    public MainController(ILogger<MainController> logger, ICOMService comService, IFileService fileService)
    {
        _logger = logger;
        this.comService = comService;
        this.fileService = fileService;
    }

    [HttpGet("onopen", Name = "On Open")]
    public StatusCodeResult onButtonOpen()
    {
        Console.WriteLine("GetConnected");
        
        PortBroker.printValue();
        return StatusCode(200);
    }
    
    [HttpGet("getvalue", Name = "Get value")]
    public ActionResult<string> getValue()
    {
        Console.WriteLine("GetValue");

        Response.StatusCode = 200;
        DataDTO response = PortBroker.getData(PortBroker.multiplier);
        string jsonObject = JsonSerializer.Serialize(response);
        this.fileService.WriteToJSON(response);
        Console.WriteLine(jsonObject);
        return jsonObject;
    }

    [HttpGet("savedb")]
    public void saveToDb()
    {
        Console.WriteLine("SaveStart");
        comService.PostDataToDB(PortBroker.getData(1.0f));
        
    }

    [HttpPost("multiplier", Name = "Multilier")]
    public StatusCodeResult setMultiplier([FromBody] MultiplierDto newVal)
    {
        Console.WriteLine("New multiplier " + newVal.data);
        PortBroker.multiplier = float.Parse(newVal.data);
        return new StatusCodeResult(200);
    }

    [HttpGet("getall")]
    public List<DataDTO> getAll()
    {
        return this.fileService.getAll();
    }
}