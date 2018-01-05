using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiTest.Models;

namespace ApiTest.Controllers
{
    public class Order_DetailsController : ApiController
    {
        private Northwind db = new Northwind();

        /// <summary>
        /// Gets the order details.
        /// </summary>
        /// <returns></returns>
        // GET: api/Order_Details
        public IQueryable<Order_Details> GetOrder_Details()
        {
            return db.Order_Details;
        }

        /// <summary>
        /// Gets the order details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        // GET: api/Order_Details/5
        [ResponseType(typeof(Order_Details))]
        public IHttpActionResult GetOrder_Details(int id)
        {
            Order_Details order_Details = db.Order_Details.Find(id);
            if (order_Details == null)
            {
                return NotFound();
            }

            return Ok(order_Details);
        }

        /// <summary>
        /// Puts the order details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="order_Details">The order details.</param>
        /// <returns></returns>
        // PUT: api/Order_Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder_Details(int id, Order_Details order_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order_Details.OrderID)
            {
                return BadRequest();
            }

            db.Entry(order_Details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_DetailsExists(id))
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
        /// Posts the order details.
        /// </summary>
        /// <param name="order_Details">The order details.</param>
        /// <returns></returns>
        // POST: api/Order_Details
        [ResponseType(typeof(Order_Details))]
        public IHttpActionResult PostOrder_Details(Order_Details order_Details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Order_Details.Add(order_Details);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Order_DetailsExists(order_Details.OrderID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = order_Details.OrderID }, order_Details);
        }

        /// <summary>
        /// Deletes the order details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        // DELETE: api/Order_Details/5
        [ResponseType(typeof(Order_Details))]
        public IHttpActionResult DeleteOrder_Details(int id)
        {
            Order_Details order_Details = db.Order_Details.Find(id);
            if (order_Details == null)
            {
                return NotFound();
            }

            db.Order_Details.Remove(order_Details);
            db.SaveChanges();

            return Ok(order_Details);
        }

        // 7.為 OrderDetailsController、OrdersController 加入部分更新功能。(PATCH)
        public IHttpActionResult PatchOrders(int id, Order_Details patchData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patchData.OrderID)
            {
                return BadRequest();
            }
            Order_Details orderdetails = db.Order_Details.Find(id);
            if (orderdetails == null)
            {
                return NotFound();
            }
            // 異動 Product 物件部分欄位
            orderdetails.Quantity = patchData.Quantity;
            db.Entry(orderdetails).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_DetailsExists(id))
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Order_DetailsExists(int id)
        {
            return db.Order_Details.Count(e => e.OrderID == id) > 0;
        }
    }
}