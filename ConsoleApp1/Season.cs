using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    internal class Season : ISeason {
        private List<IPlayer> m_allPlayers;
        private List<IPlayer> m_stillIn;
        private List<IPlayer> m_votedOut;
        private List<IPlayer> m_jury;
        private IPlayer[] m_finalists;

        public int Number { get; private set; }
        public string Location { get; private set; }
        public string Theme { get; private set; }
        public string Title {
            get { return $"Survivor {Number}: {(Theme.Length > 0 ? Theme : Location)}"; }
        }

        public int PlayersLeft { get { return m_allPlayers.Count; } }

        public IReadOnlyList<IPlayer> AllPlayers { get { return m_allPlayers; } }

        public IReadOnlyList<IPlayer> StillIn { get { return m_stillIn; } }

        public IReadOnlyList<IPlayer> VotedOut { get { return m_votedOut; } }

        public IReadOnlyList<IPlayer> Jury { get { return m_jury; } }

        public IReadOnlyList<IPlayer> Finalists { get { return m_finalists; } }

        public IPlayer? Winner { get; private set; }

        public Season(int number, string location, string theme = "") {
            Number = number;
            Location = location;
            Theme = theme;

            m_allPlayers = new List<IPlayer>();
            for (int i = 1; i < 21; i++) {
                m_allPlayers.Add(new Player($"Player #{i}"));
            }
            m_stillIn = new List<IPlayer>(m_allPlayers);
            m_votedOut = new List<IPlayer>();
            m_jury = new List<IPlayer>();
            m_finalists = new IPlayer[3];
            Winner = null;
        }
    }
}
