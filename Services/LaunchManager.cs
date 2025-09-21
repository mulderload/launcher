using System.Diagnostics;

namespace MulderLauncher.Services
{
    public class LaunchManager(ConfigProvider configProvider, FormStateManager formStateManager)
    {
        public void Launch()
        {
            var (exePath, workDir) = GetExecParams();
            var args = GetArgs();

            if (!File.Exists(exePath))
            {
                throw new FileNotFoundException("Can't find executable.", exePath);
            }

            Process process = new()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    WorkingDirectory = workDir,
                    Arguments = args,
                    UseShellExecute = false
                }
            };
            process.Start();
        }

        private (string exePath, string workDir) GetExecParams()
        {
            var config = configProvider.GetConfig();
            var selected = formStateManager.GetChoices();
            selected["Addon"] = formStateManager.GetAddon();

            foreach (var action in config.Actions.Exe)
            {
                if (WhenResolver.Match(action.When, selected))
                {
                    // result = [exePath, workDir]
                    return (action.Result[0], action.Result[1]);
                }
            }

            throw new InvalidOperationException("Aucun exécutable valide trouvé.");
        }

        private string GetArgs()
        {
            var config = configProvider.GetConfig();
            var selected = formStateManager.GetChoices();
            selected["Addon"] = formStateManager.GetAddon();
            var args = new List<string>();

            foreach (var action in config.Actions.Args)
            {
                if (WhenResolver.Match(action.When, selected))
                {
                    args.Add(action.Result);
                }
            }

            return string.Join(" ", args);
        }
    }
}
