using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PembeliController : ControllerBase
    {
        public static readonly List<Pembeli> _pembeli = new List<Pembeli>();

        [HttpGet]
        public IEnumerable<Pembeli> GetAllPembeli()
        {
            return _pembeli;
        }

        [HttpGet("{username}")]
        public ActionResult<Pembeli> GetPembeliByUsername(string username)
        {
            var pembeli = _pembeli.FirstOrDefault(p => p.Username == username);
            if (pembeli == null)
            {
                return NotFound();
            }
            return pembeli;
        }

        [HttpPost]
        public ActionResult<Pembeli> CreatePembeli(Pembeli pembeli)
        {
            if (_pembeli.Any(p => p.Username == pembeli.Username))
            {
                return Conflict();
            }

            _pembeli.Add(pembeli);
            return CreatedAtAction(nameof(GetPembeliByUsername), new { username = pembeli.Username }, pembeli);
        }
    }

    public class Pembeli
    {
        public string Username { get; set; }
        public Dictionary<string, Dictionary<string, int>> Cart { get; set; }
    }
}