using System;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {

        public Guid Id { get; private set; }

        public string NomeCompleto { get; private set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Email { get; private set; }

        public string Message { get; set; }

        public static explicit operator AlterarJogadorResponse(Entities.Jogador jogador)
        {
            return new AlterarJogadorResponse()
            {
                Id = jogador.Id,
                Email = jogador.Email.Endereco,
                PrimeiroNome = jogador.Nome.PrimeiroNome,
                UltimoNome = jogador.Nome.UltimoNome,
                NomeCompleto = jogador.ToString(),
                Message = Properties.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
