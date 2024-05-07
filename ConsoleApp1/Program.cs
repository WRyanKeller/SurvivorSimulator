namespace ConsoleApp1
{
    internal class Program {
        static ISeason m_season;

        static bool Initiate () {
            m_season = new Season(1, "Nevada");
            return true;
        }

        static void Main(string[] args) {
            if (!Initiate()) {
                return;
            }

            Console.WriteLine($"Welcome to {m_season.Title}!\n");
            Console.WriteLine("Our contestants are:");
            DisplayHelper.PrintNumberedList(m_season.AllPlayers);
        }
    }
}