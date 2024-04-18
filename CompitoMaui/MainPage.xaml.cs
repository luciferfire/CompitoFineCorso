using System.Collections.ObjectModel;
using CompitoMaui.Models;
using System.Net.Http.Json;
using System.Net.Http;
namespace CompitoMaui
{
    public partial class MainPage : ContentPage
    {
        private string _apiCity = "https://api.jsonbin.io/v3/b/6620334ce41b4d34e4e60a2c";

        private readonly HttpClient _httpClient;

        public ObservableCollection<CityResults> cityResults { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            _httpClient = new HttpClient();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            cityResults.Clear();
            var responseCity = await _httpClient.GetFromJsonAsync<CityResults>(_apiCity);

            cityResults?.Add(responseCity);
            
        
        }



    }

}
