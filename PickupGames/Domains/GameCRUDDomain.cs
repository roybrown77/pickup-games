using System;
using System.Collections.Generic;
using Ninject;
using PickupGames.Domain.Objects;
using PickupGames.Repositories.Interfaces;
using PickupGames.Utilities.DependencyInjector;

namespace PickupGames.Domains
{
    public class GameCrudDomain
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGeographyRepository _geographyRepository;

        public GameCrudDomain()
        {
            _gameRepository = NinjectDependencyInjector.Dependencies.Get<IGameRepository>();
            _geographyRepository = NinjectDependencyInjector.Dependencies.Get<IGeographyRepository>();
        }

        public BasicResponse CreateGame(Game game)
        {
            try
            {
                var coordinates = _geographyRepository.GetCoordinates(game.Location.Address);
                game.Location = new Location { Lat = coordinates.Lat, Lng = coordinates.Lng };

                _gameRepository.Add(game);

                return new BasicResponse();
            }
            catch (Exception ex)
            {
                return new BasicResponse
                {
                    Status = ResponseStatus.Failed,
                    Message = ex.Message
                };
            }
        }

        public BasicResponse EditGame(Guid id, Game game)
        {
            try
            {
                _gameRepository.Edit(id, game);

                return new BasicResponse();
            }
            catch (Exception ex)
            {
                return new BasicResponse
                {
                    Status = ResponseStatus.Failed,
                    Message = ex.Message
                };
            }
        }

        public BasicResponse DeleteGame(Guid id)
        {
            try
            {
                _gameRepository.Delete(id);

                return new BasicResponse();
            }
            catch (Exception ex)
            {
                return new BasicResponse
                {
                    Status = ResponseStatus.Failed,
                    Message = ex.Message
                };
            }
        }
    }
}