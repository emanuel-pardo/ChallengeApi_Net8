using AutoMapper;
using DTO;
using Entities;
using Interfaces;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace Manager
{
    public class BSManager : IBSManager
    {
        private static readonly Dictionary<string, string> Endpoints = new Dictionary<string, string>
    {
        { "https://mercadopago.bistrosoft.com/api/check", "Mercado Pago" },
        { "https://modo.bistrosoft.com/api/v1/check", "Modo" },
        { "https://multidelivery.bistrosoft.com/api/check", "Multidelivery" },
        { "https://mx-clip.bistrosoft.com/api/v1.0/check", "Clip" }
    };

        private readonly HttpClient _httpClient;
        private readonly ISystemStatusRepository _repository;
        private readonly IMapper _map;

        public BSManager(HttpClient httpClient, ISystemStatusRepository repository, IMapper mapper)
        {
            _httpClient = httpClient;
            _repository = repository;
            _map = mapper;
        }
        

        public async Task<ResponsesDTO> GetStatusesAsync()
        {
            var responses = new ResponsesDTO();
            try
            {
                foreach (var endpoint in Endpoints ?? new Dictionary<string, string>())
                {
                    var response = await GetResponsesSystemsAsync(endpoint);
                    if (response != null)
                    {
                        var systemmapped =_map.Map<ResponseDTO, SystemStatus>(response);
                        
                        await _repository.SaveSystemStatusAsync(systemmapped);

                        responses.statuses.Add(response);

                    }
                }

                var listDB = await _repository.GetAllSystemStatusAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estados de los sistemas", ex);
            }

            return responses;
        }
        #region Metodos Privados
        private async Task<ResponseDTO> GetResponsesSystemsAsync(KeyValuePair<string, string> dicEndpoint)
        {
            RequestDTO? request = null;
            var httpresponse = await _httpClient.GetAsync(dicEndpoint.Key);
            if (httpresponse.StatusCode.Equals(HttpStatusCode.OK))
            {
                var responsejson = await httpresponse.Content.ReadAsStringAsync();
                request = JsonConvert.DeserializeObject<RequestDTO>(responsejson);
            }



            return ObtenerResponseDto(request!, dicEndpoint.Value);

        }

        private ResponseDTO ObtenerResponseDto(RequestDTO request, string plataformName)
        {
            ResponseDTO? response = null;
            if (request != null)
            {
                response = new ResponseDTO
                {
                    PlataformName = plataformName ?? "Plataforma no brindada",
                    Status = request.ResponseCode.HasValue ? request.ResponseCode.Value.Equals(0) ? ResponseDTO.LeyendaOk :  request.ResponseCode.Value.Equals(-1) ?  ResponseDTO.LeyendaError :
                            "Desconocido" : "S/Status",
                    Version = request.Version ?? "S/Version"

                };

            }
            return response!;
        }
        #endregion



    }
}
