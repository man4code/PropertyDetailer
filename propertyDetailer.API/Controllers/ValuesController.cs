using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using propertyDetailer.API.Context;

namespace propertyDetailer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private PropertyDbContext _context;
        static string _address = "http://dev1-sample.azurewebsites.net/properties.json";
        public ValuesController(PropertyDbContext context)
        {
            this._context = context;
        }
        //GET api/values
       [HttpGet]
        public IEnumerable<PropertyDetails> Get()
        {
            IEnumerable<PropertyDetails> model = _context.Set<PropertyDetails>().ToList();
            return model;
        }
        //[HttpGet]
        //public async Task<IEnumerable<string>> Get()
        //{
        //    var result = await GetExternalResponse();

        //    return result;
        //}

        private async Task<string> GetExternalResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PropertyDetails Get(int id)
        {
            PropertyDetails model = new PropertyDetails();
            if (id > 0)
            {
                PropertyDetails proDetails = _context.Set<PropertyDetails>().SingleOrDefault
                    (c => c.Id == id);
                if (proDetails != null)
                {
                    model.Id = proDetails.Id;
                    model.Address = proDetails.Address;
                    model.Financial = proDetails.Financial;
                    model.Physical = proDetails.Physical;
                }
            }
            return model;
        }

        // POST api/values
        [HttpPost]
        public void Post(int? id, PropertyDetails propertyDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    PropertyDetails propDetails = isNew ? new PropertyDetails
                    {
                        Id = id.Value
                    } : _context.Set<PropertyDetails>().SingleOrDefault(s => s.Id == id.Value);
                    propDetails.Address = propertyDetails.Address;
                    propDetails.Financial = propertyDetails.Financial;
                    propDetails.Physical = propertyDetails.Physical;
                    if (isNew)
                    {
                        _context.Add(propDetails);
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PropertyDetails propertyDetails = _context.Set<PropertyDetails>().SingleOrDefault(c => c.Id == id);
            _context.Entry(propertyDetails).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
