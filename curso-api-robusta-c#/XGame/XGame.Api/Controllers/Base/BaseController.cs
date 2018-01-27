using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Domain.Interfaces.Services;
using XGame.Infra.Transactions;

namespace XGame.Api.Controllers.Base
{
    public class BaseController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServiceBase _serviceBase;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HttpResponseMessage> ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;

            if (!serviceBase.Notifications.Any())
            {
                try
                {
                    _unitOfWork.Commit();

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema.");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = serviceBase.Notifications });
            }
        }

        public async Task<HttpResponseMessage> ResponseExceptionAsync(Exception ex)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            if(_serviceBase != null)
            {
                _serviceBase.Dispose();
            }
        }
    }
}