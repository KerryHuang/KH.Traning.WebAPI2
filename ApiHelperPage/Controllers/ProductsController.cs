using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using System.Web.Http.Tracing;
using ApiHelperPage.Filters;
using ApiHelperPage.Models;

namespace ApiHelperPage.Controllers
{
    /// <summary>
    /// 產品資料
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [JwtAuthorize]
    public class ProductsController : ApiController
    {
        private Northwind db = new Northwind();

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        // GET: api/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts()
        {
            // http://localhost:58572/api/Products?$top=5&$skip=5

            // http://localhost:58572/api/Products?$filter=UnitPrice gt 100&orderby=ProductName

            return db.Products;
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Configuration.Services.GetTraceWriter().Info(Request, "Products", "Get the list of products.");
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Puts the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Posts the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <response code="201">新增產品</response>
        /// <response code="400">新增錯誤</response>
        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        /// <summary>
        /// 釋放物件所使用的 Unmanaged 資源，並選擇性地釋放 Managed 資源。
        /// </summary>
        /// <param name="disposing">true 表示釋放 Managed 和 Unmanaged 資源；false 則表示只釋放 Unmanaged 資源。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Products the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}