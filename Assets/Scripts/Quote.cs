using UnityEngine;
using System.Collections;

public class Quote  {

    public string Text { get; set; }
    public Color TextColor { get; set; }

    public Quote(string text, Color color)
    {
        Text = text;
        TextColor = color;
    }
}
