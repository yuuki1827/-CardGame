using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class Dealer : MonoBehaviour
{
    /* カードの種類とカードのGameObjectを一緒に管理 */
    Dictionary<int, GameObject> cards;

    /* カードのGameObject(プレハブ) */
    [SerializeField]
    private List<GameObject> cardPrefabs;

    /* 場に出ているカードのGameObject(クローン) */
    [SerializeField]
    private List<GameObject> fieldCards;

    void Start()
    {
        cards = new Dictionary<int, GameObject>();
        cards.Add(0, cardPrefabs[0]);
        cards.Add(1, cardPrefabs[1]);
        cards.Add(2, cardPrefabs[2]);
        cards.Add(3, cardPrefabs[3]);

        fieldCards = new List<GameObject>();

        foreach (var card in cards)
        {
            var go = Instantiate(card.Value);
            fieldCards.Add(go);
            if (card.Key > 0)
            {
                go.transform.position = new Vector2(
                    fieldCards[card.Key - 1].transform.position.x + 0.25f,
                    fieldCards[card.Key - 1].transform.position.y
                );
            }
        }
    }
}
