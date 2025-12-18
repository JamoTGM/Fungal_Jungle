using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float cameraFollowSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(mousePos.x, mousePos.y, -10f), Time.deltaTime * cameraFollowSpeed);
    }
}
