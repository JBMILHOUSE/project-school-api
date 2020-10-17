using ProjetoEscola_API.Data;
using ProjetoEscola_API.Controllers;
using ProjetoEscola_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProjetoEscola_API.Controllers {
  
  [Route("api/[controller]")]
  [ApiController]
  public class CursoController : Controller {
    private readonly EscolaContext _context;
      public CursoController(EscolaContext context)
      {
         _context = context;
      }

      [HttpGet]
      public ActionResult<List<Curso>> GetAll(){
        
        return _context.Curso.ToList();
      }

      [HttpGet("{CursoId}")]
      public ActionResult<List<Curso>> Get(int CursoId) {

        try {
         
          var result = _context.Curso.Find(CursoId);
          if(result == null) {
            return NotFound();
          }
          return Ok(result);
        }
        catch {
          return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
        }
      }

      [HttpPost]
      public async Task <ActionResult> post(Curso model) {
          
        if(ModelState.IsValid) {
            
           _context.Curso.Add(model);
           await _context.SaveChangesAsync();
           return Created($"/api/curso/{model.codCurso}", model);
        }
        else {
            return BadRequest(ModelState);
        }
        
      }

      [HttpDelete("{CursoId}")]
      public async Task<ActionResult> delete (int CursoId) {

        try {
          
          var curso = await _context.Curso.FindAsync(CursoId);
          if(curso == null){

            return NotFound();
          }
          _context.Remove(curso);
          await _context.SaveChangesAsync();
          return NoContent();

        }
        catch {
          return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
        }
      }

      [HttpPut("{CursoId}")]
      public async Task<ActionResult> put(int CursoId, Curso dadosCursoAlt) {

        try
        {
          var result = await _context.Curso.FindAsync(CursoId);
          if(CursoId != result.id) {

            return BadRequest();
          }
          result.codCurso = dadosCursoAlt.codCurso;
          result.nomeCurso = dadosCursoAlt.nomeCurso;
          result.periodo = dadosCursoAlt.periodo;
          await _context.SaveChangesAsync();
          
          return Created($"/api/curso/{dadosCursoAlt.codCurso}", dadosCursoAlt);
        }
        catch
        {
          return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
        }
      }
  }     
}