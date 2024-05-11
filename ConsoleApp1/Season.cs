using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public enum SeasonState {
        Intro,
        PreSwap,
        PostSwapOne,
        PostSwapTwo,
        PostSwapThree,
        PostSwapFour,
        PostMerge,
        Finalists,
        Winner
    }

    public enum GameState {
        Intro,
        Recap,
        PreChallenge,
        Challenge,
        PostChallenge,
        PreTribal,
        Tribal,
        PostTribal,
        FinalJury,
        Winner,
    }

    public class Season : ISeason {
        private static Dictionary<int, int> minLookup = new Dictionary<int, int> {
            {1, 14},
            {2, 7},
            {3, 6},
            {4, 4},
            {5, 4},
            {6, 3},
        };
        private static Dictionary<int, int> maxLookup = new Dictionary<int, int> {
            {1, 24},
            {2, 12},
            {3, 7},
            {4, 5},
            {5, 4},
            {6, 4},
        };

        private List<ITribe> m_tribes;

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


        public int TribesLeft { get { return m_tribes.Count; } }

        public IList<ITribe> Tribes { get { return m_tribes; } }


        public int PlayersLeft { get { return m_allPlayers.Count; } }
        public IList<IPlayer> AllPlayers { get { return m_allPlayers; } }
        public IList<IPlayer> StillIn { get { return m_stillIn; } }
        public IList<IPlayer> VotedOut { get { return m_votedOut; } }
        public IList<IPlayer> Jury { get { return m_jury; } }
        public IList<IPlayer> Finalists { get { return m_finalists; } }
        public IPlayer? Winner { get; private set; }

        public Season(int number,
                      string location,
                      string theme = "",
                      int numOfTribes = 0,
                      int numOfPlayers = 0) {

            if (numOfTribes <= 0 || numOfTribes > 6) {
                numOfTribes = StaticRng.GetRandomInt(3, 6);
            }
            if (numOfPlayers < 10 || numOfPlayers > 30 || numOfPlayers % numOfTribes != 0) {
                numOfPlayers = StaticRng.GetRandomInt(minLookup[numOfTribes], maxLookup[numOfTribes]+1) * numOfTribes;
            }

            Number = number;
            Location = location;
            Theme = theme;

            // create the players!
            m_allPlayers = new List<IPlayer>();
            for (int i = 0; i < numOfPlayers; i++) {
                m_allPlayers.Add(new Player($"Player #{i+1}"));
            }
            m_stillIn = new List<IPlayer>(m_allPlayers);
            m_votedOut = new List<IPlayer>();
            m_jury = new List<IPlayer>();
            m_finalists = new IPlayer[3];
            Winner = null;


            // split the players into tribes
            List<IPlayer>[] tribeRosters = StaticRng.SplitIntoLists(ref m_allPlayers, numOfTribes);
            m_tribes = new List<ITribe>();
            foreach (List<IPlayer> roster in tribeRosters) {
                m_tribes.Add(new Tribe("Tunk", roster));
            }
        }

        public void Update() {

        }
    }
}
