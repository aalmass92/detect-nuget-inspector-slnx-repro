using Newtonsoft.Json;
using NLog;
using Serilog;

namespace SampleLib;

public class StringHelper
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public static string Serialize(object obj)
    {
        _logger.Debug("Serializing object");
        return JsonConvert.SerializeObject(obj);
    }

    public static T? Deserialize<T>(string json)
    {
        Log.Debug("Deserializing JSON: {Json}", json);
        return JsonConvert.DeserializeObject<T>(json);
    }
}
