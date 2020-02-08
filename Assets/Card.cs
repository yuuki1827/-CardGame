using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードのデータを保持するクラス
/// 数字・マーク・ジョーカー判定の3項目を持つ
/// </summary>
public struct Card
{
    /* カードのマーク */
    public int suit;

    /* カードの数字 */
    public int number;

    /* ジョーカー判定 */
    // Jokerの場合、マーク・数字に関係なくJoker扱いとする
    public bool isJoker;

    public Card(int suit, int number, bool isJoker)
    {
        this.suit = suit;
        this.number = number;
        this.isJoker = isJoker;
    }
}