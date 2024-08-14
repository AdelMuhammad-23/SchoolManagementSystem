using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Bases
{
    public class ResponsesHandler
    {

        public ResponsesHandler()
        {

        }
        public Responses<T> Deleted<T>()
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }
        public Responses<T> Success<T>(T entity, object Meta = null)
        {
            return new Responses<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Added Successfully",
                Meta = Meta
            };
        }
        public Responses<T> Unauthorized<T>()
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "UnAuthorized"
            };
        }
        public Responses<T> BadRequest<T>(string Message = null)
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };

        }   public Responses<T> UnprocessableEntity<T>(string Message = null)
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }

        public Responses<T> NotFound<T>(string message = null)
        {
            return new Responses<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public Responses<T> Created<T>(T entity, object Meta = null)
        {
            return new Responses<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = Meta
            };
        }
    }

}
