using UnityEngine;
using UnityEngine.UI;

public class HorizontalLayoutHelper : MonoBehaviour
{
    HorizontalLayoutGroup horizontalLayoutGroup;
    WordGenerator wordGenerator;

    void Awake()
    {
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        wordGenerator = FindObjectOfType<WordGenerator>();
    }

    void Update()
    {
        switch (wordGenerator.randomWord.Length)
        {
            case 5:
                //horizontalLayoutGroup.spacing = -600.0f;
                break;
            case 6:
                //horizontalLayoutGroup.spacing = -400.0f;
                break;
            case 7:
                //horizontalLayoutGroup.spacing = -100.0f;
                break;
            case 8:
                //horizontalLayoutGroup.spacing = 25.0f;
                break;
            default:
                break;
        }
    }
}