
using UnityEngine;
using GBJAM7.Types;
[System.Serializable]
public class Dialog
{
    public string dialogName;
    [TextArea] public string message;
    public string actionCode;
    public EnemyType type;
    public int quest;

    public Dialog()
    {
    }
    public Dialog(string message)
    {
        this.message = message;
    }
}
