using Microsoft.AspNetCore.Mvc;
using Server.Clients;
using Server.Clients.Model;
using Server.Data;
using Server.Model;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientContext _context;

        public ClientController(ClientContext context)
        {
            _context = context;
        }

       
        [HttpPost("client")]
        public IActionResult AddClient([FromBody] ClientModel clientModel)
        {
            try
            {
                _context.clients.Add(new Client() 
                { 
                    ClientName= clientModel.ClientName
                });
                _context.SaveChanges();

                return Ok($"Клиент '{clientModel.ClientName}' добавлен успешно.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("clientcontactscount")]
        public IEnumerable<object> GetClientContactsCount()
        {
            
            var query = _context.clients
                .Include(x=>x.Contacts)
                .Select(x=> new 
                { 
                    ClientName = x.ClientName,
                    ContactCount = x.Contacts.Count()
                })
                .ToList();
            
            return query;  
        }
        [HttpGet("clientswithmorethantwocontacts")]
        public IEnumerable<object> GetClientsWithMoreThanTwoContacts()
        {
            var query = _context.clients
                .Include(x => x.Contacts)
                .Select(x => new
                {
                    ClientName = x.ClientName,
                    ContactCount = x.Contacts.Count()
                })
                .Where(x=>x.ContactCount > 2)
                .ToList();

            return query;
        }
        [HttpPost("clientcontact")]
        public IActionResult AddClientContact([FromBody] ClientContactModel clientContactModel)
        {
            var clientExists = _context.clients.Any(c => c.Id == clientContactModel.ClientId);
            if (!clientExists)
            {
                return NotFound($"Клиент с ID {clientContactModel.ClientId} не найден.");
            }
            _context.clientContacts.Add(new ClientContact() 
            {
                ClientId = clientContactModel.ClientId,
                ContactType = clientContactModel.ContactType,
                ContactValue = clientContactModel.ContactValue
            });
            _context.SaveChanges();

            return Ok($"Контакт для клиента с ID {clientContactModel.ClientId} добавлен успешно.");
        }
    }
}
