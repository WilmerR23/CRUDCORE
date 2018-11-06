using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticarNetCore.Models;
using PracticarNetCore.UWork;

namespace PracticarNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Persona")]
    public class PersonaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.PersonaRepository.FindAll("Pais"));
        }

        [HttpPost]
        public async Task Post([FromBody] Persona person)
        {
            await _unitOfWork.PersonaRepository.Save(person);
            await _unitOfWork.Save();
        }

        [HttpPut]
        public async Task Put([FromBody] Persona person)
        {
            _unitOfWork.PersonaRepository.Update(person);
            await _unitOfWork.Save();
        }

        [HttpDelete]
        public async Task Delete([FromBody] Persona person)
        {
            _unitOfWork.PersonaRepository.Delete(person);
            await _unitOfWork.Save();
        }
    }
}