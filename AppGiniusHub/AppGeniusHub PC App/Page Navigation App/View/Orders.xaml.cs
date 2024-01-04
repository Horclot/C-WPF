using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace Page_Navigation_App.View
{
    public partial class Orders : UserControl
    {
        public ObservableCollection<SampleData> SampleList { get; set; } = new ObservableCollection<SampleData>();

        public Orders()
        {
            InitializeComponent();
            GenerateRandomData();
            Worklist.ItemsSource = SampleList;
        }

        private void GenerateRandomData()
        {
            string apiUrl = "http://192.168.1.5:5000/orders";
            string jsonData = $"{{\"UserId\": \"{SharedData.Id}\"}}";

            // Очистка списка перед добавлением новых данных
            SampleList.Clear();

            // Получение данных с сервера
            string response = GetDataFromApi(apiUrl, jsonData);

            // Добавление данных в список
            var sampleDataList = JsonConvert.DeserializeObject<List<SampleData>>(response);

            // Добавление элементов поочередно
            foreach (var sampleData in sampleDataList)
            {
                // Преобразование int в строку и добавление символа доллара
                sampleData.Price = $"{sampleData.Price}$";
                SampleList.Add(sampleData);
            }
        }

        private string GetDataFromApi(string apiUrl, string jsonData)
        {
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                return client.UploadString(apiUrl, "POST", jsonData);
            }
        }
    }

    public class SampleData
    {
        public string Price { get; set; }
        public string ProductsNames { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
    }
}
