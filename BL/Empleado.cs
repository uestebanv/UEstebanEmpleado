using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.UestebanEmpleadoContext context = new DL.UestebanEmpleadoContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.Nombre}'," +
                                                                           $"'{empleado.ApellidoPaterno}'," +
                                                                           $"'{empleado.ApellidoMaterno}'," +
                                                                           $"'{empleado.Estado.IdEstado}'");
                    if(query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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


        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.UestebanEmpleadoContext context = new DL.UestebanEmpleadoContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate '{empleado.IdEmpleado}'," +
                                                                               $"'{empleado.Nombre}'," +
                                                                               $"'{empleado.ApellidoPaterno}'," +
                                                                               $"'{empleado.ApellidoMaterno}'," +
                                                                               $"'{empleado.Estado.IdEstado}'");
                    if(query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static ML.Result Delete(int idEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.UestebanEmpleadoContext context = new DL.UestebanEmpleadoContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete '{idEmpleado}'");

                    if(query >= 1 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.UestebanEmpleadoContext context = new DL.UestebanEmpleadoContext())
                {
                    var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();
                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var items in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = items.IdEmpledo;
                            empleado.NumeroNomina = items.NumeroNomina;
                            empleado.Nombre = items.Nombre;
                            empleado.ApellidoPaterno = items.ApellidoPaterno;
                            empleado.ApellidoMaterno = items.ApellidoMaterno;
                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = items.IdEstado.Value;
                            empleado.Estado.Nombre = items.Estado;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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


        public static ML.Result GetById(int idEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.UestebanEmpleadoContext context = new DL.UestebanEmpleadoContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetById '{idEmpleado}'").AsEnumerable().FirstOrDefault();

                    if(query != null )
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.IdEmpleado = query.IdEmpledo;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = query.IdEstado.Value;
                        empleado.Estado.Nombre = query.Estado;

                        result.Object = empleado;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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