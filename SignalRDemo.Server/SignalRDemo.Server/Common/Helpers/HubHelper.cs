namespace SignalRDemo.Server.Common.Helpers;

public static class HubHelper
{
    public static string GetGroupNameForJurisdiction(string jurisdiction)
    {
        return $"Jurisdiction_{jurisdiction}";
    }
}