using UnityEngine;
using UnityEngine.UI;

public class GridLayoutHelper : MonoBehaviour
{
    public float width;
    public float something;

    void Update()
    {
        width = this.gameObject.GetComponent<RectTransform>().rect.width;
        Vector2 newSize = new Vector2(width / something, width / something);
        this.gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}
