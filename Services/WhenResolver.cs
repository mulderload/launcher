using MulderLauncher.Models;

namespace MulderLauncher.Services
{
    public static class WhenResolver
    {
        public static bool Match(List<WhenGroup> groups, Dictionary<string, object> selected)
        {
            if (groups == null || groups.Count == 0)
                return false;

            foreach (var group in groups)
            {
                bool groupValid = true;

                foreach (var kvp in group)
                {
                    string key = kvp.Key;
                    string expected = kvp.Value; // can be "" for "nothing selectioned"

                    selected.TryGetValue(key, out var selectedValue); // null if missing

                    // SPECIAL CASE - expected is ""
                    if (string.IsNullOrEmpty(expected))
                    {
                        if (selectedValue == null)
                            continue;

                        // If it's a checkboxGroup and the list is empty => condition is valid
                        if (selectedValue is List<string> list0)
                        {
                            if (list0.Count == 0)
                                continue;

                            // condition is invalid
                            groupValid = false;
                            break;
                        }
                    }

                    // NORMAL CASE : expected not empty
                    if (selectedValue == null)
                    {
                        groupValid = false;
                        break;
                    }

                    // If checkboxGroup (list)
                    if (selectedValue is List<string> list)
                    {
                        if (!list.Contains(expected, StringComparer.OrdinalIgnoreCase))
                        {
                            groupValid = false;
                            break;
                        }
                    }
                    else // radio
                    {
                        if (!string.Equals(selectedValue?.ToString(), expected, StringComparison.OrdinalIgnoreCase))
                        {
                            groupValid = false;
                            break;
                        }
                    }
                }

                // A group matchs
                if (groupValid)
                    return true;
            }

            // No group match
            return false;
        }
    }
}
