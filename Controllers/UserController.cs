using Farasis.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
namespace Farasis.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        private BattEntities m_db = null;

        public UserController()
        {
            m_db = new BattEntities();
        }
        public UserController(BattEntities repoistory)
        {
            m_db = repoistory;

        }
        public IEnumerable<User> Get()
        {
            return m_db.User.ToList();
        }
        public User Get(int id)
        {
            return m_db.User.Find(id);  
        }

        // POST api/user  
        public HttpResponseMessage Post(User user)
        {
            User _user = m_db.User.AsNoTracking().FirstOrDefault(p => p.UserId == user.UserId );
            CheckExistingEmail(user);
           
            if (_user!= null)
            {
                // Modify existing user.
                m_db.User.Attach(user);
                m_db.Entry(user).State = EntityState.Modified;
                m_db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                // Add new user.
                m_db.User.Add(user);
                m_db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }           
        }

        private void CheckExistingEmail(User user)
        {
            User existingUser = m_db.User.AsNoTracking().FirstOrDefault(p => p.Email == user.Email && p.UserId != user.UserId);
            if (existingUser != null)
            {
                throw new Exception("Email exists alreaddy");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            User _user = m_db.User.AsNoTracking().FirstOrDefault(p => p.UserId == id);
            if (_user != null)
            {
                _user.WorkState = false;
                m_db.User.Attach(_user);
                m_db.Entry(_user).State = EntityState.Modified;
                m_db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
