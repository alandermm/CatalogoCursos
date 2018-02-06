using System.Collections.Generic;
using System.Linq;
using CatalogoCursos.Dados;
using CatalogoCursos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoCursos.Controllers
{
    [Route("api/[controller]")]
    public class AreaController:Controller
    {
        Area area = new Area();
        readonly CatalogoContext contexto;

        public AreaController(CatalogoContext contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Area> Listar(){
            return contexto.Area.ToList();
        }

        [HttpGet("{id}")]
        public Area Listar(int id){
            return contexto.Area.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Area area){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            contexto.Area.Add(area);

            int x = contexto.SaveChanges();
            if(x > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Area area){
            if(area == null || area.Id != id){
                return BadRequest();
            }
            var ar = contexto.Area.FirstOrDefault(x=> x.Id == id);
            if(ar == null){
                return NotFound();
            }

            ar.Id = area.Id;
            ar.Nome = area.Nome;

            contexto.Area.Update(ar);
            int rs = contexto.SaveChanges();

            if(rs > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var area = contexto.Area.Where(x => x.Id == id).FirstOrDefault();
            if(area == null){
                return NotFound();
            }

            contexto.Area.Remove(area);

            int rs = contexto.SaveChanges();

            if(rs > 0){
                return Ok();
            } else {
                return BadRequest();
            }
        }
    }
}