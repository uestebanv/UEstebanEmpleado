using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.UestebanEmpleadoContext context = new DL.UestebanEmpleadoContext())
                {
                    var query = context.CatEntidadFederativas.FromSqlRaw("CatEntidadFederativaGetAll").ToList();

                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            ML.Estado estado = new ML.Estado();

                            estado.IdEstado = item.IdEntidadFederativa;
                            estado.Nombre = item.Estado;

                            result.Objects.Add(estado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo consultar la informacion";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
