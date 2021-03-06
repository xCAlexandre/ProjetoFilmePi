using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTS.Shared;
using ProjetoTS.Server;

namespace ProjetoTS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : Controller
    {
        private readonly ApplicationDBContext db;
        public TagController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("CriarTAG")]
        public async Task<ActionResult> Post([FromBody] Tag tag)//recebe uma tag do body do Http e não do header
        {
           
            try
            {
                var newTag = new Tag
                {
                    TagId = tag.TagId,
                    Nome = tag.Nome
                };
                db.Add(newTag);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpGet]
        [Route("ListarTAG")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var tags = await db.Tags.ToListAsync();//resulta em uma Lista de Tags
            return Ok(tags);
        }


    }
}