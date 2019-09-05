

using UnityEngine;

[System.Serializable]
public class Dialog
{
    public string Dialogname;
    [TextArea] public string message;

    public Dialog()
    {
    }public Dialog(string message)
    {
        this.message = message;
    }
    public KeyCode actionCode;
}
