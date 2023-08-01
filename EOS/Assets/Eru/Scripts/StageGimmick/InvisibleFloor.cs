using UnityEngine;

public class InvisibleFloor : MonoBehaviour
{
    [SerializeField, Header("Œ©‚¦‚È‚¢ŽžŠÔ")]
    private float invisivleTime = 2f;

    [SerializeField,Header("Œ©‚¦‚Ä‚éŽžŠÔ")]
    private float visivleTime = 2f;

    [SerializeField, Header("°")]
    private GameObject floorObj;

    private float inTime, viTime;

    private bool invisileFlg = false;


    void Start()
    {
        invisileFlg = false;
        viTime = visivleTime;
    }

    void Update()
    {
        if (viTime > 0) viTime -= Time.deltaTime;
        else if(!invisileFlg)
        {
            inTime = invisivleTime;
            invisileFlg = true;
        }
        if (inTime > 0) inTime -= Time.deltaTime;
        else if (invisileFlg)
        {
            viTime = visivleTime;
            invisileFlg = false;
        }

        floorObj.SetActive(!invisileFlg);
    }
}
