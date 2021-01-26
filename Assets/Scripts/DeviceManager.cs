using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum Mode
{
	Desktop,
	VR,
	AR
}
	
public class DeviceManager : MonoBehaviour
{
	public static Mode mode;
		
	private List<XRDisplaySubsystem> displaySubsystems = new List<XRDisplaySubsystem>();

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
			
		SubsystemManager.GetInstances(displaySubsystems);
		if (displaySubsystems.Count != 0)
		{
			Debug.Log($"Running on VR");
			mode = Mode.VR;
		}
		else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			Debug.Log($"Running on AR");
			mode = Mode.AR;
		}
	}
}