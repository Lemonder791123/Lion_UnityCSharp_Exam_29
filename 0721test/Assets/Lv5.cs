using UnityEngine;
using System.Linq;                  // 查詢
using System.Collections.Generic;  // List
using System.Collections;



//在編輯模式執行
[ExecuteInEditMode]
public class Lv5 : MonoBehaviour
{
    /// <summary>
    /// 撲克牌：所有牌、52張
    /// </summary>
    public List<GameObject> cards = new List<GameObject>();

    /// <summary>
    /// 花色：黑桃、方塊、愛心、梅花
    /// </summary>
    private string[] type = { "Spades", "Diamond", "Heart", "Club" };


    private void Start()
    {
        GetAllCard();
    }


    /// <summary>
    /// 取得所有撲克牌的方法
    /// </summary>
    private void GetAllCard()
    {
        if (cards.Count == 52) return;
        {

        }


        // 跑四個花色
        for (int i = 0; i < type.Length; i++)
        {
            // 跑 1-13張
            for (int j = 1; j < 14; j++)
            {

                string number = j.ToString();               //數字 = j.轉字串

                switch (j)
                {
                    case 1:                                 //數字 1 改為 A
                        number = "A";
                        break;
                    case 11:                                 //數字 11 改為 J
                        number = "J";
                        break;
                    case 12:                                 //數字 12 改為 Q
                        number = "Q";
                        break;
                    case 13:                                 //數字 13 改為 K
                        number = "K";
                        break;
                }

                //卡牌 = 素材.載入<遊戲物件>("素材名稱")
                GameObject card = Resources.Load<GameObject>("PlayingCards_" + number + type[i]);
                //撲克牌.添加(卡牌)
                cards.Add(card);
            }
        }
    }

    public void Sort()
    {
        DelteAllChild();

        //排序後的卡牌 = 從cards.找到資源放到card
        //where條件 - 梅花 || 愛心 || 方塊 || 黑桃
        //select 選取 card
        var sort = from card in cards
                   where card.name.Contains(type[0]) || card.name.Contains(type[1]) || card.name.Contains(type[2]) || card.name.Contains(type[3])
                   select card;


        foreach (var item in sort) Instantiate(item, transform);

        StartCoroutine(SetChildPosition());
    }

    private void DelteAllChild()
    {
        for (int i = 0; i < transform.childCount; i++) Destroy(transform.GetChild(i).gameObject);
    }


    private IEnumerator SetChildPosition()
    {
        yield return new WaitForSeconds(0.1f);                  //延遲0.1秒 避免執行開始刪除到這次卡牌
        for (int i = 0; i < transform.childCount; i++)          //迴圈執行每個子物件
        {
            Transform child = transform.GetChild(i);            
            child.eulerAngles = new Vector3(180, 0, 0);         
            child.localScale = Vector3.one * 20;                

            
            float x = i % 13;
            
            float y = i / 13;
            child.position = new Vector3((x - 6) * 1.3f, 4 - y * 2, 0);

            yield return null;
        }
    }


     

}