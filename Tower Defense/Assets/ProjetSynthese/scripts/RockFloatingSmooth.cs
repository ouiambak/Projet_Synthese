using UnityEngine;

public class RockFloatingSmooth : MonoBehaviour
{
    public float amplitude = 0.5f; 
    public float speed = 1f;       
    public float rotationSpeed = 10f; 

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float offsetY = Mathf.Sin(Time.time * speed) * amplitude;
        Vector3 targetPosition = _startPosition + new Vector3(0f, offsetY, 0f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 2f);

        float rotationZ = Mathf.Sin(Time.time * (speed * 0.5f)) * rotationSpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}
