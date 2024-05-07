using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Player : IPlayer {
        public string Name {
            get;
        }

        public int ChallengeRating {
            get;
        }

        public int Likeability {
            get;
        }

        public Player(string name) : this(name,
                                          StaticRng.GetRandomInt(10),
                                          StaticRng.GetRandomInt(10)) { }

        public Player(string name, int chal, int like) {
            Name = name;
            ChallengeRating = chal;
            Likeability = like;
        }

        public override string ToString() {
            return $"{Name}:\tChal - {ChallengeRating}\tLike - {Likeability}";
        }
    }
}
