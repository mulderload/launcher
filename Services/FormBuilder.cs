﻿using MulderLauncher.Models;

namespace MulderLauncher.Services
{
    public class FormBuilder(FormValidator formValidator, FormStateManager formStateManager)
    {
        public void BuildAddons(Config config, ComboBox comboBox)
        {
            comboBox.Items.Clear();

            foreach (var addon in config.Addons)
            {
                comboBox.Items.Add(addon.Title);
            }

            comboBox.SelectedIndex = 0;
            formStateManager.SetAddon(comboBox.SelectedItem?.ToString());
        }

        public void BuildForm(Config config, Panel panelOptions, Action UpdateButtons)
        {
            panelOptions.Controls.Clear();

            int y = 10;

            foreach (var group in config.OptionGroups)
            {
                // Crée un groupBox pour le groupe d'options
                var groupBox = new GroupBox
                {
                    Text = group.Name,
                    Left = 10,
                    Top = y,
                    Width = panelOptions.ClientSize.Width - 40,
                    Height = 10,
                    AutoSize = true,
                    ForeColor = Color.White,
                };

                panelOptions.Controls.Add(groupBox);

                int innerY = 20;

                if (group.Type == "radioGroup" && group.Radios != null)
                {
                    foreach (var radioChoice in group.Radios)
                    {
                        var radioButton = new RadioButton
                        {
                            Text = radioChoice.Value,
                            Left = 10,
                            Top = innerY,
                            AutoSize = true
                        };

                        radioButton.CheckedChanged += (s, e) =>
                        {
                            formValidator.ApplyWhenConstraints();
                            UpdateButtons();
                        };
                        groupBox.Controls.Add(radioButton);
                        formStateManager.AddRadioButton(group.Name, radioButton, radioChoice.Value);
                        innerY += 25;
                    }
                }
                else if (group.Type == "checkboxGroup" && group.Checkboxes != null)
                {
                    foreach (var checkItem in group.Checkboxes)
                    {
                        var checkBox = new CheckBox
                        {
                            Text = checkItem.Value,
                            Left = 10,
                            Top = innerY,
                            AutoSize = true,
                            Tag = checkItem.Value
                        };

                        checkBox.CheckedChanged += (s, e) =>
                        {
                            formValidator.ApplyWhenConstraints();
                            UpdateButtons();
                        };
                        groupBox.Controls.Add(checkBox);
                        formStateManager.AddCheckBox(checkBox, checkItem.Value);
                        innerY += 25;
                    }
                }

                groupBox.Height = innerY + 10;
                y += groupBox.Height + 8;
            }
        }

    }
}
