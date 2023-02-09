using Newtonsoft.Json;

namespace BLL.DTO.MainDTO
{
    public class ModelStateErrorDetails
    {
        public int Status { get; set; }

        public string Title { get; set; }

        public string TraceId { get; set; }

        public string Type { get; set; }

        public AdminDTO Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
