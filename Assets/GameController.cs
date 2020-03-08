using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Dealer
{
    // memo: ハイアンドローのロジックを作る

    // カードの代わりとなる１〜１３の数
    //static List<int> numbers = new List<int>();

    // めくった数字を格納する
    static List<int> turnedOver = new List<int>();

    public static void GameMain(List<int> fieldCards, int turnNum, int button)
    {

        // カードめくられたカードを用意
        //InSuit(fieldCards);
        var nextNum = fieldCards[turnNum];


        // めくられる前カード
        //var nextNum = CardNext();
        turnNum--;
        var num = fieldCards[turnNum];

        Debug.Log(num);
        Debug.Log(nextNum);

        // めくられたカードが上か下か当てる
        var result = Judge(num, nextNum, button);


        // 勝ち負け判定
        if (result)
            Debug.Log("勝ち！！");
        else
            Debug.Log("負け...");
    }

    // 数の初期化
    //static void InSuit(List<int> numbers)
    //{
    //    for (int i = 1; i <= Card.numbersInSuit; i++)
    //    {
    //        // オブジェクト名を取得
    //        string str = fieldCards[i].name;

    //        for (int j = 1; i <= Card.numbersInSuit; j++)
    //        {
    //            // 検索文字列を設定
    //            string target = j.ToString("00");
    //            // 検索値を取得
    //            string search = str.Substring(
    //                str.IndexOf(target, System.StringComparison.CurrentCulture),
    //                target.Length);
    //            // 検索値を取得できていればfor文を抜ける
    //            if(search != null)
    //            {
    //                int num;
    //                int.TryParse(search, out num);
    //                numbers.Add(num);
    //                break;
    //            }
    //        }
    //    }
    //}

    // カードをめくるメソッド
    //static int CardNext()
    //{
    //    // 数字を取り出す
    //    var index = new System.Random().Next(0, numbers.Count);
    //    var number = numbers[index];
    //    // めくった数字を記憶させてデッキから消す
    //    numbers.RemoveAt(index);
    //    turnedOver.Add(number);

    //    return number;
    //}

    // 上か下かの判定を決めるメソッド
    // true=勝ち、false=負け
    static bool Judge(int card, int nextCard, int player)
    {
        var result = false;

        // めくった数が場に出ている数よりも小さいか
        // かつプレイヤーの手が下だったら
        if ((card > nextCard) && player == 2)
        {
            result = true;
        }
        // めくった数が場に出ている数よりも大きいか
        // かつプレイヤーの手が下だったら
        else if ((card < nextCard) && player == 1)
        {
            result = true;
        }

        return result;
    }
}

