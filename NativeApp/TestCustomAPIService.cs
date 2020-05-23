using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NativeApp
{
    public class TestCustomAPIService
    {
        private string _resource;


        public TestCustomAPIService()
        {
            _resource = ConfigurationManager.AppSettings.Get("resourceServer");
        }



        private async Task<string> getTokenAsync()
        {
            var tenantName = ConfigurationManager.AppSettings.Get("tenantName");
            var aad = ConfigurationManager.AppSettings.Get("aad");
            var authority = string.Format(CultureInfo.InvariantCulture, aad, tenantName);
            var clientId = ConfigurationManager.AppSettings.Get("clientId");
            var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authority);
            X509Certificate2 cert = Helper.GetCertificateBySubject();
            var certCred = new Microsoft.IdentityModel.Clients.ActiveDirectory.ClientAssertionCertificate(clientId, cert);

            string token = null;
            Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult result = await authContext.AcquireTokenAsync(_resource, certCred);
            if (result != null)
            {
                token = result.AccessToken;
            }
            return token;
        }


        public async Task ChargedGetAsync(string text)
        {
            try
            {
                var token = await getTokenAsync();
                if (token != null)
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage response = await httpClient.GetAsync($"{_resource}/api/charged?text={text}");
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response and output it to the console.
                        string s = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response:  {0}\n", s);
                    }
                    else
                    {
                        Console.WriteLine("Failed to call TestGet\nError:  {0}\n", response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public async Task FreeGetAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync($"{_resource}/api/free");
                if (response.IsSuccessStatusCode)
                {
                    // Read the response and output it to the console.
                    string s = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response:  {0}\n", s);
                }
                else
                {
                    Console.WriteLine("Failed to call FreeGet\nError:  {0}\n", response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
