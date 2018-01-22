using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Enum;
using XGame.Domain.Properties;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", 6, 32));
        }

        public Guid Id { get; set; }

        public Nome Nome { get; set; }

        public Email Email { get; set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; set; }
    }
}
