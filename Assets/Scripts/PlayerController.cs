using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    public float turnSpeed;
    public float moveSpeed;

    void Update()
    {
        if (photonView.IsMine)
        {
            var forward = Input.GetAxis("Vertical");
            var turn = Input.GetAxis("Horizontal");

            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            transform.position += transform.forward * forward * moveSpeed * Time.deltaTime;

            if (DeviceManager.mode == Mode.AR && Input.GetTouch(0).tapCount > 0)
            {
                Debug.Log($"Jumping");
                GetComponent<Rigidbody>().AddForce(0, 200, 0);
            }
        }
    }

    public static void RefreshInstance(ref PlayerController playerController, PlayerController prefab)
    {
        var position = Vector3.zero;
        var rotation = Quaternion.identity;

        if (playerController != null)
        {
            position = playerController.transform.position;
            rotation = playerController.transform.rotation;
            PhotonNetwork.Destroy(playerController.gameObject);
        }

        playerController = PhotonNetwork.Instantiate(prefab.gameObject.name, position, rotation)
            .GetComponent<PlayerController>();
    }
}