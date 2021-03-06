﻿using Application.ViewModel;
using Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.Middleware
{
    public class RestfulMiddleware
    {
        private readonly RequestDelegate _next;

        public RestfulMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var x = new Error();
            var statusCode = 0;
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is BasicException)
                {
                    var basicException = (BasicException)ex;
                    statusCode = basicException.ERROR_CODE;
                    x.Message = basicException.Message;

                }
                else
                {
                    statusCode = 500;
                    x.Message = ex.Message;

                }

                var _objserialized = JsonConvert.SerializeObject(x);

                context.Response.Clear();
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(_objserialized);
            }
        }
    }
    public static class RestfulMiddlewareExtensions
    {
        public static IApplicationBuilder UseRestfulMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RestfulMiddleware>();
        }
    }
}
