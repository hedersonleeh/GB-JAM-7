using System;
using System.Collections;
using GBJAM7.Types;
using TMPro;
using UnityEngine;
public class TutoScript : MonoBehaviour
{
    [SerializeField] private Phases phase;
    [SerializeField] private PlayerController controller;
    [SerializeField] private Character player;
    [SerializeField] private Builder builder;

    [SerializeField] private TMP_Text showedText;
    [SerializeField] private Dialog[] BeginningDialogs;
    [SerializeField] private Dialog[] BattleDialogs;
    [SerializeField] private Dialog[] BuildDialogs;
    [SerializeField] private Dialog[] EndDialogs;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Buildings building;
    [SerializeField] private Transform SpawnAliesPos;
    [SerializeField] private Character character;

    [SerializeField] private float typingSpeed = 0.02f;
    private bool canTypeAgain = true;
    private int currentDialogIndex = 0;
    private Dialog[] dialogs;
    private bool interacting;
    private bool quest;
    private bool canQuest = true;
    private bool typing;

    void Start()
    {
        DisablePlayer();
        dialogs = BeginningDialogs;
        ShowDialog();
        //  StartCoroutine(Type(dialogs[currentDialogIndex]));
    }

    private void DisablePlayer()
    {
        controller.Rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        builder.enabled = false;
    }

    private void LateUpdate()
    {
        ShowDialog();
    }
    void Update()
    {
        switch (phase)
        {
            case Phases.Beginning:
                {
                    quest = true;
                    DialogActions();
                    break;
                }

            case Phases.Battle:
                {
                    DialogActions();
                    break;
                }
            case Phases.Build:
                {
                    DialogActions();
                    break;
                }
                 case Phases.End:
                {
                    DialogActions();
                    break;
                }
        }
    }

    private void DialogActions()
    {
        if (!typing)
            switch (GetDialogName())
            {
                case "":
                    Debug.Log("Nothing");
                    if (controller.Buttom_B || controller.Buttom_A)
                    {
                        Debug.Log("Pass");
                        NextDialog();
                    }
                    break;
                case "Action":
                    if (Input.GetButtonDown(GetActionCode()))
                    {
                        NextDialog();
                    }
                    break;
                case "Quest":
                    Debug.Log("In Quest");
                    if (quest)
                    {
                        NextDialog();
                        canQuest = true;
                    }
                    else
                    {
                        InitQuest(dialogs[currentDialogIndex].type,dialogs[currentDialogIndex].quest);
                    }
                    break;
                case "ActivateMove":
                    if (Input.GetButtonDown(GetActionCode()))
                    {
                        NextDialog();
                        controller.Rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                    break;
                case "ActivateSelect":
                    builder.enabled = true;
                    if (Input.GetButtonDown(GetActionCode()))
                    {
                        NextDialog();
                    }
                    break;
                case "Build":
                    Debug.Log(builder.currentNameOfObject);

                    if (builder.currentNameOfObject == "Tower" && controller.Buttom_A && player.Interacting)
                    {
                        Instantiate(building, new Vector2(SpawnAliesPos.position.x, building.transform.position.y), Quaternion.identity);
                        NextDialog();
                    }
                    break;
                case "Alies":
                    Debug.Log(builder.currentNameOfObject);
                    if (builder.currentNameOfObject == "Warrior" && controller.Buttom_A && player.Interacting)
                    {
                        Instantiate(character, new Vector2(SpawnAliesPos.position.x, building.transform.position.y), Quaternion.identity);
                        NextDialog();
                    }
                    break;


            }
    }

    private void NextDialog()
    {
        NextDialogIndex();
    }

    private void InitQuest(EnemyType type,int amount)
    {
        if (canQuest)
        {
            canQuest = false;
            SpawnEnemies(type, amount);
        }
        else if (Enemy.ctr <= 0)
        {
            quest = true;
            return;
        }
    }

    private string GetDialogName()
    {
        return dialogs[currentDialogIndex].dialogName;
    }

    private string GetActionCode()
    {
        Debug.Log( dialogs[currentDialogIndex].actionCode);
        return dialogs[currentDialogIndex].actionCode;
    }

    private void ShowDialog()
    {
        StartCoroutine(Type(dialogs[currentDialogIndex]));
    }


    IEnumerator Type(Dialog message)
    {
        if (canTypeAgain)
        {
            showedText.text = "";
            foreach (char letter in message.message)
            {
                canTypeAgain = false;
                showedText.text += letter;
                typing = true;
                yield return new WaitForSeconds(typingSpeed);
            }
            typing = false;
        }
    }

    public void NextDialogIndex()
    {
        canTypeAgain = true;
        if (currentDialogIndex < dialogs.Length - 1 && !typing)
        {
            currentDialogIndex++;
        }
        else
        {
            if (quest)
            {
                currentDialogIndex = 0;
                phase = phase + 1;
                SetDialogs();
                quest = false;
                Debug.Log(phase);
            }
            else if (Phases.End == phase)
                Invoke("ChangeScene", 5f);
        }
    }

    private void SetDialogs()
    {
        switch (phase)
        {
            case Phases.Battle:
                dialogs = BattleDialogs;
                break;
            case Phases.Build:
                dialogs = BuildDialogs;
                break;
            case Phases.End:
                dialogs = EndDialogs;
                break;
        }
    }

    private void ChangeScene()
    {
        SceneScript.ChangeScene("Main");
    }

    private void SpawnEnemies(EnemyType Type)
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Type == Type)
                Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
    private void SpawnEnemies(EnemyType Type, int amount)
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Type == Type)
                for (int i = 0; i < amount; i++)
                {
                    Debug.Log(i + "I");
                    Instantiate(enemy, transform.position, Quaternion.identity);
                }
        }
    }

}

