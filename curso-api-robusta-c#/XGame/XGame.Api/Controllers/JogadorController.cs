using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Api.Controllers.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Services;
using XGame.Infra.Transactions;

namespace XGame.Api.Controllers
{

    [RoutePrefix("api/jogador")]
    public class JogadorController : BaseController
    {
        private readonly IServiceJogador _service;

        public JogadorController(IServiceJogador service, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _service = service;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarJogadorRequest request)
        {
            try
            {
                var response = _service.AdicionarJogador(request);
                return await ResponseAsync(response, _service);
            }catch(Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
