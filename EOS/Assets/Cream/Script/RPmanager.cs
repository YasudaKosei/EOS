using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPmanager : MonoBehaviour
{
    //ランキング表示のスクリプト

    [SerializeField] Text rankText;
    [SerializeField] Text playerNameText;
    [SerializeField] Text timeText;
    [SerializeField] Text dayText;

    public void StartRankPrefab(int rankVal, string playerName, int timeVal, string day)
    {
        rankText.text = rankVal.ToString();
        timeText.text = Convertime(timeVal);
        playerNameText.text = playerName;
        dayText.text = day;
    }

    //秒数を、時分秒の表示になをす
    private string Convertime(int timeVal)
    {
        int hoursVal;
        int minutesVal;
        int secondsVal;

        string hours;
        string minutes;
        string seconds;

        string time;

        //時分秒それぞれの値を計算
        hoursVal = (timeVal / 60) / 60;
        minutesVal = ((timeVal / 60) % 60) / 60;
        secondsVal = ((timeVal / 60) % 60) % 60;

        //TimeCheckを使って値が10未満なら文字列の最初に0を入れる
        hours = TimeCheck(hoursVal);
        minutes = TimeCheck(minutesVal);
        seconds = TimeCheck(secondsVal);

        //直した物をtimeに入れる
        time = hours + " : " + minutes + " : " + seconds;

        return time;
    }

    private string TimeCheck(int cTimeVal)
    {
        string cTime;

        if (cTimeVal < 10)
        {
            cTime = "0" + cTimeVal.ToString();
        }
        else
        {
            cTime = cTimeVal.ToString();
        }

        return cTime;
    }

}
