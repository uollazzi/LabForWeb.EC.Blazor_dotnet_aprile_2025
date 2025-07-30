using LabForWeb.EC.Blazor.Models;
using System.Net.Http.Json;

namespace LabForWeb.EC.Blazor.Services;

public interface IECService
{
    Task<IEnumerable<ProdottoModel>> GetProdotti();
}

public class ECService : IECService
{
    private readonly HttpClient _http;

    public ECService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<ProdottoModel>> GetProdotti()
    {
        // chiamata ajax al server API per recuperare i prodotti in formato JSON
        var prodotti = await _http.GetFromJsonAsync<List<ProdottoModel>>("api/prodotti");

        return prodotti;
    }
}
