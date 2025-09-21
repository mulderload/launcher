
using Newtonsoft.Json;
using MulderLauncher.Models;

namespace MulderLauncher.Services
{
    public class ConfigProvider
    {
        private Config? Config;

        public Config GetConfig()
        {
            if (this.Config == null)
            {
                string configPath = Path.Combine(Application.StartupPath, "MulderLauncher.config.json");
                try
                {
                    this.Config = LoadConfig(configPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error: config failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    throw;
                }
            }

            return this.Config;
        }

        private static Config LoadConfig(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("The file 'MulderLauncher.config.json' does not exist.", path);

            try
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<Config>(json) 
                    ?? throw new InvalidDataException("The file 'MulderLauncher.config.json' is empty or invalid.");
            }
            catch (JsonException)
            {
                throw new Exception("The file 'MulderLauncher.config.json' is invalid");
            }
        }
    }
}
