using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public TextMeshProUGUI coinDisplay;
    void Update()
    {
        coinDisplay.SetText(User.Coins.ToString());
    }
}
