using UnityEngine;

public class Doors : MonoBehaviour
{
    /// <summary>
    /// Open the Door
    /// </summary>
    public void OpenDoor()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 10.5f, transform.position.z);
    }

    /// <summary>
    /// Close the Door
    /// </summary>
    public void CloseDoor()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 10.5f, transform.position.z);
    }
}
