using NalaTest.Application.Interfaces.Base;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace NalaTest.Application.Services.Base
{
    [Serializable]
    public class WebRequestService : IWebRequestService
    {
        public async Task<string?> HttpClientRequest(string url, string? accessToken, object? requestBody, HttpMethod methodType, IDictionary<string, string>? headers = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if (headers != null)
                        if (headers.Count > 0)
                        {
                            foreach (var item in headers)
                            {
                                client.DefaultRequestHeaders.Add(item.Key, item.Value);
                            }
                        }

                    if (!string.IsNullOrEmpty(accessToken))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    StringContent? stringContent = null; ;
                    string result = string.Empty;
                    string body = string.Empty;
                    if (methodType == HttpMethod.Post)
                    {
                        body = JsonConvert.SerializeObject(requestBody);
                        stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                        result = await client.PostAsync(url, stringContent).ContinueWith<string>((response1) =>
                        {
                            return response1.Result.Content.ReadAsStringAsync().Result;
                        });

                        return result;
                    }
                    else if (methodType == HttpMethod.Patch)
                    {
                        body = JsonConvert.SerializeObject(requestBody);
                        stringContent = new StringContent(body, Encoding.UTF8, "application/json");

                        result = await client.PatchAsync(url, stringContent).ContinueWith<string>((response1) =>
                        {
                            return response1.Result.Content.ReadAsStringAsync().Result;
                        });

                        return result;
                    }
                    else if (methodType == HttpMethod.Delete)
                    {
                        body = JsonConvert.SerializeObject(requestBody);
                        stringContent = new StringContent(body, Encoding.UTF8, "application/json");

                        result = await client.DeleteAsync(url).ContinueWith<string>((response1) =>
                        {
                            return response1.Result.Content.ReadAsStringAsync().Result;
                        });

                        return result;
                    }
                    else if (methodType == HttpMethod.Put)
                    {
                        body = JsonConvert.SerializeObject(requestBody);
                        stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                        result = await client.PutAsync(url, stringContent).ContinueWith<string>((response1) =>
                        {
                            return response1.Result.Content.ReadAsStringAsync().Result;
                        });
                        return result;
                    }
                    else
                    {
                        result = await client.GetAsync(url).ContinueWith<string>((response1) =>
                        {
                            return response1.Result.Content.ReadAsStringAsync().Result;
                        });
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

    }
}
