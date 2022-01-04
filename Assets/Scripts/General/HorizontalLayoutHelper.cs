using UnityEngine;
using UnityEngine.UI;

public class HorizontalLayoutHelper : MonoBehaviour
{
    WordGenerator wordGenerator;
    RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        wordGenerator = FindObjectOfType<WordGenerator>();
    }

    void Update()
    {
        switch (wordGenerator.randomWord.Length)
        {
            case 5:
                rectTransform.offsetMin = new Vector2(400.0f, rectTransform.offsetMin.y);
                rectTransform.offsetMax = new Vector2(-400.0f, rectTransform.offsetMax.y);
                break;
            case 6:
                rectTransform.offsetMin = new Vector2(300.0f, rectTransform.offsetMin.y);
                rectTransform.offsetMax = new Vector2(-300.0f, rectTransform.offsetMax.y);
                break;
            case 7:
                rectTransform.offsetMin = new Vector2(200.0f, rectTransform.offsetMin.y);
                rectTransform.offsetMax = new Vector2(-200.0f, rectTransform.offsetMax.y);
                break;
            case 8:
                rectTransform.offsetMin = new Vector2(100.0f, rectTransform.offsetMin.y);
                rectTransform.offsetMax = new Vector2(-100.0f, rectTransform.offsetMax.y);
                break;
            case 9:
                rectTransform.offsetMin = new Vector2(0.0f, rectTransform.offsetMin.y);
                rectTransform.offsetMax = new Vector2(0.0f, rectTransform.offsetMax.y);
                break;
            case 10:
                rectTransform.offsetMin = new Vector2(0.0f, rectTransform.offsetMin.y);
                rectTransform.offsetMax = new Vector2(0.0f, rectTransform.offsetMax.y);
                break;
            default:
                break;
        }
    }
}