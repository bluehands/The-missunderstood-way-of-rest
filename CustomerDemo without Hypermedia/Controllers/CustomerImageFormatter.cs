using System;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CustomerDemo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
//using Microsoft.AspNetCore.
using Microsoft.Net.Http.Headers;

namespace CustomerDemo.Controllers
{
    public class CustomerImageFormatter : OutputFormatter
    {


        public CustomerImageFormatter()
        {
            SupportedMediaTypes.Add("image/png");
            SupportedMediaTypes.Add("image/jpeg");
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(Customer).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
            var c = context.Object as Customer;

            return Task.Run(() => c?.Image?.Save(response.Body, ImageFormat.Jpeg));

        }

    }
}