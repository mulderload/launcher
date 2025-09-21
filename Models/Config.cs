﻿namespace MulderLauncher.Models
{
    public class Config
    {
        public required Game Game { get; set; }
        public List<Addon>? Addons { get; set; }
        public required List<OptionGroup> OptionGroups { get; set; }
        public required ActionRoot Actions { get; set; }
    }

    public class Game
    {
        public required string Title { get; set; }
        public required string OriginalExe { get; set; }
    }

    public class Addon
    {
        public required string Title { get; set; }
        public int? SteamId { get; set; }
    }

    public class OptionGroup
    {
        public required string Name { get; set; }
        public required string Type { get; set; } // "radioGroup" | "checkboxGroup"
        public List<Radio>? Radios { get; set; }
        public List<Checkbox>? Checkboxes { get; set; }
    }

    public class Radio
    {
        public required string Value { get; set; }
        public List<WhenGroup>? DisabledWhen { get; set; }
    }

    public class Checkbox
    {
        public required string Value { get; set; }
        public List<WhenGroup>? DisabledWhen { get; set; }
    }

    public class WhenGroup : Dictionary<string, string>
    {
    }

    public class ActionRoot
    {
        public required List<ExecAction> Exe { get; set; }
        public List<ArgsAction>? Args { get; set; }
    }

    public class ExecAction
    {
        public required List<WhenGroup> When { get; set; }
        public required List<string> Result { get; set; }
    }

    public class ArgsAction
    {
        public required List<WhenGroup> When { get; set; }
        public required string Result { get; set; }
    }
}
