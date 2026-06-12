using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GameService(IUnitOfWork unitOfWork, IMapper mapper) : IGameService 
    {
        public async Task<Game> CriarGameAsync(GameRequest User)
        {
            var Game = mapper.Map<Game>(User);

            var createdGame = await unitOfWork.Games.AdicionarAsync(Game);

            await unitOfWork.SaveChangesAsync();

            return createdGame;
        }

        public async Task AtualizarAsync(GameUpdateRequest GameUpdateRequest)
        {
            var Game = await unitOfWork.Games.ObterPorIdAsync(GameUpdateRequest.Id) ?? throw new DirectoryNotFoundException(GameUpdateRequest.Id.ToString());

            Game.Nome = GameUpdateRequest.Nome;
            Game.Price = GameUpdateRequest.Price;

            await unitOfWork.Games.Atualizar(Game);
            await unitOfWork.SaveChangesAsync();
        }        

        public async Task DeletarAsync(int id)
        {
            var User = await unitOfWork.Games.ObterPorIdAsync(id) ?? throw new DirectoryNotFoundException(id.ToString());

            await unitOfWork.Games.DeletarAsync(User);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Game> ObterPorIdAsync(int id)
        {
            return await unitOfWork.Games.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Game>> ObterTodosAsync()
        {
            return await unitOfWork.Games.ObterTodosAsync();
        }
    }
}
