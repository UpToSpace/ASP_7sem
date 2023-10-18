using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace lab2.Controllers
{
    public class ValuesController : ApiController
    {
        private static int result = 0;
        private static ConcurrentStack<int> stack = new ConcurrentStack<int>();
        // GET api/values
        public string Get()
        {
            if (stack.Count == 0)
            {
                return "{\"result\": " + result + "}";
            }
            else
            {
                return "{\"result\": " + (result + stack.First()) + "}";
            }
        }

        // POST api/values
        public void Post(int result)
        {
            ValuesController.result = result;
        }

        // PUT api/values/5
        public void Put(int add)
        {
            stack.Push(add);
        }

        // DELETE api/values/5
        public void Delete()
        {
            if (stack.Count != 0)
            {
                stack.TryPop(out int _);
            }
        }
    }
}
