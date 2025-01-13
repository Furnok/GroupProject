using UnityEngine;

public class Doors : MonoBehaviour
{
    public void OpenDoor()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void CloseDoor()
    {
        transform.position = new Vector3(transform.position.x, 10.5f, transform.position.z);
    }
}
