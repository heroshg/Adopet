using Adopet.Data;
using Adopet.Data.Dtos;
using Adopet.Models;
using Adopet.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Adopet.Controllers;
[ApiController]
[Route("[controller]")]
public class TutorController : Controller
{
    private AdoPetContext _context;
    private IMapper _mapper;
    public TutorController(AdoPetContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("/tutores")]
    public IActionResult AdicionarTutor([FromBody]CreateTutorDto tutorDto)
    {
        Tutor tutor = _mapper.Map<Tutor>(tutorDto);
        _context.Tutores.Add(tutor);
        _context.SaveChanges();
        return Ok(tutor);
    }

    [HttpGet("/tutores")]
    public IActionResult RecuperaTutor([FromQuery] int skip = 0, [FromQuery] int take = 0) 
    {
        var tutores = _context.Tutores.Skip(skip).Take(take).ToList();
        if (tutores.Count == 0)
        {
            return NotFound("Não encontrado");
        }
        return Ok(tutores);
    }

    [HttpGet("/tutores/{id}")]
    public IActionResult RecuperaTutorPorId(int id)
    {
       Tutor tutorRecuperado =  _context.Tutores.FirstOrDefault(t => t.Id == id);
        if (tutorRecuperado == null)
        {
            return NotFound("Não encontrado");
        }
        return Ok(tutorRecuperado);
    }
    [HttpDelete("/tutores/{id}")]
    public IActionResult DeletarTutor(int id)
    {
        Tutor tutorADeletar  = _context.Tutores.FirstOrDefault(t => t.Id == id);
        if(tutorADeletar == null)
        {
            return NotFound("Tutor não encontrado");
        }
        _context.Tutores.Remove(tutorADeletar);
        _context.SaveChanges();
        return Ok("Sucesso ao deletar tutor!");

    }

    [HttpPut("/tutores/{id}")]
    public IActionResult AtualizarTutor(int id, [FromBody] UpdateTutorDto tutorDto)
    {
        var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
        if( tutor == null) 
        {
            return NotFound();
        }
        _mapper.Map(tutorDto, tutor);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("/tutores/{id}")]
    public IActionResult AtualizarTutorParcialmente(int id, JsonPatchDocument<UpdateTutorDto> patch)
    {
        var tutor  = _context.Tutores.FirstOrDefault(t => t.Id == id);
        if (tutor == null) return NotFound();

        var tutorParaAtualizar = _mapper.Map<UpdateTutorDto>(tutor);
        patch.ApplyTo(tutorParaAtualizar, ModelState);  
        if(!TryValidateModel(tutorParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(tutorParaAtualizar, tutor);
        _context.SaveChanges();
        return NoContent();
    }
}
