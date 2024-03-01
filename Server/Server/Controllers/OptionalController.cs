using Microsoft.AspNetCore.Mvc;
using Server.Clients.Model;
using Server.Model;
using Server.Optional;
using Server.Optional.Model;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionalController : ControllerBase
    {
        private readonly OptionalContext _context;

        public OptionalController(OptionalContext context)
        {
            _context = context;
        }
        [HttpPost("addInterval")]
        public IActionResult addInterval([FromBody] DataEntryModel clientModel)
        {
            try
            {
                _context.dates.Add(new DateEntry()
                {
                   IdEntry = clientModel.Id,
                   Dt = DateTime.UtcNow
                });
                _context.SaveChanges();

                return Ok($"Объект успешно добавлен.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getIntervals")]
        public IEnumerable<OptionResultModel> GetIntervals()
        {
            var intervals = _context.dates
                .OrderBy(d => d.IdEntry)
                .ThenBy(d => d.Dt)
                .AsEnumerable()
                .GroupBy(d => d.IdEntry)
                .Where(group => group.Count() > 1)
                .ToList();

            var result = new List<OptionResultModel>();

            foreach (var group in intervals)
            {
                var groupIntervals = group.OrderBy(d => d.Dt).ToList();

                for (int i = 0; i < groupIntervals.Count - 1; i++)
                {
                    var current = groupIntervals[i];
                    var next = groupIntervals[i + 1];

                    result.Add(new OptionResultModel()
                    {
                        id = current.IdEntry,
                        StartDate = current.Dt,
                        EndDate = next.Dt
                    });           
                }
            }
            return result;
        }
    }
}
