using System;
using System.Linq;
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
            
            PlayersRepository.Add(player);
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
            
            PlayersRepository.Remove(id);
            PlayersRepository.Add(player);
            return new CreatedPlayerDTO(player.Id);
        }

        public Guid? Remove(Guid id)
        {
            return PlayersRepository.Remove(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return PlayersRepository.Players as IEnumerable<Player>;
        }
    }
}
