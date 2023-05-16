using LBA_Dominios.ModelosConsultas;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LBA_Services
{
    public class UserServices
    {


        public async Task<string> LoginUser()
        {
            using (var httpClient = new HttpClient())
            {


                string url = "http://23.102.103.53:5200/api/Login";
                string requestBody = "{\"userName\":\"user\",\"password\":\"1234\"}";
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var respuesta = await httpClient.PostAsync(url, content);
                if (respuesta.IsSuccessStatusCode)
                {
                    var responseContent = await respuesta.Content.ReadAsStringAsync();
                   
                    return responseContent;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> ConteoVehiculos(InformacionDto informacionDto)
        {
            using (var httpClient = new HttpClient())
            {
                string fecha = informacionDto.fecha;
                string token = informacionDto.token;

                string url = $"http://23.102.103.53:5200/api/ConteoVehiculos/{fecha}";

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", $"Bearer {token}");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                
                if (response.IsSuccessStatusCode)
                {
                    var respuesContent = await response.Content.ReadAsStringAsync();
                    return respuesContent;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<string> RecaudoVehiculos(InformacionDto informacionDto)
        {
            using (var httpClient = new HttpClient())
            {
                string fecha = informacionDto.fecha;
                string token = informacionDto.token;


                string url = $"http://23.102.103.53:5200/api/RecaudoVehiculos/{fecha}";

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", $"Bearer {token}");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var respuesContent = await response.Content.ReadAsStringAsync();
                    return respuesContent;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
