using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTimeManager : MonoBehaviour, Skill
{
    //スキルの発動を管理するスクリプトです

    //スキルのクールタイム
    public float skillTimae;

    //スクリプト内で使う時間のカウント
    private float time;

    void Start()
    {
        time = skillTimae;
        Skill.skillFlg = true;
    }


    void Update()
    {
        if(Skill.skillFlg == false)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = skillTimae;
                Skill.skillFlg = true;
                Debug.Log("スキル使用可能");
            }
        }
    }
}
