public class TextsStorage
{
    public static string GetCollectText(string axisName, Pickup pickup)
        => $"Press {axisName} to collect {pickup.Name}.";
}
