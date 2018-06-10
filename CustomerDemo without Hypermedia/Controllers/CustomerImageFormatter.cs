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
        private readonly IHostingEnvironment m_HostingEnvironment;
        private static readonly MediaTypeHeaderValue MediaType = new MediaTypeHeaderValue("image/png");

        public CustomerImageFormatter(IHostingEnvironment hostingEnvironment)
        {
            m_HostingEnvironment = hostingEnvironment;
            SupportedMediaTypes.Add(MediaType);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var stream = context.HttpContext.Response.Body;
            var c = context.Object as Customer;
            //c?.Image?.Save(stream, ImageFormat.Jpeg);
            if (!string.IsNullOrEmpty(c?.ImageFile))
            {
                var buf = File.ReadAllBytes(Path.Combine(m_HostingEnvironment.WebRootPath, c.ImageFile));
                stream.Write(buf, 0, buf.Length);
            }
            //stream.Position = 0;
            return Task.FromResult(stream);
        }
    }
}