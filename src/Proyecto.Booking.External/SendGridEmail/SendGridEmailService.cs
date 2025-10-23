using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Proyecto.Booking.Application.External.SendGridEmail;
using Proyecto.Booking.Domain.Models.SendGridEmail;
using System.Text;
using DotNetEnv;

namespace Proyecto.Booking.External.SendGridEmail
{
    public class SendGridEmailService: ISendGridEmailService
    {
        private readonly IConfiguration _configuration;
        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> Execute(SendGridEmailRequestModel model)
        {
             Env.Load(@"Proyecto.Booking\.env");
            //string apiKey = _configuration.GetConnectionString("SendGridEmailKey");
            string apiUrl = "https://api.sendgrid.com/v3/mail/send";
            string apiKey = Environment.GetEnvironmentVariable("sendgrid") ?? "";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            client.DefaultRequestHeaders.Add("Accept", $"application/json");

            string emailContent = JsonConvert.SerializeObject(model);
            var response = await client.PostAsync(apiUrl,new StringContent(emailContent, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
