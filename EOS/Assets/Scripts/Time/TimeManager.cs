using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour, ITime
{
    //ゲームの時間を管理するスクリプトです

    // ITime プロパティを読み込むたびに timer フィールドの値が返される
    public int ITimer => timer;

    //画面に表示する時間テキスト
    public Text timeText;

    //時間の単位
    private int second = 0;
    private int minute = 0;
    private int timer = 0;
    private float time = 0;

    private bool limitFlg = false;

    void Start()
    {
        //時間の初期化
        time = 0;
        timer = 0;
        second = 0;
        minute = 0;
        limitFlg = false;
    }

    void Update()
    {
        //ゲームが止まっている時はここから先は進まない
        if (Stop.stopFlg || limitFlg) return;

        //時間を増やす
        time += Time.deltaTime;

        //秒
        if (time >= 1f)
        {
            time = 0;
            second++;
            timer++;
        }

        //分
        if (second >= 60)
        {
            if (minute >= 59)
            {
                timeText.text = "59:59";
                limitFlg = true;
                return;
            }

            second = 0;
            minute++;
        }


        //テキスト更新
        timeText.text = minute.ToString("d2") + ":" + second.ToString("d2");
    }
}
