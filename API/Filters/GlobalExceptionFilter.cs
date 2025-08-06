using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;
using Shared.Vistas;
using System.Net;

namespace API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string error = "Ocurrio un error inesperado, por favor intente mas tarde";
            int statusCode = (int) HttpStatusCode.InternalServerError;

            if (context.Exception is ValidationException fluentException)
            {
                error = "Error de validacion de datos: " + string.Join(",", fluentException.Errors.Select(e => e.ErrorMessage));
                statusCode = (int) HttpStatusCode.BadRequest;
            }
            if(context.Exception is ApiException apiException)
            {
                error = "Error de API: " + apiException.Message;

                if (apiException.Message.Contains("no encontrado", StringComparison.OrdinalIgnoreCase))
                {
                    statusCode = (int) HttpStatusCode.NotFound;
                }
                else
                {
                    statusCode = (int) HttpStatusCode.BadRequest;
                }
            }
            if (context.Exception is DbUpdateException dbUpdateException)
            {
                error = "Error al actualizar la base de datos: " + dbUpdateException.InnerException?.Message;
            }

            var result = new GenericResponse(error);
            context.Result = new ObjectResult(result) { StatusCode = statusCode };
            context.ExceptionHandled = true;
        }
    }
}
