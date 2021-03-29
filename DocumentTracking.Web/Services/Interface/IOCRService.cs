using DocumentTracking.Entities;

namespace DocumentTracking.Services.Intecace
{
    public interface IOCRService
    {
        public Invoice GetInvoice(string imagePath);
    }
}
