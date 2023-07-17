using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerChange : MonoBehaviour
{
    public int playerID = 0;
    public Vector3 startPos;
    public int coolDownTime = 5;

    [HideInInspector]
    public int nowPlayerID;

    [HideInInspector]
    public bool nowStopFlg = false;

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
    private int time;
    private float timer = 0;
    private bool changeFlg = true;
    private bool idFlg = true;

    void Awake()
    {
        nowPlayer = Instantiate(playerType[playerID], startPos, Quaternion.identity);
        time = coolDownTime;
        change.action.Enable();
        can.SetActive(false);
        nowPlayerID = playerID;
        nowStopFlg = false;
    }

    void Update()
    {
        if (Stop.stopFlg && !nowStopFlg) return;

        if (!changeFlg)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer = 0;
                time--;
            }
            if (time <= 0) changeFlg = true;
        }

        if (change.action.triggered)
        {
            if (changeFlg)
            {
                can.SetActive(true);
                if (idFlg) nowPlayerID = playerID;
                idFlg = false;
                Stop.stopFlg = true;
                nowStopFlg = true;
            }
            else Debug.Log("クールダウン中");
        }

        for (int i = 0; i < playerImage.Length; i++)
        {
            if (playerID == i) playerImage[i].color = Color.yellow;
            else playerImage[i].color = Color.white;
        }
    }

    public void ChangePlayer()
    {
        nowPos = nowPlayer.transform.position;
        nowPos.y += 1f;
        Transform cam = Camera.main.GetComponent<Transform>();
        cam.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 1, cam.transform.position.z);
        Destroy(nowPlayer);
        nowPlayer = Instantiate(playerType[playerID], nowPos, Quaternion.identity);
        time = coolDownTime;
        timer = 0;
        changeFlg = false;
        idFlg = true;
    }
}
