using UnityEngine;

public class DeviceDependant : MonoBehaviour
{
    public Mode mode;
    public bool enabledChildren;

    private void Start()
    {
        if (DeviceManager.mode != Mode.VR && mode == Mode.VR)
        {
            DestroyImmediate(gameObject);
        }
            
        if (DeviceManager.mode != Mode.AR && mode == Mode.AR)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            if (enabledChildren)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }
}