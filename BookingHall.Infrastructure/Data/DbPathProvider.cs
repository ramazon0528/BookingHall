namespace BookingHall.Infrastructure.Data;

public static class DbPathProvider
{
    public static string GetDbPath()
    {
        var directory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "BookingHall"
        );

        Directory.CreateDirectory(directory);

        return Path.Combine(directory, "BookingHall.db");
    }
}
