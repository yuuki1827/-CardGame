using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードのデータを保持するクラス
/// </summary>
public class Card : MonoBehaviour
{
    /* 各マークでの枚数を判定 */
    public const int numbersInSuit = 13;

    /// <summary>
    /// カードをめくる位置を設定する
    /// </summary>
    /// <param name="position">奥行きのポジション</param>
    public void CardOpen(float position)
    {
        transform.position = new Vector3(
            transform.position.x + 10f, transform.position.y, position);
        transform.rotation = Quaternion.Euler(
            transform.rotation.x + 90f, transform.rotation.y, transform.rotation.z - 180f);
    }

    /// <summary>
    /// カードをセットする位置を設定する
    /// </summary>
    /// <param name="position">奥行きのポジション</param>
    public void CardSet(float position)
    {
        transform.position = new Vector3(-5f, 0f, position);
        transform.rotation = Quaternion.Euler(-90f, 0f, 180f);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}




