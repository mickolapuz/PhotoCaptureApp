using PhotoCaptureApplication.Entities.ViewModels;
using System.Net.Http.Json;

public class ConnectivityService
{
    public event Action<bool>? OnConnectivityChanged;
    public bool IsOnline { get; private set; }

    private readonly HttpClient _httpClient;
    private readonly FileStorageService _fileStorageService;

    public ConnectivityService(HttpClient httpClient, FileStorageService fileStorageService)
    {
        _httpClient = httpClient;
        _fileStorageService = fileStorageService;
        IsOnline = Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        Connectivity.Current.ConnectivityChanged += ConnectivityChanged;
    }

    private async void ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        IsOnline = e.NetworkAccess == NetworkAccess.Internet;
        OnConnectivityChanged?.Invoke(IsOnline);

        if (IsOnline)
        {
            await UploadPendingImages();
        }
    }

    private async Task UploadPendingImages()
    {
        var pendingImages = await _fileStorageService.GetPendingUploadsAsync();

        foreach (var photo in pendingImages)
        {
            var imageData = new PhotoViewModel
            {
                ImagePath = photo.ImagePath,
                Description = photo.Description
            };

            var response = await _httpClient.PostAsJsonAsync("api/photo/saveImage", imageData);

            if (response.IsSuccessStatusCode)
            {
                await _fileStorageService.ClearPendingUploadsAsync(); // Remove all uploaded images
            }
        }
    }
}