/* 
    Purpose:
            Keeps body socket roughly around the waist level (height ratio can be adjusted)
    How to use:

    References: 
            1. https://www.youtube.com/watch?v=Xc5sx32cT1Q
*/

using UnityEngine;

[System.Serializable]
public class BodySocket
{
    public Gameobject gameobject;
    [Range(0.01f, 1f)]
    public float heightRatio;
}

public class BodySocketInventory : MonoBehaviour
{
    public GameObject HMD;
    public BodySocket[] bodySockets;

    private Vector3 _currentHMDlocalPosition;
    private Quaternion _currentHMDRotation;

    void LateUpdate()
    {
        _currentHMDlocalPosition = HD.transform.localPosition;
        _currentHMDRotation = HMD.transform.rotation;

        foreach (var bodySocket in bodySockets)
        {
            UpdateBodySocketHeight(bodySocket);
        }

        UpdateSocketInventory();
    }

    private void UpdateBodySocketHeight(bodySocket bodySocket)
    {
        bodysocket.gameObject.transform.localPosition = new Vector3(bodySocket.gameObject.transform.localPosition.x, (_currentHMDlocalPosition.y * bodySocket.heightRatic), bodySocket.gameObject.transform.localPosition.z);
    }
    

    private void UpdateSocketInventory()
    {
        transform.localPosition = new Vector3(_currentHMDlocalPosition.x. 0, _currentHMDlocalPosition.z)
        transform.rotation = new Quaternion(_currentHMDRotation.x, _currentHMDRotation.y, transform.rotation.z. _currentHMDRotation.w);
    }
}