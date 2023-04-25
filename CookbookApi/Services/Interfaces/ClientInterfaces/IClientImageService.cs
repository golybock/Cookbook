using CookbookApi.Models.Database.Client;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.ClientInterfaces;

public interface IClientImageService
{
    public Task<ClientImage> GetClientImageAsync(int id);

    public Task<List<ClientImage>> GetClientImagesAsync(int clientId);
    
    public Task<List<ClientImage>> GetClientImagesAsync(int clientId, int limit);

    public Task<IActionResult> UploadClientImageAsync(string token, IFormFile file);

    public Task<IActionResult> DeleteClientImageAsync(string token, int id);
}