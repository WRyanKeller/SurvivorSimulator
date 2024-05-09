using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    internal class Tribe : ITribe {
        private List<IPlayer> m_players = new List<IPlayer>();

        public string Name {
            get;
        }

        public int Size {
            get {
                return m_players.Count;
            }
        }

        public bool WillTribal {
            get;
            private set;
        }

        public IList<IPlayer> Players {
            get { 
                return m_players;
            }
        }

        public Tribe(string name, List<IPlayer> players) {
            Name = name;
            m_players = players;
        }

        public IPlayer GoToTribal() {
            WillTribal = false;

            IPlayer voteOut = StaticRng.RandomFromList(m_players);
            m_players.Remove(voteOut);
            return voteOut;
        }

        public void RemoveFromTribe(IPlayer player) {
            m_players.Remove(player);
        }

        public override string ToString() {
            return $"{Name}, with a population of {Size}";
        }
    }
}
