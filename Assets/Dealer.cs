using System.Collections.Generic;
using UnityEngine;


public class Dealer : MonoBehaviour
{
    /// <summary>
    /// カードの種類とカードのGameObjectを一緒に管理
    /// </summary>
    Dictionary<int, GameObject> cards;

    /// <summary>
    /// 場に出ているカードのGameObject(クローン)
    /// </summary>
    private List<GameObject> fieldCards;

    // 「めくる」ボタンを押された回数
    int turnNum = 0;

    // カードの位置を格納する変数
    float position = 0;

    // めくったカードの位置を格納する変数
    float turnPosition = 0;

    void Start()
    {
        InitializeCard();
        ShowCards();
    }

    /// <summary>
    /// めくるボタンの処理
    /// </summary>
    public void Turn()
    {
        if(turnNum < Card.numbersInSuit) {
            turnPosition = turnPosition - 0.01f;
            fieldCards[turnNum].GetComponent<Card>().CardOpen(turnPosition);
            turnNum++;
        }
    }

    /// <summary>
    /// リセットボタンの処理
    /// </summary>
    public void CardReset()
    {
        turnNum = 0;
        turnPosition = 0;
        position = 0;
        for (int i = 0; i < Card.numbersInSuit; i++)
        {
            position = position - 0.01f;
            fieldCards[i].GetComponent<Card>().CardSet(position);
        }
        ShuffleCards();
    }

    /// <summary>
    /// 山札の初期化
    /// </summary>
    void InitializeCard()
    {
        // カード情報の初期化
        cards = new Dictionary<int, GameObject>();
        for (int i = 1; i <= Card.numbersInSuit; i++)
        {
            // プレハブのファイルパス+ファイル名
            string prefabName;
            string prefabPath = "Prefab/BackColor_Black/Black_PlayingCards_Club";
            // 1桁の場合は「0」を付ける
            if (i < 10)
            {
                prefabName = "0" + i.ToString() + "_00"; 
            }
            else
            {
                prefabName = i.ToString() + "_00";
            }
            // プレハブを読み込む
            GameObject prefab = (GameObject)Resources.Load(prefabPath + prefabName);
            cards.Add(i, prefab);
            Debug.Log(cards);
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
            go.AddComponent<Card>();
            fieldCards.Add(go);
            if (card.Key > 0)
            {
                position = position - 0.01f;
                go.GetComponent<Card>().CardSet(position);
            }
        }
        ShuffleCards();
        Turn();
    }

    /// <summary>
    /// カードをシャッフルする
    /// </summary>
    void ShuffleCards()
    {
        // 順番にカードデッキの配列にアクセスする
        for (int i = 0; i < Card.numbersInSuit; i++)
        {
            // アクセスした要素(A)は一時的に変数に格納
            var temp = fieldCards[i];
            // 要素を格納する位置を「Random.Range」を使用してランダムに取得
            int randomIndex = UnityEngine.Random.Range(0, fieldCards.Count);
            // 移動先の要素(B)を(A)の位置に格納
            fieldCards[i] = fieldCards[randomIndex];
            // (B)の位置に(A)を格納
            fieldCards[randomIndex] = temp;
        }
    }
}