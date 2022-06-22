namespace XotaApi.Models
{
    public interface IXotaItemBase
    {
        long Id { get; }
        string? Source { get; }
        string? Band { get; }
        string? Frequency { get; }
        string? LocationName { get; }
        string? LocationCode { get; }
        string? ActivatorName { get; }
        string? ActivatorCallsign { get; }
        DateTime? DateTime { get; }
        string? Mode { get; }

        // void FillFrom(string jsonInput);
        
    }
}