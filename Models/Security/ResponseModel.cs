using System.ComponentModel;

namespace ms_partnership.Models.Security
{
    public class ResponseModel
    {
        [DefaultValue(true)]
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}