namespace StoreManagement.Api;

/// <summary>
/// Represents a sample weather forecast model used by the demo API.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Forecast date.
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Temperature in Celsius.
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Temperature converted to Fahrenheit.
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Optional summary text describing the weather condition.
    /// </summary>
    public string? Summary { get; set; }
}
