using Microsoft.AspNetCore.Mvc;
using veeb.models;

namespace veebirakendus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TootedController : ControllerBase
    {
        private static List<Toode> _tooted = new List<Toode>
        {
            new Toode(1,"Koola", 1.5, true),
            new Toode(2,"Fanta", 1.0, false),
            new Toode(3,"Sprite", 1.7, true),
            new Toode(4,"Vichy", 2.0, true),
            new Toode(5,"Vitamin well", 2.5, true)
        };

        // GET: /tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }

        // GET: /tooted/kustuta-koik
        [HttpGet("kustuta-koik")]
        public List<Toode> DeleteAll()
        {
            _tooted.Clear();
            return _tooted;
        }

        // GET: /tooted/muuda-koik-vaara
        [HttpGet("muuda-koik-vaara")]
        public List<Toode> ToggleAllActiveStatus()
        {
            foreach (var toode in _tooted)
            {
                toode.IsActive = false;
            }
            return _tooted;
        }

        // GET: /tooted/{index}
        [HttpGet("{index}")]
        public ActionResult<Toode> GetByIndex(int index)
        {
            if (index < 0 || index >= _tooted.Count)
            {
                return NotFound("Toode määratud indeksiga ei leitud.");
            }
            return _tooted[index];
        }

        // GET: /tooted/korgeim-hind
        [HttpGet("korgeim-hind")]
        public ActionResult<Toode> GetByHighestPrice()
        {
            if (_tooted.Count == 0)
            {
                return NotFound("Ühtegi toodet ei leitud.");
            }

            var maxPriceToode = _tooted.OrderByDescending(t => t.Price).First();
            return maxPriceToode;
        }
    }
}
