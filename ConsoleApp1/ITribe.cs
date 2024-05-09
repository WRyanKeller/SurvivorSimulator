using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public interface ITribe {
        string Name { get; }
        int Size { get; }
        bool WillTribal { get; }

        IList<IPlayer> Players { get; }

        IPlayer GoToTribal();
        void RemoveFromTribe(IPlayer player);
    }
}
