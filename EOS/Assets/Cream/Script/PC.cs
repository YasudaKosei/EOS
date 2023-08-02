using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PC : MonoBehaviour
{
    public int playerID = 0;
    public Vector3 startPos;
    public int coolDownTime = 5;

    [HideInInspector]
    public int nowPlayerID;

    [HideInInspector]
    public bool nowStopFlg = false;

    [HideInInspector]
    public bool elevatorFlg = false;

    [SerializeField]
    private GameObject[] playerType;

    [SerializeField]
    private GameObject can;

    [SerializeField]
    private Image[] playerImage;

    [SerializeField]
    private InputActionReference change;

    private GameObject nowPlayer;
    private Vector3 nowPos;

    void Awake()
    {
        //有効化
        change.action.Enable();

        nowPlayer = Instantiate(playerType[playerID], startPos, Quaternion.identity);
        if (nowPlayer.TryGetComponent<TomatoController>(out TomatoController tc)) tc.pc = this.gameObject.GetComponent<PC>();
        if (nowPlayer.TryGetComponent<PotController>(out PotController po)) po.pc = this.gameObject.GetComponent<PC>();
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
        if (nowPlayer.TryGetComponent<TomatoController>(out TomatoController tc)) tc.pc = this.gameObject.GetComponent<PC>();
        if (nowPlayer.TryGetComponent<PotController>(out PotController po)) po.pc = this.gameObject.GetComponent<PC>();
    }
}
