using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public interface ISeason {
        public int Number { get; }
        public string Location { get; }
        public string Theme { get; }
        public string Title { get; }

        public int TribesLeft { get; }
        public IList<ITribe> Tribes { get; }

        public int PlayersLeft { get; }
        public IList<IPlayer> AllPlayers { get; }
        public IList<IPlayer> StillIn { get; }
        public IList<IPlayer> VotedOut { get; }
        public IList<IPlayer> Jury { get; }
        public IList<IPlayer> Finalists { get; }
        public IPlayer? Winner { get; }

        public void Update(string? input);
        public string? Display();
    }
}
