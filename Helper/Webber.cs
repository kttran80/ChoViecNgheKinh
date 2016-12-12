using System;
//using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Onha.Kiet
{
   public delegate Task<string> GetDataDeligate(string url);
   public class Webber
    {
        HttpClient _client;
        public Webber(string hostname)
        {
            // at company
            //var handler = new HttpClientHandler
            //{
            //    UseDefaultCredentials = false,
            //    DefaultProxyCredentials = CredentialCache.DefaultCredentials,
            //    Credentials = CredentialCache.DefaultCredentials
            //};

            //_client = new HttpClient(handler)
            //{
            //    MaxResponseContentBufferSize = 1000000
            //};

            /*
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

            */

            _client = new HttpClient();           
            // _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml"); 
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Chrome/54.0.2840.71 (Macintosh; Intel Mac OS X 10_12_1) Gecko/20100101 Firefox/19.0");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");


            if (!string.IsNullOrEmpty(hostname))
            {
                _client.BaseAddress = new Uri(hostname);
            }

        }

        public Task<string> GetStringAsync(string path)
        {
            
            return _client.GetStringAsync(path);
        }

        public Task<string> GetStringPostAsync(string path, string data, string contentType = "application/x-www-form-urlencoded")
        {
            StringContent queryString = new StringContent(data, Encoding.UTF8, contentType);
            
            HttpResponseMessage response = _client.PostAsync(new Uri(path), queryString ).Result; // content type here http://stackoverflow.com/questions/10679214/how-do-you-set-the-content-type-header-for-an-httpclient-request

            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync();
        }

        public Task<byte[]> DownloadFile(string path, string mime = "image/png, image/svg+xml, image/*;q=0.8, */*;q=0.5")
        {
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", mime);
            Task<byte[]> buffer =  _client.GetByteArrayAsync(path); 
            
            return buffer;
        }
    }
}