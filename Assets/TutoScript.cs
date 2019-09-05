using System.Collections;
using GBJAM7.Types;
using TMPro;
using UnityEngine;
public class TutoScript : MonoBehaviour
{
    [SerializeField] private Phases phase;
    [SerializeField] private PlayerController controller;
    [SerializeField] private Character player;
    [SerializeField] private TMP_Text showedText;
    [SerializeField] private Dialog[] BeginningDialogs;
    [SerializeField] private Dialog[] BattleDialogs;
    [SerializeField] private Dialog[] BuildDialogs;
    [SerializeField] private Dialog[] AliesDialogs;
    [SerializeField] private Dialog[] EndDialogs;
    [SerializeField] private Enemy[] enemies;

    [SerializeField] private float typingSpeed = 0.02f;
    private bool canTypeAgain = true;
    private int currentDialogIndex = 0;
    private Dialog[] dialogs;
    private bool interacting;

    void Start()
    {
        dialogs = BeginningDialogs;
        StartCoroutine(type(dialogs[currentDialogIndex]));
        SpawnEnemies(EnemyType.Gigant);
    }

    private void LateUpdate()
    {
    }
    void Update()
    {


        bool isDiaglogDifferenceFromAction = dialogs[currentDialogIndex - 1 < 0 ? 0 : currentDialogIndex - 1].Dialogname != "Action";
        KeyCode action = dialogs[currentDialogIndex - 1 < 0 ? 0 : currentDialogIndex - 1].actionCode;



        switch (phase)
        {
            case Phases.Beginning:
                {

                    if (controller.Buttom_B || controller.Buttom_A)
                        if (isDiaglogDifferenceFromAction)
                            NextDialog();
                        else if (Input.GetKey(action))
                        {
                            NextDialog();
                            Debug.Log("Entro");
                        }
                    
                    break;
                }
        }


    }

    private void NextDialog()
    {
        StartCoroutine(type(dialogs[currentDialogIndex]));
    }

    private void OnMouseDown()
    {
    }
    IEnumerator type(Dialog message)
    {
        if (canTypeAgain)
        {
            showedText.text = "";
            foreach (char letter in message.message)
            {
                canTypeAgain = false;
                showedText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            NextDialogIndex();
            canTypeAgain = true;
        }
    }

    public void NextDialogIndex()
    {
        if (currentDialogIndex < dialogs.Length - 1)
            currentDialogIndex++;
        else
        {
            if (Phases.End != phase)
            {
                dialogs = null;
                currentDialogIndex = 0;
                phase = phase + 1;
                Debug.Log(phase);
            }
            else
                Invoke("ChangeScene", 5f);
        }
    }

    private void ChangeScene()
    {
        SceneScript.ChangeScene("Main");

    }

    private void SpawnEnemies(EnemyType type)
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Type == type)
                Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

}

