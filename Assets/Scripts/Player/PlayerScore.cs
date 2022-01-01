using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int correctLetters;

    void Start() => correctLetters = 0;

    public void IncreaseCorrectLetters() => correctLetters += 1;
}
