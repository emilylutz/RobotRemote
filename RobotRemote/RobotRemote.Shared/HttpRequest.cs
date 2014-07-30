using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.IO;

namespace RobotRemote
{
    class HttpRequest
    {
        private string node_host = "robotcontrol.azurewebsites.net";//"wof-nodebot.azurewebsites.net"; //"robotcontrol.azurewebsites.net"; //CHANGE BACK TO "[your host]"
        string json;
        public HttpRequest(string body)
        {
            json = body;
        }
        public void sendInstructions()
        {
            string sURL = "http://" + node_host + "/robot/list";
            //Uri url = new Uri(sURL);

            try
            {
                // Create the web request object 
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(sURL);
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";//;charset=utf-8";
                webRequest.Accept = "application/json";
                //webRequest.Host = node_host;
                webRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), webRequest);
            }
            catch { }
        }
        void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the stream request operation 
            Stream postStream = webRequest.EndGetRequestStream(asynchronousResult);

            // Create the post data 

            //var input = Newtonsoft.Json.JsonConvert.SerializeObject(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            // Add the post data to the web request 
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Dispose();

            // Start the web request 
            webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
        }
        void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                // End the get response operation 
                HttpWebResponse response = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(streamResponse);
                var responses = streamReader.ReadToEnd();
                String stringResponses = (String)responses;
                streamResponse.Dispose();
                streamReader.Dispose();
                response.Dispose();

            }
            catch (WebException e)
            {
                // Error treatment 
                // ... 
            }
        } 
    }
}
