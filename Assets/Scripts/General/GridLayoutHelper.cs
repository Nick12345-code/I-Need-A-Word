using UnityEngine;
using UnityEngine.UI;

public class GridLayoutHelper : MonoBehaviour
{
    public float width;
    public int height;

    void Update()
    {
        width = GetComponent<RectTransform>().rect.width;
        Vector2 newSize = new Vector2(width / height, width / height);
        GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}