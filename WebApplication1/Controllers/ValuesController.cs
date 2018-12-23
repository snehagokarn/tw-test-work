using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public In Get()
        {
            var sample = new Input() { encryptedMessage = "F KFRTZX JCUQTWJW TSHJ XFNI, YMFY YMJ JCYWFTWINSFWD NX NS BMFY BJ IT, STY BMT BJ FWJ. LT JCUQTWJ!", key = 5 };
            return sample;
        }

        // POST api/values
        public SampleOutput Post([FromBody]SampleOutput value)
        {
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
