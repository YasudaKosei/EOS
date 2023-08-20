using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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

    void Awake()
    {
        //�L����
        change.action.Enable();

        nowPlayer = Instantiate(playerType[playerID], startPos.position, Quaternion.identity);
        if (nowPlayer.TryGetComponent<TomatoController>(out TomatoController tc)) tc.pc = this.gameObject.GetComponent<PC>();
        if (nowPlayer.TryGetComponent<PotController>(out PotController po)) po.pc = this.gameObject.GetComponent<PC>();
    }

    void Update()
    {
        if (Stop.stopFlg && !nowStopFlg) return;

        //�F�ύX
        for (int i = 0; i < playerImage.Length; i++)
        {
            if (playerID == i) playerImage[i].color = Color.yellow;
            else playerImage[i].color = Color.white;
        }
    }

    /// <summary>
    /// �v���C���[�ύX����
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
