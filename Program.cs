namespace MulderLauncher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(ParseSteamAddonId()));
        }

        private static int? ParseSteamAddonId()
        {
            string[] args = Environment.GetCommandLineArgs().Skip(1).ToArray();

            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i].Equals("-addon", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(args[i + 1], out int id))
                    {
                        return id;
                    }
                }
            }
            return null;
        }
    }
}