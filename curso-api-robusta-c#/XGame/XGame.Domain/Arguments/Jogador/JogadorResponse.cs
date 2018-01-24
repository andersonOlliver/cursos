using System;

namespace XGame.Domain.Arguments.Jogador
{
    public class JogadorResponse
    {
        public Guid Id { get; private set; }

        public string NomeCompleto { get; private set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Email { get; private set; }
        
        public string Status { get; private set; }

        public static explicit operator JogadorResponse(Entities.Jogador jogador)
        {
            return new JogadorResponse()
            {
                Email = jogador.Email.Endereco,
                PrimeiroNome = jogador.Nome.PrimeiroNome,
                UltimoNome = jogador.Nome.UltimoNome,
                NomeCompleto = jogador.ToString(),
                Id = jogador.Id,
                Status = jogador.Status.ToString()
            };
        }
    }
}
