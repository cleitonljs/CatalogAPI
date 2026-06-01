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
    public class LibraryRepository (FCGDbContext dbContext) : ILibraryRepository
    {
        public async Task<Library> AdicionarAsync(Library Library)
        {
            var retorno = await dbContext.Library.AddAsync(Library);

            return retorno.Entity;
        }

        public async Task DeletarAsync(Library Library)
        {
            dbContext.Library.Remove(Library);
        }

        public async Task<Library> ObterPorIdAsync(long id)
        {
            return await dbContext.Library.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Library>> ObterTodosAsync()
        {
            return await dbContext.Library.ToListAsync();
        }
    }
}
