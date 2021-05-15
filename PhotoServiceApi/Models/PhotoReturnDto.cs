using System;

namespace PhotoServiceApi.Models
{
    public class PhotoReturnDto
    {
        public Guid Id { get; set; }

        public string Url { get; set; }
    }
}