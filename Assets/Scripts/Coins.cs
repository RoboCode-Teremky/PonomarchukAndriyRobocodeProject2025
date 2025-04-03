using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField]private int coins = 10;
    [SerializeField]TMP_Text TMP_text;
    void Start()
    {
        RefreshUI();
    }
     public void Addcoins(int value)
     {
        coins += value;
        RefreshUI();
     }
     public void Spendcoins(int value)
     {
        coins -= value;
        RefreshUI();
     }
      public bool CanSpendcoins(int value)
     {
        return coins >= value;
     }
     public void RefreshUI()
     {
        TMP_text.text = "Coins " + coins.ToString();
     }
}
