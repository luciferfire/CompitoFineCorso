using System.Collections.ObjectModel;
using CompitoMaui.Models;
using System.Net.Http.Json;
using System.Net.Http;
namespace CompitoMaui;

public partial class Meteo : ContentPage
{
    private string _apiMeteo = "https://api.jsonbin.io/v3/b/662034fead19ca34f85bbe8b";
    private readonly HttpClient _httpClient;

    public ObservableCollection<Daily> dailyList { get; set; } = new();

    public Meteo()
    {
        InitializeComponent();
        BindingContext = this;
        _httpClient = new HttpClient();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        dailyList.Clear();
        var responseMeteo = await _httpClient.GetFromJsonAsync<MeteoResults>(_apiMeteo);

        responseMeteo?.record?.timelines?.daily?.ForEach(daily =>
        {
            dailyList.Add(daily);
        });

        foreach (var item in dailyList)
        {
            DateTime today = DateTime.Today;

            string dateString = item.time.ToString();

            DateTime compare = DateTime.Parse(dateString);

            if (compare.Date == today)
            {

                ImageStatus.Text = Icon(item.status);
                TempStatus.Text = item.values.temperatureAvg.ToString() + " °C";
            }
            item.status = Icon(item.status);
        }
    }
    public string Icon(string statusString)
    {
        string icon = "";

        switch (statusString)
        {
            case "sunny":
                icon = "☀";
                break;
            case "cloudy":
                icon = "☁️";
                break;
            case "thunderstorm":
                icon = "⛈️";
                break;
            case "windy":
                icon = "🌬️";
                break;
            case "rainy":
                icon = "🌧️";
                break;
            default:
                break;
        }

        return icon;
    }



}
