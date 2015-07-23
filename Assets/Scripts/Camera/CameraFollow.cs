using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float Smoothing = 5f;

    private Vector3 _offset;

    void Start()
    {
        transform.position = Target.position + new Vector3(1, 15, -22);
        transform.rotation = Quaternion.Euler(30, 0, 0);
        _offset = transform.position - Target.position;
    }

    void FixedUpdate()
    {
        var targetCamPos = Target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, Smoothing * Time.fixedDeltaTime);
    }
}
