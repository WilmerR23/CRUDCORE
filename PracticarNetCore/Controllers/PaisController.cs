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
    [Route("api/Pais")]
    public class PaisController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaisController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.PaisRepository.FindAll());
        }

        [HttpPost]
        public async Task Post([FromBody] Pais pais)
        {
            await _unitOfWork.PaisRepository.Save(pais);
            await _unitOfWork.Save();
        }

        [HttpPut]
        public async Task Put([FromBody] Pais pais)
        {
            _unitOfWork.PaisRepository.Update(pais);
            await _unitOfWork.Save();
        }

        [HttpDelete]
        public async Task Delete([FromBody] Pais pais)
        {
            _unitOfWork.PaisRepository.Delete(pais);
            await _unitOfWork.Save();
        }
    }
}