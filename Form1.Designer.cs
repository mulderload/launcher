﻿namespace MulderLauncher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxAddon = new ComboBox();
            panelOptions = new Panel();
            btnLaunch = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // comboBoxAddon
            // 
            comboBoxAddon.BackColor = Color.FromArgb(89, 101, 119);
            comboBoxAddon.Font = new Font("Segoe UI", 9F);
            comboBoxAddon.ForeColor = SystemColors.HighlightText;
            comboBoxAddon.FormattingEnabled = true;
            comboBoxAddon.Location = new Point(12, 12);
            comboBoxAddon.Name = "comboBoxAddon";
            comboBoxAddon.Size = new Size(438, 23);
            comboBoxAddon.TabIndex = 0;
            comboBoxAddon.SelectedIndexChanged += comboBoxAddon_SelectedIndexChanged;
            // 
            // panelOptions
            // 
            panelOptions.AutoSize = true;
            panelOptions.BorderStyle = BorderStyle.FixedSingle;
            panelOptions.ForeColor = SystemColors.Control;
            panelOptions.Location = new Point(12, 53);
            panelOptions.Name = "panelOptions";
            panelOptions.Padding = new Padding(20);
            panelOptions.Size = new Size(600, 60);
            panelOptions.TabIndex = 1;
            // 
            // btnLaunch
            // 
            btnLaunch.Location = new Point(537, 12);
            btnLaunch.Name = "btnLaunch";
            btnLaunch.Size = new Size(75, 23);
            btnLaunch.TabIndex = 2;
            btnLaunch.Text = "Launch";
            btnLaunch.UseVisualStyleBackColor = true;
            btnLaunch.Click += btnLaunch_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(456, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(35, 35, 45);
            ClientSize = new Size(624, 341);
            Controls.Add(btnSave);
            Controls.Add(btnLaunch);
            Controls.Add(panelOptions);
            Controls.Add(comboBoxAddon);
            Name = "Form1";
            Padding = new Padding(0, 0, 0, 20);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxAddon;
        private Panel panelOptions;
        private Button btnLaunch;
        private Button btnSave;
    }
}
