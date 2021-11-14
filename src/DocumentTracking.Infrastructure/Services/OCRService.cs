
using DocumentTracking.ApplicationCore.Entities;
using DocumentTracking.Infrastructure.Services.Intecace;
using Microsoft.Extensions.Configuration;
using Tesseract;

namespace DocumentTracking.Infrastructure.Services
{
    public class OCRService: IOCRService
    {
        private readonly string DATA_PACH;
        private readonly string Language = "pol";
        public OCRService(IConfiguration configuration)
        {
            if (configuration.GetSection("DATA_PACH").Exists())
            {
                DATA_PACH = configuration.GetSection("DATA_PACH").Value;
            }
        }

        public Invoice GetInvoice(string imagePath)
        {
            Invoice invoice = null;
            using var engine = new TesseractEngine(DATA_PACH, Language, EngineMode.Default);
                using var img = Pix.LoadFromFile(imagePath);
                    using var page = engine.Process(img);
                        var text = page.GetText();
                        using var iter = page.GetIterator();
                            iter.Begin();
                            do
                            {
                                if (iter.IsAtBeginningOf(PageIteratorLevel.TextLine))
                                {
                                    invoice = GetInvoice(iter.GetText(PageIteratorLevel.TextLine), iter);
                                }
                               
                            } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
            return invoice;
        }

        private Invoice GetInvoice(string key, ResultIterator iterator)
        {
            var invoice = new Invoice();
            do
            {
                if (iterator.IsAtBeginningOf(PageIteratorLevel.TextLine))
                {
                   
                }

            } while (iterator.Next(PageIteratorLevel.TextLine));

            return invoice;
        }
    }
}
