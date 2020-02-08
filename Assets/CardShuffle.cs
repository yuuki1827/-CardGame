using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードをシャッフルするクラス
/// </summary>
public class CardShuffle : MonoBehaviour
{
    /* カードを保持するリスト */
    List<Card> cardList;

    /* 各マークでの枚数を判定 */
    const int numbersInSuit = 13;

    /* 各マークのIDを決める */
    const int Spade = 0;
    const int Club = 1;
    const int Heart = 2;
    const int Diamond = 3;
    List<int> suits = new List<int>() { Spade, Club, Heart, Diamond };

    void Start()
    {
        InitializeCordList();
        ShuffleCards();
        ShowCardName();
    }

    /// <summary>
    /// 山札の初期化を行う
    /// </summary>
    void InitializeCordList()
    {
        // 山札を初期化する
        cardList = new List<Card>();

        // 各マークごとにカードを生成
        foreach(int suit in suits)
        {
            for (int i = 1; i <= numbersInSuit; i++)
            {
                Card card = new Card(suit, i, false);
                cardList.Add(card);
            }
        }

        // ジョーカーを追加
        Card joker = new Card(0, 0, true);
        cardList.Add(joker);
    }

    /// <summary>
    /// コンソールに出力する
    /// </summary>
    void ShowCardName()
    {

        //

        //// コンソールに表示する
        //Debug.Log(cardText);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string separator = ", ";
        foreach (Card card in cardList)
        {
            if (card.isJoker)
            {
                sb.Append("JOKER").Append(separator);
            }
            else
            {
                sb.Append(GetSuitMark(card.suit)).
                    Append(GetSpecialNumber(card.number)).Append(separator);
            }
        }
        string cardText = sb.ToString();

        // 一行あたり15枚のカードを表示する
        int cardInLine = 15;
        int cardCount = 0;

        // 区切り文字を使用して、カードを一枚ごとの配列に格納する
        string[] separatorChar = { separator };
        string[] cards = cardText.Split(separatorChar,
            System.StringSplitOptions.RemoveEmptyEntries);
        sb = new System.Text.StringBuilder();
        for(int i = 0; i < cards.Length; i++)
        {
            sb.Append(cards[i]).Append(separator);
            cardCount++;
            // 表示枚数に達していたらコンソールに表示
            if(cardCount < cardInLine)
            {
                continue;
            }
            string line = sb.ToString();
            if(i == cards.Length - 1)
            {
                line = RemoveLastSeparator(line, separator);
            }
            Debug.Log(line);
            sb = new System.Text.StringBuilder();
            cardCount = 0;
        }
        // 最後のカンマだけ削除する
        string lastLine = sb.ToString();
        if(lastLine.Length > 0)
        {
            lastLine = RemoveLastSeparator(lastLine, separator);
            Debug.Log(lastLine);
        }
    }

    /// <summary>
    /// 置換処理（カンマの削除）
    /// </summary>
    /// <param name="line">文字列</param>
    /// <param name="separator">カンマ</param>
    /// <returns>削除後の文字列</returns>
    string RemoveLastSeparator(string line, string separator)
    {
        int index = line.LastIndexOf(separator);
        if(index != -1)
        {
            line = line.Remove(index);
        }
        return line;
    }

    /// <summary>
    /// IDに応じたマークを返す
    /// </summary>
    /// <param name="suit">マークID</param>
    /// <returns></returns>
    string GetSuitMark(int suit)
    {
        string suitMark;
        switch (suit)
        {
            case Spade:
                suitMark = "♠︎";
                break;
            case Club:
                suitMark = "♣︎";
                break;
            case Heart:
                suitMark = "♡";
                break;
            case Diamond:
                suitMark = "♢";
                break;
            default:
                suitMark = "JOKER";
                break;
        }
        return suitMark;
    }

    /// <summary>
    /// 1,11~13をアルファベットにして返す
    /// </summary>
    /// <param name="number">数字</param>
    /// <returns></returns>
    string GetSpecialNumber(int number)
    {
        if(1 < number && number < 11)
        {
            return number.ToString();
        }
        string special = "None";
        switch (number)
        {
            case 1:
                special = "A";
                break;
            case 11:
                special = "J";
                break;
            case 12:
                special = "Q";
                break;
            case 13:
                special = "K";
                break;
        }
        return special;
    }

    /// <summary>
    /// カードをシャッフルする
    /// </summary>
    void ShuffleCards()
    {
        // 順番にカードデッキの配列にアクセスする
        for (int i = 0; i < cardList.Count; i++)
        {
            // アクセスした要素(A)は一時的に変数に格納
            Card temp = cardList[i];
            // 要素を格納する位置を「Random.Range」を使用してランダムに取得
            int randomIndex = Random.Range(0, cardList.Count);
            // 移動先の要素(B)を(A)の位置に格納
            cardList[i] = cardList[randomIndex];
            // (B)の位置に(A)を格納
            cardList[randomIndex] = temp;
        }
    }
}
