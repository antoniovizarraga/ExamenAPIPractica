using ENT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ApiResponse
    {
        public List<Persona> personas = new List<Persona>();

            public static async Task<List<Persona>> ObtenerListadoMAUI()
            {
                List<Persona> listado = new List<Persona>();

                ApiResponse res = new ApiResponse();
                Uri miUri = new Uri($"https://localhost:7272/api/miapi");
                HttpClient mihttpClient = new HttpClient();

                try
                {
                    HttpResponseMessage miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                    if (miCodigoRespuesta.IsSuccessStatusCode)
                    {
                        string textoJsonRespuesta = await miCodigoRespuesta.Content.ReadAsStringAsync();
                        var personas = JsonConvert.DeserializeObject<List<Persona>>(textoJsonRespuesta);
                        if (personas != null)
                        {
                            listado.AddRange(personas);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    mihttpClient.Dispose();
                }

                return listado;
            }
            public static async Task<Persona> ObtenerObjMAUI(int id)
            {
                Persona obj = new Persona();

                ApiResponse res = new ApiResponse();
                Uri miUri = new Uri($"https://localhost:7272/api/miapi/{id}");
                HttpClient mihttpClient = new HttpClient();

                try
                {
                    HttpResponseMessage miCodigoRespuesta = await mihttpClient.GetAsync(miUri);

                    if (miCodigoRespuesta.IsSuccessStatusCode)
                    {
                        string textoJsonRespuesta = await miCodigoRespuesta.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<Persona>(textoJsonRespuesta);

                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    mihttpClient.Dispose();
                }

                return obj;
            }
            public static async Task<bool> InsertarObjMAUI(Persona obj)
            {
                Uri miUri = new Uri($"https://localhost:7272/api/miapi");
                HttpClient miHttpClient = new HttpClient();
                bool res;
                try
                {

                    string json = JsonConvert.SerializeObject(obj);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage respuesta = await miHttpClient.PostAsync(miUri, content);
                    res = respuesta.IsSuccessStatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    miHttpClient.Dispose();
                }
                return res;
            }

            public static async Task<bool> ActualizarObj(Persona obj)
            {
                Uri miUri = new Uri($"https://localhost:7272/api/miapi/{obj.Id}");
                HttpClient miHttpClient = new HttpClient();
                bool res;
                try
                {
                    string json = JsonConvert.SerializeObject(obj);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage respuesta = await miHttpClient.PutAsync(miUri, content);
                    res = respuesta.IsSuccessStatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    miHttpClient.Dispose();
                }
                return res;
            }

            public static async Task<bool> EliminarObj(int id)
            {
                Uri miUri = new Uri($"https://localhost:7272/api/miapi/{id}");
                HttpClient miHttpClient = new HttpClient();
                bool res;
                try
                {
                    HttpResponseMessage respuesta = await miHttpClient.DeleteAsync(miUri);

                    res = respuesta.IsSuccessStatusCode;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    miHttpClient.Dispose();
                }
                return res;
            }

    }
}
