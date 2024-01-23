using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;

public class PC : MonoBehaviour
{

    public int playerID = 0;
    public Transform startPos;
    public int coolDownTime = 5;

    [HideInInspector]
    public int nowPlayerID;

    [HideInInspector]
    public bool nowStopFlg = false;

    [HideInInspector]
    public bool elevatorFlg = false;

    [HideInInspector]
    public GameObject nowPlayer;

    [SerializeField]
    private GameObject[] playerType;

    [SerializeField]
    private GameObject can;

    [SerializeField]
    private Image[] playerImage;

    [SerializeField]
    private InputActionReference change;

    private Vector3 nowPos;

    FollowTaggedObject followTaggedObject;

    [SerializeField]
    private float TomatoOffsetY;
    [SerializeField]
    private Vector3 TomatoCPsize;

    [SerializeField]
    private float BroccoliOffsetY;
    [SerializeField]
    private Vector3 BroccoliCPsize;

    [SerializeField]
    private float CarrotOffsetY;
    [SerializeField]
    private Vector3 CarrotCPsize;

    [SerializeField]
    private float WatermelonOffsetY;
    [SerializeField]
    private Vector3 WatermelonCPsize;

    private GameObject CMFreeLook;
    private CinemachineFreeLook freeLook;

    void Awake()
    {
        //有効化
        change.action.Enable();

        CMFreeLook = GameObject.Find("CM FreeLook1");
        freeLook = CMFreeLook.GetComponent<CinemachineFreeLook>();

        nowPlayer = Instantiate(playerType[playerID], startPos.position, Quaternion.identity);

        freeLook.Follow = nowPlayer.transform;
        freeLook.LookAt = nowPlayer.transform;

        if (nowPlayer.TryGetComponent<CarrotController>(out CarrotController tc)) tc.pc = this.gameObject.GetComponent<PC>();
        if (nowPlayer.TryGetComponent<PotController>(out PotController po)) po.pc = this.gameObject.GetComponent<PC>();

        //followTaggedObject = GameObject.FindWithTag("FTO").GetComponent<FollowTaggedObject>();
        //followTaggedObject.TomatoSerect(TomatoOffsetY, nowPlayer, TomatoCPsize);
    }

    void Update()
    {
        if (Stop.stopFlg && !nowStopFlg) return;

        //色変更
        for (int i = 0; i < playerImage.Length; i++)
        {
            if (playerID == i) playerImage[i].color = Color.yellow;
            else playerImage[i].color = Color.white;
        }
    }

    /// <summary>
    /// プレイヤー変更処理
    /// </summary>
    public void ChangePlayer()
    {
        nowPlayerID = playerID;
        nowPos = nowPlayer.transform.position;
        nowPos.y += 1f;
        Destroy(nowPlayer);
        nowPlayer = Instantiate(playerType[playerID], nowPos, Quaternion.identity);

        freeLook.Follow = nowPlayer.transform;
        freeLook.LookAt = nowPlayer.transform;

        if (nowPlayer.TryGetComponent<CarrotController>(out CarrotController tc)) tc.pc = this.gameObject.GetComponent<PC>();
        if (nowPlayer.TryGetComponent<PotController>(out PotController po)) po.pc = this.gameObject.GetComponent<PC>();

        //if(nowPlayerID == 0)
        //{
        //    followTaggedObject.TomatoSerect(TomatoOffsetY, nowPlayer, TomatoCPsize);
        //}
        //else if (nowPlayerID == 1)
        //{
        //    followTaggedObject.BroccoliSerect(BroccoliOffsetY, nowPlayer, BroccoliCPsize);
        //}
        //else if (nowPlayerID == 2)
        //{
        //    followTaggedObject.CarrotSerect(CarrotOffsetY, nowPlayer, CarrotCPsize);
        //}
        //else
        //{
        //    followTaggedObject.WatermelonSerect(WatermelonOffsetY, nowPlayer, WatermelonCPsize);
        //}
    }
}
