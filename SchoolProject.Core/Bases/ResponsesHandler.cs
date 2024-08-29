using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Bases
{
    public class ResponsesHandler
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public ResponsesHandler(IStringLocalizer<SharedResources> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public Responses<T> Deleted<T>(string Message = null)
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = true,
                Message = Message == null ? _stringLocalizer[SharedResourcesKeys.Deleted] : Message
            };
        }
        public Responses<T> Success<T>(T entity, object Meta = null)
        {
            return new Responses<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,

                Message = _stringLocalizer[SharedResourcesKeys.Success],
                Meta = Meta
            };
        }
        public Responses<T> Unauthorized<T>(string Message = null)
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKeys.UnAuthorized]
            };
        }
        public Responses<T> BadRequest<T>(string Message = null)
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? _stringLocalizer[SharedResourcesKeys.BadRequest] : Message
            };

        }
        public Responses<T> UnprocessableEntity<T>(string Message = null)
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message == null ? _stringLocalizer[SharedResourcesKeys.UnprocessableEntity] : Message
            };
        }

        public Responses<T> NotFound<T>(string message = null)
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? _stringLocalizer[SharedResourcesKeys.NotFound] : message
            };
        }

        public Responses<T> Created<T>(T entity, object Meta = null)
        {
            return new Responses<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = _stringLocalizer[SharedResourcesKeys.Created],
                Meta = Meta
            };
        }
    }

}
