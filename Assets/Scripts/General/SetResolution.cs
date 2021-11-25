using UnityEngine;

public class SetResolution : MonoBehaviour
{
    void Start() => Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
}
