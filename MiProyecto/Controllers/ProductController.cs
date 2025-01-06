using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")] // Indica que el controlador devuelve JSON.
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtiene un producto por ID", Description = "Devuelve un producto según su ID.")]
        [SwaggerResponse(200, "Producto encontrado", typeof(Product))]
        [SwaggerResponse(404, "Producto no encontrado")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todos los productos", Description = "Devuelve una lista de todos los productos.")]
        [SwaggerResponse(200, "Lista de productos obtenida", typeof(IEnumerable<Product>))]
        public async Task<ActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Crea un nuevo producto", Description = "Agrega un nuevo producto al sistema.")]
        [SwaggerResponse(201, "Producto creado exitosamente", typeof(Product))]
        [SwaggerResponse(400, "Solicitud inválida")]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Actualiza un producto existente", Description = "Modifica la información de un producto existente.")]
        [SwaggerResponse(200, "Producto actualizado exitosamente", typeof(Product))]
        [SwaggerResponse(400, "Los IDs no coinciden")]
        [SwaggerResponse(404, "Producto no encontrado")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProductDto productUp)
        {
            if (id <= 0)

            {
                return BadRequest(new { message = "El ID es requerido." });
            }

            Product existingProduct = await _productService.GetProductByIdAsync(id);
            existingProduct.Name = productUp.Name;
            existingProduct.Description = productUp.Description;
            existingProduct.Price = productUp.Price;
            existingProduct.Stock = productUp.Stock;


            await _productService.UpdateProductAsync(existingProduct);
            return Ok(new { message = "Producto actualizado exitosamente.", existingProduct });
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Elimina un producto por ID", Description = "Elimina un producto del sistema.")]
        [SwaggerResponse(200, "Producto eliminado exitosamente", typeof(Product))]
        [SwaggerResponse(404, "Producto no encontrado")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Producto no encontrado." });
            }

            await _productService.DeleteProductAsync(id);
            return Ok(new { message = "Producto eliminado exitosamente.", product = existingProduct });
        }
    }
}
