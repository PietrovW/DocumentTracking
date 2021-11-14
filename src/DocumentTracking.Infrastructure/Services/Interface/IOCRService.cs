using DocumentTracking.ApplicationCore.Entities;

namespace DocumentTracking.Infrastructure.Services.Intecace
{
    public interface IOCRService
    {
        public Invoice GetInvoice(string imagePath);
    }
}
