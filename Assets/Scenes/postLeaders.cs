using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

public class postLeaders : MonoBehaviour
{
    private const string URL = "http://localhost:3000/api";

    async System.Threading.Tasks.Task Start()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new System.Uri(URL);

        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        // List data response.
        var content = new StringContent("{\"name\":\"C#\",\"value\":20,\"volume\":2}", Encoding.UTF8, "application/json");

        HttpResponseMessage response = client.PostAsync(URL, content).Result;
        if (response.IsSuccessStatusCode)
        {
            // Parse the response body.
            Debug.Log("Contenido");
            Debug.Log(response.Content);

            var customerJsonString = await response.Content.ReadAsStringAsync();
            var dataObjects = JsonConvert.DeserializeObject(customerJsonString);
            Debug.Log(customerJsonString);

            // LeaderBoard en customerJsonString.ranking
        }
        else
        {
            Debug.Log("{0} ({1})");
            Debug.Log(response.StatusCode);
            Debug.Log(response.ReasonPhrase);
        }
        client.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
