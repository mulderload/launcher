using MulderLauncher.Models;

namespace MulderLauncher.Services
{
    public class FormValidator(ConfigProvider configProvider, FormStateManager formStateManager)
    {
        public bool IsValid()
        {
            var config = configProvider.GetConfig();

            if (config.OptionGroups == null)
                return false;

            foreach (var group in config.OptionGroups)
            {
                if (group.Type != "radioGroup")
                    continue;

                if (!formStateManager.RadioButtons.TryGetValue(group.Name, out var radios))
                    continue;

                if (!radios.Values.Any(rb => rb.Enabled && rb.Checked))
                    return false;
            }

            return true;
        }

        public void ApplyWhenConstraints()
        {
            var config = configProvider.GetConfig();
            var selected = formStateManager.GetChoices();
            selected["Addon"] = formStateManager.GetAddon();

            foreach (var group in config.OptionGroups)
            {
                if (group.Type == "radioGroup" && formStateManager.RadioButtons.TryGetValue(group.Name, out var radios))
                {
                    foreach (var radioRow in group.Radios)
                    {
                        if (radioRow.DisabledWhen == null)
                            continue;

                        if (radios.TryGetValue(radioRow.Value, out var radioButton))
                        {
                            bool disable = WhenResolver.Match(radioRow.DisabledWhen, selected);
                            radioButton.Enabled = !disable;
                            radioButton.Checked = !disable && radioButton.Checked;
                        }
                    }
                }

                else if (group.Type == "checkboxGroup" && group.Checkboxes != null)
                {
                    foreach (var checkboxRow in group.Checkboxes)
                    {
                        if (checkboxRow.DisabledWhen == null)
                            continue;

                        if (formStateManager.CheckBoxes.TryGetValue(checkboxRow.Value, out var checkBox) )
                        {
                            bool disable = WhenResolver.Match(checkboxRow.DisabledWhen, selected);
                            checkBox.Enabled = !disable;
                            checkBox.Checked = !disable && checkBox.Checked;
                        }
                    }
                }
            }

        }
    }
}
