using System.Text.Json;

public class FileStorageService
{
    private readonly string _filePath;

    public FileStorageService()
    {
        _filePath = Path.Combine(FileSystem.AppDataDirectory, "pending_uploads.json");
    }

    public async Task<List<PendingPhoto>> GetPendingUploadsAsync()
    {
        if (!File.Exists(_filePath))
            return new List<PendingPhoto>();

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<PendingPhoto>>(json) ?? new List<PendingPhoto>();
    }

    public async Task AddPendingUploadAsync(PendingPhoto photo)
    {
        var pendingImages = await GetPendingUploadsAsync();
        pendingImages.Add(photo);
        var json = JsonSerializer.Serialize(pendingImages);
        await File.WriteAllTextAsync(_filePath, json);
    }

    public async Task ClearPendingUploadsAsync()
    {
        if (File.Exists(_filePath))
        {
            await File.WriteAllTextAsync(_filePath, "[]"); // Clear the file
        }
    }

    public async Task<int> GetPendingUploadCountAsync()
    {
        var pendingImages = await GetPendingUploadsAsync();
        return pendingImages.Count;
    }

    public async Task SavePendingUploadsAsync(List<PendingPhoto> pendingPhotos)
    {
        var json = JsonSerializer.Serialize(pendingPhotos);
        await File.WriteAllTextAsync(_filePath, json);
    }
}

public class PendingPhoto
{
    public string ImagePath { get; set; }
    public string Description { get; set; }
}
