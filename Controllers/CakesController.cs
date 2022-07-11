using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweetShoppp.Repositories;
using SweetShoppp.Models;
using Microsoft.EntityFrameworkCore;

namespace SweetShoppp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        private readonly ICakeRepository _cakeRepository;

        public CakesController(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Cake>> GetCakes()
        {
            return await _cakeRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cake>> GetCakes(int id)
        {
            return await _cakeRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Cake>> PostCakes([FromBody] Cake cake)
        {
            var newCake = await _cakeRepository.Create(cake);
            return CreatedAtAction(nameof(GetCakes), new { id = newCake.Id }, newCake);
        }
        [HttpPut]
        public async Task<ActionResult> PutCakes(int id,[FromBody] Cake cake)
        {
            if (id !=cake.Id)
            {
                return BadRequest();
            }
            await _cakeRepository.Update(cake);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var cakeToDelete= await _cakeRepository.Get(id);
            if (cakeToDelete == null)
                return NotFound();

            await _cakeRepository.Delete(cakeToDelete.Id);
            return NoContent();
        }
    }
}
