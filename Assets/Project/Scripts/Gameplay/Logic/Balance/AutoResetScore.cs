using UnityEngine;

public class AutoResetScore : MonoBehaviour
{
    private void Awake()
    {
        Score.Reset();
    }
}