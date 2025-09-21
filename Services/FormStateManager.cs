﻿using MulderLauncher.Models;

namespace MulderLauncher.Services
{
    public class FormStateManager(ConfigProvider configProvider)
    {
        private string? Addon;
        public readonly Dictionary<string, Dictionary<string, RadioButton>> RadioButtons = [] ;
        public readonly Dictionary<string, CheckBox> CheckBoxes = [];

        internal void AddRadioButton(string groupName, RadioButton radioButton, string value)
        {
            if (!this.RadioButtons.ContainsKey(groupName))
                this.RadioButtons[groupName] = [];

            this.RadioButtons[groupName][value] = radioButton;
        }

        internal void AddCheckBox(CheckBox checkBox, string value)
        {
            this.CheckBoxes[value] = checkBox;
        }

        public void SetAddon(string? addon)
        {
            this.Addon = addon;
        }

        public string GetAddon()
        {
            return this.Addon ?? "default";
        }

        public void ResetChoices()
        {
            foreach (var grp in RadioButtons)
            {
                foreach (var rb in grp.Value.Values)
                {
                    rb.Enabled = true;
                    rb.Checked = false;
                }
            }

            foreach (var kv in CheckBoxes)
            {
                var cb = kv.Value;
                if (cb.Checked) {
                    cb.Checked = false;
                    cb.Enabled = true;
                }
            }
        }

        public Dictionary<string, object?> GetChoices()
        {
            var config = configProvider.GetConfig();
            var choices = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);

            foreach (var group in config.OptionGroups)
            {
                if (group.Type == "radioGroup" && RadioButtons.TryGetValue(group.Name, out var radios))
                {
                    var selectedRadio = radios.Values.FirstOrDefault(radio => radio.Checked);
                    if (selectedRadio != null)
                        choices[group.Name] = selectedRadio.Text;
                }

                else if (group.Type == "checkboxGroup" && group.Checkboxes != null)
                {
                    var selectedCheckboxes = group.Checkboxes
                        .Where(checkbox => CheckBoxes.TryGetValue(checkbox.Value, out var checkbox2) && checkbox2.Checked)
                        .Select(checkbox => checkbox.Value)
                        .ToList();

                    choices[group.Name] = selectedCheckboxes;
                }
            }

            return choices;
        }
    }
}
