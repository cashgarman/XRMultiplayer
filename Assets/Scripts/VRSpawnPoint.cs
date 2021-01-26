using UnityEngine;

public class VRSpawnPoint : MonoBehaviour
{
    void Start()
    {
        if (DeviceManager.mode == Mode.VR)
        {
            Debug.Log($"Teleporting VR rig to {name}");
            GameObject.FindGameObjectWithTag("VRRig").transform.position = transform.position;
        }
    }
}
