using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Olimpia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinchasController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Hincha> Hinchas() => DatosPrograma.HinchasEnum;

        [HttpGet("{id}")]
        public Hincha Get(int id) => DatosPrograma.HinchasEnum.ElementAt(id);

        [HttpPost]
        public void Post([FromBody] Hincha value)
        {
            if (DatosPrograma.HinchasEnum.Where(x => x.NumID == value.NumID).Count() == 0)
            {
                DatosPrograma.HinchasEnum.Add(value);
            }
            else throw new AggregateException("Hincha ya existe.");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DatosPrograma.HinchasEnum.RemoveAt(id);
        }
    }
}
