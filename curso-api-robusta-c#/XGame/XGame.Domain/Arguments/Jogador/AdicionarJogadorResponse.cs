using System;
using XGame.Domain.Interfaces.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator AdicionarJogadorResponse(Entities.Jogador jogador)
        {
            return new AdicionarJogadorResponse()
            {
                Id = jogador.Id,
                Message = Properties.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
