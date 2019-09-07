
using UnityEngine;
[System.Serializable]
public class Dialog
{
    public string dialogName;
    [TextArea] public string message;
    public KeyCode actionCode;
    public int quest;

    public Dialog()
    {
    }
    public Dialog(string message)
    {
        this.message = message;
    }


}
