using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context)
        {
            _context = context;
        }

        public Jogador AdicionarJogador(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);
            _context.SaveChanges();

            return jogador;
        }

        public Jogador AlterarJogador(Jogador jogador)
        {


            return jogador;
        }

        public Jogador AutenticarJogador(string email, string senha)
        {
            return _context.Jogadores
                .Where(j => j.Email.Endereco == email && j.Senha == senha)
                .FirstOrDefault();
        }

        public IEnumerable<Jogador> ListarJogador()
        {
            return _context.Jogadores.ToList();
        }

        public Jogador ObterJogadorPorId(Guid id)
        {
            return _context.Jogadores.Find(id);
        }
    }
}
