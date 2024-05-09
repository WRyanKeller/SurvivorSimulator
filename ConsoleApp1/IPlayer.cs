using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IPlayer {
        public string Name { get; }
        public int ChallengeRating { get; }
        public int Likeability { get; }
    }
}
