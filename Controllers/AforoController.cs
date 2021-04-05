using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Olimpia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AforoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Visitante> Get() => DatosPrograma.VisitantesEnum;

        [HttpGet("{id}")]
        public Visitante Get(int id) => DatosPrograma.VisitantesEnum.ElementAt(id);

        [HttpPost("{Entrada}")]
        public int Post(int Entrada, [FromBody] string NumID)
        {
            if (DatosPrograma.VisitantesEnum.Where(x => x.NumID == NumID).Count() == 0)
            {
                if (DatosPrograma.HinchasEnum.Where(x => x.NumID == NumID).Count() != 0)
                {
                    if (DatosPrograma.VisitantesEnum.Count() <= (DatosPrograma.Capacidad * (DatosPrograma.Aforo / 100)))
                    {
                        Visitante value = new Visitante();
                        value.NumID = NumID;
                        value.Entrada = Entrada;
                        value.FechaIngreso = DateTime.Now;
                        DatosPrograma.VisitantesEnum.Add(value);
                        return 0;
                    }
                    else //Aforo Lleno.
                        return 3;
                }
                else
                {
                    // Visitante no registrado en el sistema.
                    return 1;
                }
            }
            else { 
                //Visitante ya está dentro.
                return 2;
            }
        }

        [HttpDelete("{NumID}")]
        public int Delete(string NumID)
        {
            if (DatosPrograma.VisitantesEnum.Where(x => x.NumID == NumID).Count() != 0)
            {
                DatosPrograma.VisitantesEnum.Remove(DatosPrograma.VisitantesEnum.Where(x => x.NumID == NumID).ElementAt(0));
                return 0;
            }
            else
            {
                // Visitante no registrado en el sistema.
                return 1;
            }
        }

        [HttpOptions]
        public Hashtable Options()
        {
            EvHashtable retVal = new EvHashtable(); 
            float tmpval = (100 / DatosPrograma.Capacidad) * DatosPrograma.VisitantesEnum.Count;
            retVal.Add("capacidad", DatosPrograma.Capacidad);
            retVal.Add("aforo", DatosPrograma.Aforo);
            retVal.Add("porcentajeocupacion", tmpval.ToString("0.0").Replace(",", "."));
            tmpval = ((DatosPrograma.Capacidad * (DatosPrograma.Aforo / 100)) - DatosPrograma.VisitantesEnum.Count);
            retVal.Add("sillasdisponibles", Math.Round(tmpval,0).ToString("000"));
            tmpval = ((DatosPrograma.Capacidad * ((100 - DatosPrograma.Aforo) / 100)) - DatosPrograma.VisitantesEnum.Count);
            retVal.Add("sillasbloqueadas", Math.Round(tmpval, 0).ToString("000"));
            return retVal;
        }

        [HttpOptions("{name}")]
        public void Options(String name, [FromBody] object valor)
        {
            switch (name.ToLower().Trim())
            {
                case "capacidad":
                    DatosPrograma.Capacidad = Convert.ToInt32(valor);
                    break;
                case "aforo":
                    DatosPrograma.Aforo = Convert.ToSingle(valor);
                    break;
                default:
                    throw new AggregateException("Parámetro incorrecto.");
            }
        }
    }
}
