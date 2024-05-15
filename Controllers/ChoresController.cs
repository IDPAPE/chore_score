using Microsoft.AspNetCore.Http.HttpResults;

namespace chore_score.Controllers;
[ApiController]
[Route("api/chores")]

public class ChoresController : ControllerBase
{
    private readonly ChoresService _choresService;
    public ChoresController(ChoresService choresService)
    {
        _choresService = choresService;
    }


    [HttpGet]
    public ActionResult<List<Chore>> GetAllChores()
    {
        try
        {
            List<Chore> chores = _choresService.GetAllChores();
            return Ok(chores);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{choreId}")]
    public ActionResult<Chore> GetChoreById(int choreId)
    {
        try
        {
            Chore chore = _choresService.GetChoreById(choreId);
            return chore;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public ActionResult<Chore> CreateChore([FromBody] Chore choreData)
    {
        try
        {
            Chore chore = _choresService.CreateChore(choreData);
            return Ok(chore);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{choreId}")]
    public ActionResult<string> DestroyChore(int choreId)
    {
        try
        {
            string message = _choresService.DestroyChore(choreId);
            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}