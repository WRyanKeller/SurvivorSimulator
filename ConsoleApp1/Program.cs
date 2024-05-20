using System.Diagnostics;

namespace ConsoleApp1
{
    public enum MenuState {
        Title,
        SeasonSetup,
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
                    State = MenuState.SeasonSetup;
                    break;

                case MenuState.SeasonSetup:
                    if (m_input == null) { return; }
                    State = MenuState.MidSeason;
                    break;

                case MenuState.MidSeason:
                    Season!.Update(m_input);
                    if (Season.Winner != null) {
                        State = MenuState.PostSeason;
                    }
                    break;

                case MenuState.PostSeason:
                    if (m_input == null) { return; }
                    Season = null;
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

                case MenuState.SeasonSetup:
                    result = Console.ReadLine();
                    break;

                case MenuState.MidSeason:
                    result = Season!.Display();
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