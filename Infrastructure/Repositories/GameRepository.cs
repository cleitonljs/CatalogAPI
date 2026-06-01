using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GameRepository(FCGDbContext dbContext) : IGameRepository
    {


        public async Task<Game> AdicionarAsync(Game entidade)
        {
            var retorno = await dbContext.Games.AddAsync(entidade);

            return retorno.Entity;
        }

        public async Task Atualizar(Game User)
        {
            dbContext.Games.Update(User);
        }

        public async Task DeletarAsync(Game User)
        {
            dbContext.Games.Remove(User);
        }        

        public async Task<Game> ObterPorIdAsync(long id)
        {
            return await dbContext.Games.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Game>> ObterTodosAsync()
        {
            return await dbContext.Games.ToListAsync();
        }
    }
}
