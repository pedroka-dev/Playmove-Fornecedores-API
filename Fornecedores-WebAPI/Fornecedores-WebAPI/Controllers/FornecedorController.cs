using Fornecedores_Model.Features;
using Fornecedores_ORM;
using Microsoft.AspNetCore.Mvc;

namespace Fornecedores_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly BaseRepository<Fornecedor> _repository;
        private readonly ILogger<FornecedorController> _logger;

        public FornecedorController(BaseRepository<Fornecedor> repository, ILogger<FornecedorController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os fornecedores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> GetAll()
        {
            var fornecedores = _repository.SelectAll();
            if (fornecedores == null || fornecedores.Count == 0)
                return NotFound("Nenhum fornecedor encontrado.");

            return Ok(fornecedores);
        }

        /// <summary>
        /// Retorna um fornecedor espec�fico pelo ID
        /// </summary>
        /// <param name="id">Identificador �nico. Obrigat�rio</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Fornecedor> GetById(int id)
        {
            var fornecedor = _repository.SelectById(id);
            if (fornecedor == null)
                return NotFound($"Fornecedor com ID {id} n�o encontrado.");

            return Ok(fornecedor);
        }

        /// <summary>
        /// Adiciona um novo fornecedor
        /// </summary>
        /// <param name="fornecedor">Objeto fornecedor, com nome e email. Obrigat�rio</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Fornecedor> Create([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest("Dados inv�lidos.");

            var validation = fornecedor.Validate();
            if (validation != "VALID")
                return BadRequest(validation);

            var success = _repository.Insert(fornecedor);
            if (!success)
                return StatusCode(500, "Erro ao salvar fornecedor.");

            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }


        /// <summary>
        /// Atualiza um fornecedor existente pelo ID
        /// </summary>
        /// <param name="id">Identificador �nico. Obrigat�rio.</param>
        /// <param name="fornecedor">Objeto fornecedor, com nome e email. Obrigat�rio</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest("Dados inv�lidos.");

            var existingFornecedor = _repository.SelectById(id);
            if (existingFornecedor == null)
                return NotFound($"Fornecedor com ID {id} n�o encontrado.");

            fornecedor.Id = id;
            var success = _repository.Update(id, fornecedor);
            if (!success)
                return StatusCode(500, "Erro ao atualizar fornecedor.");

            return NoContent();
        }

        /// <summary>
        /// Remove um fornecedor pelo ID
        /// </summary>
        /// <param name="id">Identificador �nico. Obrigat�rio.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingfornecedor = _repository.SelectById(id);
            if (existingfornecedor == null)
                return NotFound($"Fornecedor com ID {id} n�o encontrado.");

            var success = _repository.Delete(id);
            if (!success)
                return StatusCode(500, "Erro ao excluir fornecedor.");

            return NoContent();
        }
    }
}
