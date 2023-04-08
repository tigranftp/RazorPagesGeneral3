using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace RazorPagesGeneral
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }


    [Serializable]
    public class Testimonial
    {
        public string? CommentLabel { get; set; }
        public string? Comment { get; set; }
        public string? Name { get; set; }
        public string? JobTitle { get; set; }
        public string? ImageUrl { get; set; }
    }
    public interface ITestimonialService
    {
        IEnumerable<Testimonial> getAll();
    }

    public class TestimonialService : ITestimonialService
    {
        public IEnumerable<Testimonial> getAll()
        {
            var streamReader = new StreamReader("testimonials.json");

            string json = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<Testimonial[]>(json) ?? new Testimonial[] { };
        }
    }

}
