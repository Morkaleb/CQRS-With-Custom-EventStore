using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRSWITHES.Infra.ReadModels
{
    [Route("r/")]
    public class ReadModelController : Controller
    {
        [HttpGet("{key}")]
        [Route("/api/r/{key}")]
        public JsonResult Get(string key)
        {
            var blah = Book.book;
            if (Book.book.ContainsKey(key))
            {
                List<ReadModelData> returnable = Book.book[key];
                if (Request.QueryString.HasValue)
                {
                    List<ReadModelData> filtered = new List<ReadModelData>();
                    string query = Request.QueryString.ToString().Split("?")[1];
                    string param = query.Split("=")[0];
                    string value = query.Split("=")[1];
                    foreach (ReadModelData data in returnable)
                    {
                        Type dataType = data.GetType();
                        foreach (PropertyInfo propertyInfo in dataType.GetProperties())
                        {
                            var DataValue = getValues(data, propertyInfo.Name).ToString();
                            if (propertyInfo.Name == param && DataValue == value)
                            {
                                filtered.Add(data);
                            }
                        }
                    }
                    return Json(filtered);
                }
                else { return Json(returnable); }
            }
            else { return Json(Book.book); }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static string getValues(object anEvent, string name)
        {
            var value = anEvent.GetType().GetProperties()
                .Single(pi => pi.Name == name)
                .GetValue(anEvent, null);
            if(value == null) { return ""; }
            return value.ToString();
        }
    }    
}
