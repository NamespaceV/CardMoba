using System;
using System.Collections.Generic;

public interface ISelectedObject
{
    public string Name { get; }

    public List<IActionDescription> Actions { get; }
}

public interface IActionDescription
{
    string Name { get; }
    bool Enabled { get; }
    string Tooltip { get; }
    Action Execute { get; }
}

public class SimpleAction : IActionDescription
{
    public string Name { get; set; }

    public bool Enabled { get; set; }

    public string Tooltip { get; set; }

    public Action Execute { get; set; }
}