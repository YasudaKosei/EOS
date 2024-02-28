using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void URL(string ulr)
    {
        Application.OpenURL(ulr);
    }
}
