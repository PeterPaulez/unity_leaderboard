using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

public class getLeaders : MonoBehaviour
{
    private const string URL = "https://leaderboardsausagevoid.herokuapp.com/api";
    private string urlParameters = "?get";


    // Start is called before the first frame update
    async System.Threading.Tasks.Task Start()
    {
        Debug.Log("Hola mundo Acción");
        HttpClient client = new HttpClient();
        client.BaseAddress = new System.Uri(URL);

        // Add an Accept header for JSON format.
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        // List data response.
        HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
        if (response.IsSuccessStatusCode)
        {
            // Parse the response body.
            Debug.Log("Contenido");
            Debug.Log(response.Content);

            var customerJsonString = await response.Content.ReadAsStringAsync();
            var dataObjects = JsonConvert.DeserializeObject(customerJsonString);
            Debug.Log(customerJsonString);

            /*
            foreach (int i in dataObjects.Results)
            {
                Debug.Log("{0}", i);
            }
            */
            
        }
        else
        {
            Debug.Log("{0} ({1})");
            Debug.Log(response.StatusCode);
            Debug.Log(response.ReasonPhrase);
        }

        //Make any other calls using HttpClient here.

        //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
        client.Dispose();
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}