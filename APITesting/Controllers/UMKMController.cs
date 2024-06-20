using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace APITesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UMKMController : ControllerBase
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "ListUMKM.json");

        public UMKMController()
        {
            // Create the JSON file if it doesn't exist
            if (!System.IO.File.Exists(_filePath))
            {
                System.IO.File.WriteAllText(_filePath, "{}");
            }
        }

        private Dictionary<string, List<Product>> ReadUmkmsFromFile()
        {
            var jsonString = System.IO.File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<Dictionary<string, List<Product>>>(jsonString);
        }

        private void WriteUmkmsToFile(Dictionary<string, List<Product>> umkms)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(umkms, options);
            System.IO.File.WriteAllText(_filePath, jsonString);
        }

        [HttpGet]
        public IActionResult GetAllUmkms()
        {
            var umkms = ReadUmkmsFromFile();
            return Ok(umkms);
        }

        [HttpGet("{username}")]
        public IActionResult GetUmkmByUsername(string username)
        {
            var umkms = ReadUmkmsFromFile();
            if (umkms.TryGetValue(username, out var umkm))
            {
                return Ok(umkm);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateUmkm([FromBody] CreateUmkmRequest request)
        {
            var umkms = ReadUmkmsFromFile();

            // Check if the UMKM with the same username already exists
            if (umkms.ContainsKey(request.Username))
            {
                return Conflict($"UMKM with username '{request.Username}' already exists.");
            }

            // Create a new UMKM with the provided products
            umkms[request.Username] = request.Products;

            WriteUmkmsToFile(umkms);

            return CreatedAtAction(nameof(GetUmkmByUsername), new { username = request.Username }, new
            {
                Username = request.Username,
                Products = umkms[request.Username]
            });
        }

        [HttpPost("{username}/products")]
        public IActionResult CreateProduct(string username, [FromBody] Product product)
        {
            var umkms = ReadUmkmsFromFile();
            if (!umkms.ContainsKey(username))
            {
                return NotFound();
            }

            umkms[username].Add(product);
            WriteUmkmsToFile(umkms);
            return CreatedAtAction(nameof(GetUmkmByUsername), new { username }, product);
        }
    }

    public class CreateUmkmRequest
    {
        public string Username { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string Nama { get; set; }
        public int Stok { get; set; }
        public decimal Harga { get; set; }
        public string Kategori { get; set; }
    }
}