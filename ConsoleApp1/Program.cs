namespace ConsoleApp1
{
    public enum MenuState {
        Title,
        NewSeason,
        MidSeason,
        PostSeason,
    }

    public class Program {
        private static bool m_initiated;

        public static ISeason Season {
            get;
            private set;
        }

        public static MenuState State {
            get;
            private set;
        }

        static Program() {
            m_initiated = false;

            Season = new Season(1, "Nevada");
            State = MenuState.Title;

            m_initiated = true;
        }

        static void Main(string[] args) {
            if (!m_initiated) {
                return;
            }

            Console.WriteLine($"Welcome to {Season.Title}!");
            Console.WriteLine("\nOur contestants are:");
            DisplayHelper.PrintNumberedList(Season.AllPlayers);
            Console.WriteLine("\nOur tribes are:");
            DisplayHelper.PrintTribes(Season.Tribes);

            bool quit = false;
            while (!quit) {
                switch (State) {
                    case MenuState.Title:
                        break;

                    // shouldn't happen?
                    default:
                        throw new NotImplementedException("default game state");
                }
            }
        }
    }
}