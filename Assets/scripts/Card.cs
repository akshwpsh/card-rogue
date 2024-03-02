using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    [SerializeField] private TMP_Text cardName;
    [SerializeField] private TMP_Text cardDescription;

    public Item item;
    public void Setup(Item item)
    {
        this.item = item;
        cardImage.sprite = item.sprite;
        cardName.text = item.cardName;
        cardDescription.text = item.description;
    }
}
