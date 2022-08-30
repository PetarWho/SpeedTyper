using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public static bool GameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameOver = true;
    }
}
