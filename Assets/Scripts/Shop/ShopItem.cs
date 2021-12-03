using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/New Shop Item", order = 1)]
public class ShopItem : ScriptableObject
{
    public string title;
    public string description;
    public int baseCost;
}
