
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed;
    [Range(-1f, 1f)]
    public float scrollSpeedY;
    private float offset;
    private float offsetY;
    private Material mat;
    Vector3 lastPos;

    [SerializeField] Transform obj;
    private float threshold = 0.0f;

    void Start()
    {

        mat = GetComponent<Renderer>().material;
        lastPos = obj.position;

    }

    void Update()
    {

        Vector3 offsetX = obj.position - lastPos;
        Vector3 offsetY1 = obj.position - lastPos;
        if (offsetX.x > threshold)
        {
            lastPos = obj.position;
                scrollSpeed = 0.43f;
        }
        else if (offsetX.x < -threshold)
        {
            lastPos = obj.position;
            scrollSpeed = -0.43f;
        }
        else
        {
            scrollSpeed = 0f;
        }
        if (FindObjectOfType<Player>().GetComponent<Player>().isJumpUp)
        { 

            scrollSpeedY = 0.1f;

        }
        else if (FindObjectOfType<Player>().GetComponent<Player>().isJumpDown)
        {


            scrollSpeedY = -0.1f;
        }
        else
        {
            scrollSpeedY = 0f;
        }


        offsetY += (Time.deltaTime * scrollSpeedY) / 10f;
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, offsetY));
    }
}
