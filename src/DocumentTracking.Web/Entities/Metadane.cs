using DocumentTracking.Constants;
using System;

namespace DocumentTracking.Entities
{
    public class Metadane : BaseEntity
    {
        public Metadane():base()
        {

        }

        public string Name { get; set; }

        public TypeFile FileFormat { get; set; }

        public DateTime DateCreated { get;set; }

        public long Size { get; set; }
    }
}
