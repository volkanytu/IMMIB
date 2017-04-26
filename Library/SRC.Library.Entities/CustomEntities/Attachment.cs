using SRC.Library.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRC.Library.Entities.CustomEntities
{
    public class Attachment
    {
        public EntityReferenceWrapper ObjectId { get; set; }
        public int? ObjectTypeCode { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Base64Data { get; set; }
        public int? FileSize { get; set; }

        public void SetMimeType()
        {
            var extension = Path.GetExtension(FileName).ToLower();
            MimeType = MimeTypeMap.GetMimeType(extension);
        }
    }
}
