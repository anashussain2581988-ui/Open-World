using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int money = 5000;

    public bool CanAfford(int amount)
    {
        return money >= amount;
    }

    public bool SpendMoney(int amount)
    {
        if (amount <= 0)
            return false;

        if (!CanAfford(amount))
            return false;

        money -= amount;
        return true;
    }

    public void AddMoney(int amount)
    {
        if (amount <= 0)
            return;

        money += amount;
    }

    public int GetMoney()
    {
        return money;
    }
}
