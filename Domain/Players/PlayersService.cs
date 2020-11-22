using System;
using System.Collections.Generic;

namespace Domain.Players
{
    public class PlayersService
    {
        private readonly PlayersRepository _playersRepository = new PlayersRepository();
        
        public CreatedPlayerDTO Create(string name)
        {
            var player = new Player(name);
            var playerVal = player.Validate();

            if (!playerVal.isValid)
            {
                return new CreatedPlayerDTO(playerVal.errors);
            }
            
            _playersRepository.Add(player);
            return new CreatedPlayerDTO(player.Id);
        }

        public CreatedPlayerDTO Update(Guid id, string name)
        {
            var player = new Player(name);
            var playerValidation = player.Validate();

            if (!playerValidation.isValid)
            {
                return new CreatedPlayerDTO(playerValidation.errors);
            }
            
            _playersRepository.Remove(id);
            _playersRepository.Add(player);
            return new CreatedPlayerDTO(player.Id);
        }

        public Guid? Remove(Guid id)
        {
            return _playersRepository.Remove(id);
        }

        public Player GetByID(Guid id)
        {
            return _playersRepository.GetByID(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return _playersRepository.GetAll();
        }
    }
}
