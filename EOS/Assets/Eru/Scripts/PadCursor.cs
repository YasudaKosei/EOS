using UnityEngine;
using UnityEngine.InputSystem;

public class PadCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject cursorCan;

    [SerializeField]
    private GameObject menuUI;

    private bool currentFlg = false;

    [Range(0.0f, 15.0f)]
    public float TimeToHide = 5.0f;

    [SerializeField]
    private RectTransform rectTransform;

    Vector2 currentMousePosition;

    void Start()
    {
        Vector3 mp = Input.mousePosition;
    }

    void Update()
    {
        if (Gamepad.current == null || !Stop.stopFlg)
        {
            currentFlg = false;
        }
        else if (Stop.stopFlg)
        {
            currentFlg = true;

            Vector3 mp = Input.mousePosition;
            currentMousePosition = new Vector2(mp.x, mp.y);

            rectTransform.transform.position = new Vector2(Mathf.Clamp(rectTransform.transform.position.x, 50, 1920),
                                                           Mathf.Clamp(rectTransform.transform.position.y, 50, 1080));
        }

        cursorCan.SetActive(currentFlg);
    }

    private void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (device is Gamepad)
        {
            if (change == InputDeviceChange.Added)
            {
                if (menuUI != null)
                {
                    Stop.stopFlg = true;
                    menuUI.SetActive(true);
                }
                currentFlg = true;

                Vector3 mp = Input.mousePosition;
                currentMousePosition = new Vector2(mp.x, mp.y);

                rectTransform.transform.position = new Vector2(Mathf.Clamp(rectTransform.transform.position.x, 50, 1920),
                                                               Mathf.Clamp(rectTransform.transform.position.y, 50, 1080));
            }
            else if (change == InputDeviceChange.Removed)
            {
                if (menuUI != null)
                {
                    Stop.stopFlg = true;
                    menuUI.SetActive(true);
                }
            }
        }
    }
}
