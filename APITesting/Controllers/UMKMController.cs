using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;

namespace APITesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UMKMController : ControllerBase
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "umkms.json");

        public UMKMController()
        {
            if (!System.IO.File.Exists(_filePath))
            {
                System.IO.File.WriteAllText(_filePath, "[]");
            }
        }

        private List<UMKM> ReadUmkmsFromFile()
        {
            var jsonString = System.IO.File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<UMKM>>(jsonString);
        }

        private void WriteUmkmsToFile(List<UMKM> umkms)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(umkms, options);
            System.IO.File.WriteAllText(_filePath, jsonString);
        }

        [HttpGet]
        public IEnumerable<UMKM> GetAllUmkms()
        {
            return ReadUmkmsFromFile();
        }

        [HttpGet("{username}")]
        public ActionResult<UMKM> GetUmkmByUsername(string username)
        {
            var umkms = ReadUmkmsFromFile();
            var umkm = umkms.FirstOrDefault(u => u.Username == username);
            if (umkm == null)
            {
                return NotFound();
            }
            return umkm;
        }

        [HttpPost]
        public ActionResult<UMKM> CreateUmkm(UMKM umkm)
        {
            var umkms = ReadUmkmsFromFile();
            if (umkms.Any(u => u.Username == umkm.Username))
            {
                return Conflict();
            }

            umkms.Add(umkm);
            WriteUmkmsToFile(umkms);
            return CreatedAtAction(nameof(GetUmkmByUsername), new { username = umkm.Username }, umkm);
        }

        [HttpGet("generate-json")]
        public IActionResult GenerateJsonFile()
        {
            var umkms = ReadUmkmsFromFile();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(umkms, options);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "umkms.json");

            System.IO.File.WriteAllText(filePath, jsonString);

            return Ok(new { message = "JSON file created successfully", filePath });
        }
    }

    public class UMKM
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
