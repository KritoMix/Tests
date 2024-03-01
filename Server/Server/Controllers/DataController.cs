using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Data;
using Server.Model;
using System.Text.Json;
using System.Linq;
using Server.Data.Model;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _context;

        public DataController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("addData")]
        public IActionResult PostData([FromBody] List<DataFormModel> dataItems)
        {
            try
            {
                if (dataItems == null || !dataItems.Any())
                {
                    return BadRequest("Передан пустой массив.");
                }

                dataItems = dataItems.OrderBy(x=>x.Code).ToList();

                _context.dataObject.AddRange(
                    dataItems.Select(x=> new DataObject() 
                    {
                        Code = x.Code,
                        Value = x.Value,
                    })
                 );
                _context.SaveChanges();

                return Ok("Данные успешно сохранены.");
            }
            catch(Exception ex)
            {            
                return BadRequest(ex.Message);
            }
        }

       
        [HttpGet("getdata")]
        public IActionResult GetData([FromQuery] int? codeFilter)
        {
           
            IQueryable<DataObject> query = _context.dataObject.AsQueryable();
            
            if (codeFilter.HasValue)
            {
                query = query.Where(d => d.Code == codeFilter);
            }

            var data = query.Select(d => new DataModel()
            {
                Id = d.Id,
                Code = d.Code,
                Value = d.Value
            }).ToList();

            return Ok(data);
        }
    }
}
