using Fornecedores_Model.Features;
using Fornecedores_ORM;
using Microsoft.AspNetCore.Mvc;

namespace Fornecedores_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly BaseRepository<Supplier> _repository;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(BaseRepository<Supplier> repository, ILogger<SupplierController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Supplier>> GetAll()
        {
            var suppliers = _repository.SelectAll();
            if (suppliers == null || suppliers.Count == 0)
                return NotFound("Nenhum fornecedor encontrado.");

            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public ActionResult<Supplier> GetById(int id)
        {
            var supplier = _repository.SelectById(id);
            if (supplier == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");

            return Ok(supplier);
        }

        [HttpPost]
        public ActionResult<Supplier> Create([FromBody] Supplier supplier)
        {
            if (supplier == null)
                return BadRequest("Dados inválidos.");

            var validation = supplier.Validate();
            if (validation != "VALID")
                return BadRequest(validation);

            var success = _repository.Insert(supplier);
            if (!success)
                return StatusCode(500, "Erro ao salvar fornecedor.");

            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Supplier supplier)
        {
            if (supplier == null)
                return BadRequest("Dados inválidos.");

            var existingSupplier = _repository.SelectById(id);
            if (existingSupplier == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");

            supplier.Id = id;
            var success = _repository.Update(id, supplier);
            if (!success)
                return StatusCode(500, "Erro ao atualizar fornecedor.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingSupplier = _repository.SelectById(id);
            if (existingSupplier == null)
                return NotFound($"Fornecedor com ID {id} não encontrado.");

            var success = _repository.Delete(id);
            if (!success)
                return StatusCode(500, "Erro ao excluir fornecedor.");

            return NoContent();
        }
    }
}
