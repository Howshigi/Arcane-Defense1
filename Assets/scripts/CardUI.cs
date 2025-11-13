using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CardUI : MonoBehaviour
{
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI descriptionText;
    public Image cardImage;       // Image ของการ์ด
    public Button selectButton;

    private CardData cardData;
    public Action<CardData> onCardSelected;

    public void SetCard(CardData data)
    {
        cardData = data;

        if(cardNameText != null) cardNameText.text = data.cardName;
        if(descriptionText != null) descriptionText.text = data.description;

        if(cardImage != null && data.cardImage != null)
        {
            cardImage.sprite = data.cardImage;
            cardImage.color = Color.white;  // กรณี Image สีโปร่ง
        }

        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => onCardSelected?.Invoke(cardData));
    }
}