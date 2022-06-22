using Microsoft.AspNetCore.Mvc;
using XotaApi.Models;
using XotaApi.Managers;

namespace XotaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class XotaItemsController : ControllerBase
{
    // GET: api/XotaItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IXotaItem>>> GetXotaItem()
    {
        List<IXotaItem> data = new List<IXotaItem>();

        XotaDataManager XM = new XotaDataManager();

        data = await XM.GetXotaItems();

        if (data.Count == 0) return NotFound();

        return Ok(data);
    }
}
