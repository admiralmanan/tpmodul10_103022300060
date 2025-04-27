using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022300060.Models;

namespace tpmodul10_103022300060.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class MahasiswaController : ControllerBase
        {
            private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa {Nama = "Admiral Manan Badawi", NIM = "103022300060"},
            new Mahasiswa {Nama = "Daniyal Arshaq Sudrajat", NIM = "103022300076"},
            new Mahasiswa {Nama = "Raditya Maheswara", NIM = "103022300026"},
            new Mahasiswa {Nama = "Azka Nadhif Athallah", NIM = "103022300065"},
            new Mahasiswa {Nama = "Alif Satria Waskita", NIM = "103022300133"},
        };

            [HttpGet]
            public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
            {
                return Ok(daftarMahasiswa);
            }

            [HttpGet("{index}")]
            public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
            {
                if (index < 0 || index >= daftarMahasiswa.Count)
                {
                    return NotFound("Mahasiswa tidak ditemukan");
                }
                return Ok(daftarMahasiswa[index]);
            }

            [HttpPost]
            public ActionResult<Mahasiswa> PostMahasiswa(Mahasiswa mahasiswa)
            {
                daftarMahasiswa.Add(mahasiswa);
                return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = daftarMahasiswa.Count - 1 }, mahasiswa);
            }

            [HttpDelete]
            public IActionResult DeleteMahasiswa(int index)
            {
                if (index < 0 || index >= daftarMahasiswa.Count)
                {
                    return NotFound("Mahasiswa tidak ditemukan untuk dihapus");
                }

                daftarMahasiswa.RemoveAt(index);
                return NoContent();
            }
        }
}
