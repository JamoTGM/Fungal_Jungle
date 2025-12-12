using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = Input.mousePosition;

        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Pos).x, Camera.main.ScreenToWorldPoint(Pos).y, 0f);
    }
}
