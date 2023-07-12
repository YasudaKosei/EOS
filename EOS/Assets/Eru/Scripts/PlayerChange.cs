using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public int playerID = 0;
    public Vector3 startPos;
    public int coolDownTime = 5;

    [SerializeField]
    private GameObject[] playerType;

    private GameObject nowPlayer;
    private Vector3 nowPos;
    private int time;
    private float timer = 0;
    private bool changeFlg = false;
    private PlayerInput playerInput;

    void Awake()
    {
        nowPlayer = Instantiate(playerType[playerID], startPos, Quaternion.identity);
        time = coolDownTime;
        playerInput = new PlayerInput();
        playerInput.Enable();
    }

    void Update()
    {
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

        if (playerInput.actions.Change.triggered)
        {
            if (changeFlg) ChangePlayer();
            else Debug.Log("クールダウン中");
        }
    }

    public void ChangePlayer()
    {
        playerID++;
        if (playerID > playerType.Length - 1) playerID = 0;
        nowPos = nowPlayer.transform.position;
        nowPos.y += 1f;
        Transform cam = Camera.main.GetComponent<Transform>();
        cam.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 1, cam.transform.position.z);
        Destroy(nowPlayer);
        nowPlayer = Instantiate(playerType[playerID], nowPos, Quaternion.identity);
        time = coolDownTime;
        timer = 0;
        changeFlg = false;
    }
}
