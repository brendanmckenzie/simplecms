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
using SimpleCms;
using SimpleCms.Models;

namespace SimpleCms.Admin.Areas.Api.Controllers
{
    public class NodesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Nodes
        public IQueryable<Node> GetNodes()
        {
            return db.Nodes;
        }

        // GET: api/Nodes/5
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> GetNode(Guid id)
        {
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }

            return Ok(node);
        }

        // PUT: api/Nodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNode(Guid id, Node node)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != node.Id)
            {
                return BadRequest();
            }

            db.Entry(node).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeExists(id))
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

        // POST: api/Nodes
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> PostNode(Node node)
        {
            node.Id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nodes.Add(node);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NodeExists(node.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = node.Id }, node);
        }

        // DELETE: api/Nodes/5
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> DeleteNode(Guid id)
        {
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }

            db.Nodes.Remove(node);
            await db.SaveChangesAsync();

            return Ok(node);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NodeExists(Guid id)
        {
            return db.Nodes.Count(e => e.Id == id) > 0;
        }
    }
}