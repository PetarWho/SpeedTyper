using TMPro;
using UnityEngine;

public class GetCustomSettings : MonoBehaviour
{
    [SerializeField] private TMP_InputField _customSpeed;
    [SerializeField] private TMP_InputField _customDelay;
    [SerializeField] private TMP_InputField _customScore;
    
    public static float CustomSpeed;
    public static float CustomDelay;
    public static int CustomScore;

    public void StartTheGame()
    {
        
        float cs = float.Parse(_customSpeed.text.ToString());
        float cd = float.Parse(_customDelay.text.ToString());
        int csc = int.Parse(_customScore.text.ToString());
        
        CustomDelay = cd;
        CustomSpeed = cs;
        CustomScore = csc;
    }
}
