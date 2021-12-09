using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] TextMeshProUGUI iqText;
    public ShopItem[] shopItems;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] purchaseButtons;

    void Awake() => gameData = SaveSystem.Load();

    void Start()
    {
        RefreshIQ();

        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }

        LoadItemPanels();
        CheckPurchasable();
    }

    public void LoadItemPanels()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].titleText.text = shopItems[i].title;
            shopPanels[i].descriptionText.text = shopItems[i].description;
            shopPanels[i].costText.text = shopItems[i].baseCost.ToString() + " IQ";
            shopPanels[i].iconImage.sprite = shopItems[i].iconSprite;
        }
    }

    public void CheckPurchasable()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (gameData.iqTotal >= shopItems[i].baseCost) purchaseButtons[i].interactable = true;
            else purchaseButtons[i].interactable = false;
        }
    }

    public void PurchaseItem(int buttonNumber)
    {
        if (gameData.iqTotal >= shopItems[buttonNumber].baseCost)
        {
            gameData.iqTotal -= shopItems[buttonNumber].baseCost;
            RefreshIQ();
            CheckPurchasable();

            switch (buttonNumber)
            {
                case 0:
                    gameData.timeTotal += 10;   // timer increased by 10 seconds
                    break;
                default:
                    break;
            }

            SaveSystem.Save(gameData);
        }
    }

    void RefreshIQ() => iqText.text = gameData.iqTotal.ToString() + " IQ";
}
