using System;
using System.Collections.Generic;

namespace Domain.Players
{
    public class PlayersService
    {
        public CreatedPlayerDTO Create(string name)
        {
            var player = new Player(name);
            var playerVal = player.Validate();

            if (!playerVal.isValid)
            {
                return new CreatedPlayerDTO(playerVal.errors);
            }
            
            var playersRepository = new PlayersRepository();
            playersRepository.Add(player);
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
            
            var playersRepository = new PlayersRepository();
            playersRepository.Remove(id);
            playersRepository.Add(player);
            return new CreatedPlayerDTO(player.Id);
        }

        public Guid? Remove(Guid id)
        {
            var playersRepository = new PlayersRepository();return 
            playersRepository.Remove(id);
        }

        public Player GetByID(Guid id)
        {
            var playersRepository = new PlayersRepository();return 
            playersRepository.GetByID(id);
        }

        public IEnumerable<Player> GetAll()
        {
            var playersRepository = new PlayersRepository();return 
            playersRepository.GetAll();
        }
    }
}
