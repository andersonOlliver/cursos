using System;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador, Guid>, IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context)
            : base(context)
        {
            _context = context;
        }
        
    }
}
