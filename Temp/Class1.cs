//using Farasis.Models;


//using System;

//using System.Collections.Generic;

//using System.Data;
//using System.Data.Entity.Infrastructure;

//using System.Linq;
//using System.Net;
//using System.Net.Http;

//using System.Web;
//using System.Web.Http;
//using System.Web.Mvc;
//namespace Farasis.Controllers
//{
//    public class UserController : ApiController
//    {
//        // GET api/user
//        private IGenericRepository<User> _repository = null;

//        public UserController()
//        {
//            _repository = new GenericRespository<User>();
//        }
//        public UserController(GenericRespository<User> repoistory)
//        {
//            _repository = repoistory;

//        }
//        //public HttpResponseMessage GetUsers()
//        //{
//        //    var _users = _repository.GetAll();
//        //    _users.Select(x=> new {
//        //        id=x.EmailId,
//        //        Email=x.Email,
//        //        FirstName=x.FirstName,
//        //        LastName=x.LastName,
//        //        Password=x.Password
//        //    });
//        //    var _response=this.Request.CreateResponse(HttpStatusCode.OK);
//        //    _response.Content = _users;
//        //    return reponse;
//        //}
//        public IEnumerable<User> Get()
//        {
//            IEnumerable<User> _userLists = _repository.GetAll();
//            return _userLists.Where(x => x.WorkState == true);
//            //return _userExisting;
//        }

//        //public JsonResult GetAll()
//        //{

//        //}
//        // GET api/user/5
//        //public User Get(int id)
//        //{
//        //    return _repository.Get(id); 
//        //}
//        public User Get(int id)
//        {
//            return _repository.Get(id);
//        }

//        // POST api/user
//        public HttpResponseMessage Post(User obj)
//        {
//            IEnumerable<User> _userLists = _repository.GetAll();

//            User _user = _userLists.Single(x => x.UserId == obj.UserId);
//            if (_user != null)
//            {
//                _repository.Delete(_user.UserId);

//                _repository.Insert(obj);
//                return Request.CreateResponse(HttpStatusCode.OK);
//            }
//            else
//            {
//                //_repository.Delete(_user.UserId);
//                _repository.Insert(obj);
//                return Request.CreateResponse(HttpStatusCode.OK);
//            }

//            //query ,save delete remoue,get get
//            //if(_user.Count>0){
//            //    _repository.Update(obj);
//            //    return Request.CreateResponse(HttpStatusCode.OK); 
//            //}
//            //else
//            //{
//            //      _repository.Insert(obj);
//            //return Request.CreateResponse(HttpStatusCode.OK); 
//            //}            
//        }

//        // PUT api/user/5
//        //public httpresponsemessage put(int id, user obj)
//        //{
//        //    //not right;
//        //    //_repository.update(obj);
//        //    return request.createresponse(httpstatuscode.ok);
//        //}
//        //public void Put(User obj)
//        //{
//        //    _repository.Update(obj);
//        //}

//        // DELETE api/user/5
//        //public HttpResponseMessage Delete(int id)
//        //{
//        //    _repository.Delete(id);
//        //    return Request.CreateResponse(HttpStatusCode.OK);
//        //}
//        public HttpResponseMessage Delete(int id)
//        {
//            User _user = _repository.GetAll().Single(x => x.UserId == id);

//            _user.WorkState = false;
//            _repository.Update(_user);

//            return Request.CreateResponse(HttpStatusCode.OK);
//            //if (_user != null)
//            //{
//            //    _repository.Update(obj);
//            //    return Request.CreateResponse(HttpStatusCode.OK);
//            //}
//            //else
//            //{
//            //    _repository.Insert(obj);
//            //    return Request.CreateResponse(HttpStatusCode.OK);
//            //}            
//            //_repository.Delete(id);

//        }
//    }
//}
