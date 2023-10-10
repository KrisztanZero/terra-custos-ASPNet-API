using Microsoft.AspNetCore.Mvc;
using terra_custos_aspnet_web_api.IService;

namespace terra_custos_aspnet_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        protected readonly IGenericService<T> _service;

        protected GenericController(IGenericService<T> service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            var entities = await _service.GetAllAsync();
            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<T>> GetById(string id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost("create")]
        public async Task<ActionResult<T>> Create(T entity)
        {
            try
            {
                var createdEntity = await _service.CreateAsync(entity);
                return CreatedAtAction(nameof(GetById), new { }, createdEntity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-by-id/{id}")]
        public async Task<IActionResult> Update(string id, T entity)
        {
            try
            {
                var updatedEntity = await _service.UpdateAsync(id, entity);
                if (updatedEntity == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-by-id/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
