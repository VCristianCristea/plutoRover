using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pluto.Rover.Api.Exceptions;

namespace Pluto.Rover.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private const string MediaType = "application/json";

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (BadRequestException ex)    
            {
                context.Response.ContentType = MediaType;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (ObstacleHitException ex)    
            {
                context.Response.ContentType = MediaType;
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = MediaType;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}