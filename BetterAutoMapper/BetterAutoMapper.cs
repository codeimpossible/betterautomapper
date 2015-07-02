using Newtonsoft.Json;

namespace BetterAutoMapper
{
    public static class BAM
    {
        public static readonly BetterAutoMapper BOOM = new BetterAutoMapper();
    }

    public class BetterAutoMapper
    {
        public TTo Map<TFrom, TTo>(TFrom from)
        {
            var json = JsonConvert.SerializeObject(from);
            return JsonConvert.DeserializeObject<TTo>(json);
        }
    }
}
