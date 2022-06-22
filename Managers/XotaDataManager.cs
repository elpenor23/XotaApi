using XotaApi.Models;
using System.Net.Http.Headers;

namespace XotaApi.Managers;

public class XotaDataManager{
    public async Task<List<IXotaItem>> GetXotaItems(string[]? xotaEntities = null){
        xotaEntities = xotaEntities ?? new string[] {"All"};

        List<IXotaItem> data = new List<IXotaItem>();

        //TODO: Each of these should be put into a class with an interface
        //      So instad of adding code here we can just add a class that implements that interface
        //      and we can just loop through those classes here maybe with an array so we can just add
        //      class types to the array and the manager will stay nice and clean and those classes
        //      can deal with all of the nitty gritty for getting each of the item types
        //      since we are probably going to have to do more complicated things then just hit API's
        //      for some of the other types.
        //TODO: Add API endpoints to settings in a way so we do not have to update code if 
        //      the end points change
        
        var potaTestData = await this.GetXotaListAsync("https://api.pota.app/spot/activator");
        var potaData = this.ConvertJsonToXotaItem<PotaItem>(potaTestData);

        data.AddRange(potaData);

        var sotaTestData = await this.GetXotaListAsync("https://api2.sota.org.uk/api/spots/-1/all");
        var sotaData = this.ConvertJsonToXotaItem<SotaItem>(sotaTestData);

        data.AddRange(sotaData);

        if (data.Count == 0) return new List<IXotaItem>();

        var sortedData = data.OrderByDescending(x => x.Band).ToList();

        return sortedData;
    }

    private List<IXotaItem> RemoveDuplicates(List<IXotaItem> xotaList)
    {
        //TODO: Fix this when we have determined the best ID that will work
        //      for all Xota types.

        var nonDupList = xotaList.GroupBy(x => x.Id).Select(y => y.First()).ToList();

        foreach (IXotaItem xm in nonDupList){

        }

        return xotaList;
    }
    private async Task<string> GetXotaListAsync(string uri)
    {
        string result = "[{}]";

        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method
            HttpResponseMessage response = await client.GetAsync(uri);
            
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                var errorMessage = string.Format($"Error Getting data from {uri}. Status Code: {response.StatusCode}");
                throw new Exception(errorMessage);
            }
        }

        return result;
    }

    public List<Models.IXotaItem> ConvertJsonToXotaItem<T>(string json_string) where T : Models.IXotaItem, new()
    {
        var returnData = new List<Models.IXotaItem>();

        dynamic? jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject(json_string);

        if (jsonData != null)
        {
            foreach (var item in jsonData)
            {
                T xotaItem = new T();

                xotaItem.FillFromJson(item);
                returnData.Add(xotaItem);
            }
        }

        return returnData;
    }
}