using UnityEngine;
using UnityEngine.UI;

public class GridLayoutHelper : MonoBehaviour
{
    float width;
    public float height;

    void Update()
    {
        width = GetComponent<RectTransform>().rect.width;
        Vector2 newSize = new Vector2(width / height, width / height);
        GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}