namespace MulderLauncher.Models
{
    public class Save
    {
        public Dictionary<string, Dictionary<string, object>> AddonSelections { get; set; }
            = new Dictionary<string, Dictionary<string, object>>(StringComparer.OrdinalIgnoreCase);
    }
}
