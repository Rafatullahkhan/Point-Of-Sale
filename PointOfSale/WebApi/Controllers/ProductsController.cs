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
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private dbContext db = new dbContext();

        // GET: api/Products
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public Product GetProduct(int id)
        {
            Product product = db.Products.Where(p=>p.Id);
            if (product == null)
            {
                return null;
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPost]
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutProduct(int id, Product product)
        {
            HttpResponseMessage res;

            try
            {
                var entity = db.Products.FirstOrDefault(p => p.Id == product.Id);

                if (entity != null)
                {
                    entity.Name = product.Name;
                    db.SaveChanges();

                    res = Request.CreateResponse(HttpStatusCode.OK, entity);

                }
                else
                {
                    res = Request.CreateResponse(HttpStatusCode.NotFound, "Product id= " + product.Id + " not found");

                }

            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                //res.Headers.Add("Access-Control-Allow-Origin", "*");
                return res;
            }

            res.Headers.Add("Access-Control-Allow-Origin", "*");
            return res;
        }

        // POST: api/Products
        [HttpPost]
        [ResponseType(typeof(Product))]
        public HttpResponseMessage PostProduct(Product product)
        {
            HttpResponseMessage res;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    res = Request.CreateResponse(HttpStatusCode.Created, product);
                }
                else
                {
                    res = Request.CreateResponse(HttpStatusCode.BadRequest, "Product not added successfully");
                }
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);


            }

            res.Headers.Add("Access-Control-Allow-Origin", "*");
            return res;
        }

        // DELETE: api/Products/5
        [HttpPost]
        [ResponseType(typeof(Product))]
        public HttpResponseMessage DeleteProduct(int id)
        {
            HttpResponseMessage res;
            try
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    res = Request.CreateResponse(HttpStatusCode.NotFound, "Product not found");
                }
                else
                {

                    db.Products.Remove(product);
                    db.SaveChanges();

                    res = Request.CreateResponse(HttpStatusCode.OK, "Deleted");

                }
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            res.Headers.Add("Access-Control-Allow-Origin", "*");
            return res;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}