using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードのデータを保持するクラス
/// 数字・マーク・ジョーカー判定の3項目を持つ
/// </summary>
public class Card
{
    /* カードのマーク */
    public int suit;

    /* カードの数字 */
    public int number;

    /* ジョーカー判定 */
    // Jokerの場合、マーク・数字に関係なくJoker扱いとする
    public bool isJoker;

    /* 各マークでの枚数を判定 */
    public const int numbersInSuit = 13;

    /* 各マークのIDを決める */
    public const int Spade = 0;
    public const int Club = 1;
    public const int Heart = 2;
    public const int Diamond = 3;

    public Card(int suit, int number, bool isJoker)
    {
        this.suit = suit;
        this.number = number;
        this.isJoker = isJoker;
    }

    /// <summary>
    /// IDに応じたマークを返す
    /// </summary>
    /// <param name="suit">マークID</param>
    /// <returns></returns>
    public static string GetSuitMark(int suit)
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
    public static string GetSpecialNumber(int number)
    {
        if (1 < number && number < 11)
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
}




