using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace NalaTest.Domain.Entity
{
    [Serializable]
    [DebuggerDisplay("Code: {" + nameof(Code) + "}, Entity: {" + nameof(Entity) + "}, Message: {" + nameof(Message) + "}")]
    public class ResultTyped<T>
    {
        public ResultTyped()
        {
        }

        public ResultTyped(T entity)
        {
            Entity = entity;
        }

        public ResultTyped(short code, string message)
        {
            Code = code;
            Message = message;
        }

        [JsonProperty("message")]
        public string Message { get; set; } = "Success";
        [JsonProperty("code")]
        public short Code { get; set; } = (short)HttpStatusCode.OK;
        [JsonProperty("entity")]
        public T? Entity { get; set; } = default;
    }

    [Serializable]
    public class ResultTyped : ResultTyped<byte>
    {
    }
}
