using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public static int money = 0;
    public static bool canSpend;
    public static bool SpendMoney(int amount)
    {
        if (amount > money)
        {
            return false;
        }
        else
        {
            money -= amount;
            return true;
        }
    }
    public static void GiveMoney(int amount)
    {
        money += amount;
    }
    private void Update()
    {
        if (money <= 0)
        {
            money = 0;
            canSpend = false;
        }
        else
        {
            canSpend = true;
        }
    }
}
