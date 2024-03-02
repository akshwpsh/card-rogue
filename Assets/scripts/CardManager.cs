using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public CardManager instance;
    public ItemSO itemSO;
    public GameObject cardPrefab;
    
    private List<Item> itemBuffer;
    
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        BufferSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            DrawCard();
    }
    
    void BufferSetup()
    {
        itemBuffer = itemSO.items.ToList();
    }
    
    void DrawCard()
    {
        var cardObject = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity);
        cardObject.transform.SetParent(transform, false);
        var card = cardObject.GetComponent<Card>();
        card.Setup(itemBuffer[Random.Range(0, itemBuffer.Count)]);
    }
}
