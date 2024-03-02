using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    NONE,
    ATTACK,
    DEFENSE,
    UTILITY,
    SPECIAL
}

public enum Rarity
{
    COMMON,
    RARE,
    EPIC,
    LEGENDARY,
}

public enum Effect
{
    MELEE_ATTACK,
    RANGED_ATTACK,
    DEFENSE,
    DRAW_CARD,
    RECOVER_COST,
    DELAY
}

[System.Serializable]
public class CardEffect
{
    public Effect effect;
    public int value;
    public Vector2[] range;
    
    public IEnumerator ApplyEffect()
    {
        switch (effect)
        {
            case Effect.MELEE_ATTACK:
                Player.instance.Melee_Attack(value);
                break;
            case Effect.RANGED_ATTACK:
                Debug.Log("Ranged Attack: " + value);
                break;
            case Effect.DEFENSE:
                Debug.Log("Defense: " + value);
                break;
            case Effect.DRAW_CARD:
                Debug.Log("Draw Card: " + value);
                break;
            case Effect.RECOVER_COST:
                Debug.Log("Recover Cost: " + value);
                break;
            case Effect.DELAY:
                yield return new WaitForSeconds(value);
                break;
        }
    }
}

[System.Serializable]
public class Item
{
    public Sprite sprite;
    public int Cost;
    public string cardName;
    [TextArea(3, 10)]
    public string description;
    public Rarity rarity;
    public Vector2 Range;
    public CardEffect[] effects;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO", order = 1)]
public class ItemSO : ScriptableObject
{
    public Item[] items;
}
