using NalaTest.Application.Interfaces;
using NalaTest.Application.Interfaces.Base;
using NalaTest.Domain.Entity;
using NalaTest.Domain.Entity.DTOs;
using Newtonsoft.Json;

namespace NalaTest.Application.Services
{
    public class UserService : IUserService
    {
        private readonly string baseUrl = "https://gorest.co.in/public/v2";
        private readonly IWebRequestService _webRequest;

        public UserService(IWebRequestService webRequest)
        {
            _webRequest = webRequest;
        }

        public async Task<ResultTyped<UserDto>> FindUserByEmail(string email)
        {
            var result = new ResultTyped<UserDto>();
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    result.Message = "email is required.";
                    return result;
                }
                var url = $"{baseUrl}/users?email={email}";
                var apiResponse = await _webRequest.HttpClientRequest(url, null, null, HttpMethod.Get);
                result.Entity = JsonConvert.DeserializeObject<IList<UserDto>>(apiResponse ?? "").FirstOrDefault();
                result.Code = 1;
            }
            catch (Exception ex)
            {
                result.Code = -1;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ResultTyped<IList<UserDto>>> GetAllActiveUsers()
        {
            var result = new ResultTyped<IList<UserDto>>();
            try
            {
                var url = $"{baseUrl}/users";
                var apiResponse = await _webRequest.HttpClientRequest(url, null, null, HttpMethod.Get);
                result.Entity = JsonConvert.DeserializeObject<IList<UserDto>>(apiResponse ?? "");
                result.Code = 1;
            }
            catch (Exception ex)
            {
                result.Code = -1;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ResultTyped<IList<UserDto>>> GetAllInActiveFemaleUsers()
        {
            var result = new ResultTyped<IList<UserDto>>();
            try
            {
                var url = $"{baseUrl}/users?status=inactive&gender=female";
                var apiResponse = await _webRequest.HttpClientRequest(url, null, null, HttpMethod.Get);
                result.Entity = JsonConvert.DeserializeObject<IList<UserDto>>(apiResponse ?? "");
                result.Code = 1;
            }
            catch (Exception ex)
            {
                result.Code = -1;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
