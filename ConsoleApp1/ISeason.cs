using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    internal interface ISeason {
        public int Number { get; }
        public string Location { get; }
        public string Theme { get; }
        public string Title { get; }

        public int PlayersLeft { get; }
        public IReadOnlyList<IPlayer> AllPlayers { get; }
        public IReadOnlyList<IPlayer> StillIn { get; }
        public IReadOnlyList<IPlayer> VotedOut { get; }
        public IReadOnlyList<IPlayer> Jury { get; }
        public IReadOnlyList<IPlayer> Finalists { get; }
        public IPlayer? Winner { get; }
    }
}
