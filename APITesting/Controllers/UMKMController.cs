using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UMKMController : ControllerBase
    {
        public static readonly List<UMKM> _umkms = new List<UMKM>();

        [HttpGet]
        public IEnumerable<UMKM> GetAllUmkms()
        {
            return _umkms;
        }

        [HttpGet("{username}")]
        public ActionResult<UMKM> GetUmkmByUsername(string username)
        {
            var umkm = _umkms.FirstOrDefault(u => u.Username == username); 
            if (umkm == null)
            {
                return NotFound();
            }
            return umkm;
        }

        [HttpPost]
        public ActionResult<UMKM> CreateUmkm(UMKM umkm)
        {
            if (_umkms.Any(u => u.Username == umkm.Username))
            {
                return Conflict();
            }

            _umkms.Add(umkm);
            return CreatedAtAction(nameof(GetUmkmByUsername), new { username = umkm.Username }, umkm);
        }
    }

    public class UMKM
    {
        public string Username { get; set; }
        public Dictionary<string, int> Stock { get; set; }
    }
}