using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class Dealer : MonoBehaviour
{
    /// <summary>
    /// カードの種類とカードのGameObjectを一緒に管理
    /// </summary>
    Dictionary<int, GameObject> cards;

    /// <summary>
    /// カードのGameObject(プレハブ)
    /// </summary>
    [SerializeField]
    private List<GameObject> cardPrefabs;

    /// <summary>
    /// 場に出ているカードのGameObject(クローン)
    /// </summary>
    [SerializeField]
    private List<GameObject> fieldCards;

    // 「めくる」ボタンを押された回数
    int turnNum = 0;

    void Start()
    {
        InitializeCard();
        ShowCards();
    }

    public void OnClick()
    {
        CaredOpen();
    }

    /// <summary>
    /// 山札の初期化
    /// </summary>
    void InitializeCard()
    {
        // カード情報の初期化
        cards = new Dictionary<int, GameObject>();
        for (int i = 0; i < Card.numbersInSuit; i++)
        {
            cards.Add(i, cardPrefabs[i]);
        }
    }

    /// <summary>
    /// 山札を場に出す
    /// </summary>
    void ShowCards()
    {
        fieldCards = new List<GameObject>();

        // カードを場に出す
        foreach (var card in cards)
        {
            var go = Instantiate(card.Value);
            fieldCards.Add(go);
            if (card.Key > 0)
            {
                go.transform.position = new Vector3(
                    fieldCards[card.Key - 1].transform.position.x,
                    fieldCards[card.Key - 1].transform.position.y,
                    fieldCards[card.Key - 1].transform.position.z - 0.01f
                );
            }
        }
    }

    /// <summary>
    /// カードをめくる
    /// </summary>
    public void CaredOpen()
    {
        if (turnNum < Card.numbersInSuit) {
            fieldCards[turnNum].transform.position = new Vector3(
                fieldCards[turnNum].transform.position.x + 10f,
                fieldCards[turnNum].transform.position.y,
                fieldCards[turnNum].transform.position.z + 0.01f);

            fieldCards[turnNum].transform.rotation = Quaternion.Euler(
                fieldCards[turnNum].transform.rotation.x + 90f,
                fieldCards[turnNum].transform.rotation.y + 180f,
                fieldCards[turnNum].transform.rotation.z);

                turnNum++;
        }
        else
        {
            return;
        }
    }
}