using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.Events;

public class CardTooltipUI : MonoBehaviour
{
    [SerializeField] public Image CardImageObject;
    [SerializeField] private RectTransform CardTipCanvas;
    public GameCon1 controller;
    public Sprite CardImage;
    [SerializeField] private TextMeshProUGUI infoText;
    private Card card;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float padding;
    public UnityEvent<Card> CardDataChangeEvent;

    private void Awake()
    {
        CardDataChangeEvent.AddListener(DisplayInfo);

    }

    private void Update()
    {
        


    }
    public void DisplayInfo(Card card)
    {
        CardImage = controller.card.cardPicture;
        CardImageObject.sprite = CardImage;
        StringBuilder builder = new StringBuilder();        
        builder.Append(card.CardTooltipInfoText());
        infoText.text = builder.ToString();

//        LayoutRebuilder.ForceRebuildLayoutImmediate(CardTipCanvas);
    }

    public void HideInfo()
    {
        CardTipCanvas.gameObject.SetActive(false);
    }


}
