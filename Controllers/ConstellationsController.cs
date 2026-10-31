using ConstellationRestore.DTOs;
using ConstellationRestore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConstellationRestore.Controllers;

[ApiController]
[Route("api/constellations")]
public sealed class ConstellationsController : ControllerBase
{
    private readonly IConstellationRestoreService _restoreService;

    public ConstellationsController(IConstellationRestoreService restoreService)
    {
        _restoreService = restoreService;
    }

    /// <summary>Определяет символы эталонного кода, отсутствующие в повреждённом.</summary>
    [HttpPost("restore")]
    [ProducesResponseType(typeof(ConstellationRestoreResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ConstellationRestoreResponse> Restore([FromBody] ConstellationRestoreRequest request)
    {
        var error = _restoreService.Validate(request.Reference!, request.Damaged!);
        if (error is not null)
            return BadRequest(new { error });

        var response = _restoreService.Restore(request.Reference!, request.Damaged!);
        return Ok(response);
    }
}
