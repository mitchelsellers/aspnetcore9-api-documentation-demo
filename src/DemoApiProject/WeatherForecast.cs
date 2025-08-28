namespace DemoApiProject;

/// <summary>
///     Represents a single point-in-time weather forecast
/// </summary>
public class WeatherForecast
{
    /// <summary>
    ///     The Date of the weather forecast
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    ///     The current temperature in Celsius
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    ///     The current temperature converted to F
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    ///     An overall summary of the current weather
    /// </summary>
    public string? Summary { get; set; }
}