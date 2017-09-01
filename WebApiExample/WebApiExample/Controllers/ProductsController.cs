using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private static List<Product> _products = new List<Product> {
            new Product{Id=0, Name="ProductA"},
            new Product{Id=1, Name="ProductB"},
            new Product{Id=2, Name="ProductC"}
        };

        [HttpGet]
        [Route("", Name = "GetAll")]
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(_products);
        }

        [HttpGet]
        [Route("{id:int}", Name ="GetById")]
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var product = _products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Route("", Name = "Add")]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Product product)
        {
            product.Id = _products.Count();
            _products.Add(product);
            return CreatedAtRoute("GetById", new { controller = "Products", id = product.Id }, product);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("{id}", Name = "UpdateById")]
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            if (product.Id != id)
            {
                return BadRequest();
            }

            if (_products.Find(p => p.Id == id) == null)
            {
                return NotFound();
            }

            _products.Find(p => p.Id == id).Name = product.Name;
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id}", Name = "DeleteById")]
        public IHttpActionResult Delete(int id)
        {
            if (_products.Find(p => p.Id == id) == null)
            {
                return NotFound();
            }

            _products.RemoveAt(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}