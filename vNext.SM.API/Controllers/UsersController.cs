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
using vNext.SM.Data;
using vNext.SM.Data.UserManagement;

namespace vNext.SM.API.Controllers
{
    public class UsersController : ApiController
    {
        private vNextSMDbContext db = new vNextSMDbContext();

        // GET: api/Users
        public IQueryable<SMUser> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(SMUser))]
        public IHttpActionResult GetSMUser(int id)
        {
            SMUser sMUser = db.Users.Find(id);
            if (sMUser == null)
            {
                return NotFound();
            }

            return Ok(sMUser);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSMUser(int id, SMUser sMUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sMUser.SMUserId)
            {
                return BadRequest();
            }

            db.Entry(sMUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SMUserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(SMUser))]
        public IHttpActionResult PostSMUser(SMUser sMUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(sMUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sMUser.SMUserId }, sMUser);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(SMUser))]
        public IHttpActionResult DeleteSMUser(int id)
        {
            SMUser sMUser = db.Users.Find(id);
            if (sMUser == null)
            {
                return NotFound();
            }

            db.Users.Remove(sMUser);
            db.SaveChanges();

            return Ok(sMUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SMUserExists(int id)
        {
            return db.Users.Count(e => e.SMUserId == id) > 0;
        }
    }
}