using System.Net.Http;
using Cookbook.Settings;

namespace Cookbook.Api;

public class ApiBase
{
    // client token from appsettings.json
    protected string? Token {
        
        get => App.Settings?.Token;
        // костыль
        set
        {
            var settings = App.Settings;

            if(settings == null)
                SettingsManager.CreateAppSettingsIfNotExists();
            
            settings = App.Settings;

            if (settings != null)
            {
                settings.Token = value;

                SettingsManager.SaveSettings(settings);
            }
        } 
    }
    
    // base request url
    protected readonly string BaseUrl = "https://localhost:7234/api";

    // controller names
    protected readonly string Auth = "Auth";

    protected readonly string Category = "Category";
    
    protected readonly string Client = "Client";
    
    protected readonly string Ingredient = "Ingredient";
    
    protected readonly string Measure = "Measure";
    
    protected readonly string Recipe = "Recipe";
    
    protected readonly string RecipeType = "RecipeType";

    // client
    protected HttpClient GetHttpClient() => new HttpClient();
}