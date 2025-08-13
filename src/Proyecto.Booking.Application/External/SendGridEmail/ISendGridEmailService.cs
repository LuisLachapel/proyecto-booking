using Proyecto.Booking.Domain.Models.SendGridEmail;

namespace Proyecto.Booking.Application.External.SendGridEmail
{
    public interface ISendGridEmailService
    {
        Task<bool> Execute(SendGridEmailRequestModel model);
    }
}
