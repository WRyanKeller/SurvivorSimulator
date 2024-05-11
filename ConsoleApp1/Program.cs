using System.Diagnostics;

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
        private static bool m_quit;
        private static string? m_input;

        public static ISeason? Season {
            get;
            private set;
        }

        public static MenuState State {
            get;
            private set;
        }

        static Program() {
            m_initiated = false;

            State = MenuState.Title;

            m_initiated = true;
        }

        static void Main(string[] args) {
            if (!m_initiated) {
                return;
            }

            m_quit = false;
            Stopwatch sw = Stopwatch.StartNew();
            while (!m_quit) {
                if (sw.ElapsedMilliseconds < 17) {
                    continue;
                }
                sw.Restart();
                Update();
                m_input = Display();
                m_quit = m_input?.ToLower() == "quit";
            }
        }

        private static void Update() {
            switch (State) {
                case MenuState.Title:
                    if (m_input == null) { return; }
                    Season = new Season(1, "Nevada");
                    State = MenuState.NewSeason;
                    break;

                case MenuState.NewSeason:
                    if (m_input == null) { return; }
                    State = MenuState.MidSeason;
                    break;

                case MenuState.MidSeason:
                    Season!.Update();
                    break;

                case MenuState.PostSeason:
                    break;

                // shouldn't happen?
                default:
                    throw new NotImplementedException("default game state");
            }
        }

        private static string? Display() {
            string? result = null;
            switch (State) {
                case MenuState.Title:
                    Console.WriteLine("Press [Enter] to continue");
                    result = Console.ReadLine();
                    break;

                case MenuState.NewSeason:
                    Console.WriteLine($"Welcome to {Season!.Title}!");
                    Console.WriteLine("\nOur contestants are:");
                    DisplayHelper.PrintNumberedList(Season.AllPlayers);
                    Console.WriteLine("\nOur tribes are:");
                    DisplayHelper.PrintTribes(Season.Tribes);
                    Console.WriteLine("Press [Enter] to continue");
                    result = Console.ReadLine();
                    break;

                case MenuState.MidSeason:
                    break;

                case MenuState.PostSeason:
                    break;

                // shouldn't happen?
                default:
                    throw new NotImplementedException("default game state");
            }
            return result;
        }
    }
}