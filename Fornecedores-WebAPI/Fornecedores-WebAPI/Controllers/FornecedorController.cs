using Fornecedores_Model.Features;
using Fornecedores_ORM;
using Microsoft.AspNetCore.Mvc;

namespace Fornecedores_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly BaseRepository<Forneceddor> _repository;
        private readonly ILogger<FornecedorController> _logger;

        public FornecedorController(BaseRepository<Forneceddor> repository, ILogger<FornecedorController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Forneceddor>> GetAll()
        {
            var fornecedores = _repository.SelectAll();
            if (fornecedores == null || fornecedores.Count == 0)
                return NotFound("Nenhum fornecedor encontrado.");

            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public ActionResult<Forneceddor> GetById(int id)
        {
            var fornecedor = _repository.SelectById(id);
            if (fornecedor == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");

            return Ok(fornecedor);
        }

        [HttpPost]
        public ActionResult<Forneceddor> Create([FromBody] Forneceddor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest("Dados inválidos.");

            var validation = fornecedor.Validate();
            if (validation != "VALID")
                return BadRequest(validation);

            var success = _repository.Insert(fornecedor);
            if (!success)
                return StatusCode(500, "Erro ao salvar fornecedor.");

            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Forneceddor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest("Dados inválidos.");

            var existingFornecedor = _repository.SelectById(id);
            if (existingFornecedor == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");

            fornecedor.Id = id;
            var success = _repository.Update(id, fornecedor);
            if (!success)
                return StatusCode(500, "Erro ao atualizar fornecedor.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingfornecedor = _repository.SelectById(id);
            if (existingfornecedor == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");

            var success = _repository.Delete(id);
            if (!success)
                return StatusCode(500, "Erro ao excluir fornecedor.");

            return NoContent();
        }
    }
}
