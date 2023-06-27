using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour,ITime
{
    public int ITime => timer;

    [SerializeField]
    private Text timeText;

    private int second = 0;
    private int minute = 0;
    private int hour = 0;
    private int timer = 0;
    private float time = 0;

    void Start()
    {
        //初期化
        time = 0;
        timer = 0;
        second = 0;
        minute = 0;
        hour = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        //秒
        if(time >= 1f)
        {
            time = 0;
            second++;
            timer++;
        }

        //分
        if(second >= 60)
        {
            second = 0;
            minute++;
        }

        //時
        if(minute >= 60)
        {
            minute = 0;
            hour++;
        }

        //テキスト
        timeText.text = hour.ToString("d2") + ":" + minute.ToString("d2") + ":" + second.ToString("d2");
    }
}
