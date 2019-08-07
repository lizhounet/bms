using IdentityModel.Client;
using System;
using System.Net.Http;
using Xunit;

namespace Zhouli.XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1Async()
        {
            string strAccessToken = "";
            {
                var client = new HttpClient();
                var response = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = "http://localhost:5000/connect/token",
                    ClientId = "zhouli",
                    ClientSecret = "991022",
                    Scope = "Zhouli.FileService"
                });
                strAccessToken = response.Result.AccessToken;
            }
            {

                var client = new HttpClient();
                client.SetBearerToken(strAccessToken);

                var response =  client.GetAsync("http://localhost:5001/Blog");
                if (!response.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.Result.StatusCode);
                }
                else
                {
                    var content = await response.Result.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                }
            }
        }
    }
}
