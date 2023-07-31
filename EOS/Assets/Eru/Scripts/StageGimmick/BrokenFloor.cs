using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    [SerializeField, Header("����܂ł̎���")]
    private float brokenTime = 1f;

    [SerializeField, Header("����܂ł̎���")]
    private float returnTime = 2f;

    [SerializeField, Header("���ɖ߂�")]
    private bool returnOriginal = false;

    [SerializeField, Header("�v���C���[�w��")]
    private PlayerType playerType;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private float btimer, rtimer;
    private bool returnFlg = false;

    private enum PlayerType
    {
        none,
        Tomato,
        Pot,
        Broccoli,
        Carrot,
        Watermelon,
    }

    void Awake()
    {
        btimer = brokenTime;
        if (!returnOriginal) return;
        rtimer = 0f;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
    }

    void Update()
    {
        if (btimer <= 0f && !returnFlg)
        {
            //�j��
            if (!returnOriginal) gameObject.SetActive(false);
            else
            {
                rtimer = returnTime;
                returnFlg = true;
                meshRenderer.enabled = false;
                boxCollider.enabled = false;
            }
        }

        if (!returnFlg || !returnOriginal) return;

        if (rtimer > 0f) rtimer -= Time.deltaTime;
        else 
        {
            //���ɖ߂�
            btimer = brokenTime;
            returnFlg = false;
            meshRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (playerType != PlayerType.none && playerType.ToString() != collision.gameObject.tag) return;
        btimer -= Time.deltaTime;
    }
}
