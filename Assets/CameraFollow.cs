using UnityEngine;

public class SmashyRoadCamera : MonoBehaviour
{
    public Transform target; // Arabay� ba�la
    public Vector3 offset = new Vector3(0f, 15f, -10f); // Sabit ofset (nereye baks�n)
    public float smoothSpeed = 5f; // Takip yumu�akl���
    public Vector3 fixedRotation = new Vector3(45f, 0f, 0f); // Sabit kamera a��s�

    void FixedUpdate()
    {
        if (target == null) return;

        // Araban�n pozisyonuna sabit offset ekle (araban�n y�n� dikkate al�nmadan)
        Vector3 desiredPosition = target.position + offset;

        // Yumu�ak ge�i� (kamera araban�n pe�inden d�zg�n gelsin)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Sabit a��da bak (asla d�nmez)
        transform.rotation = Quaternion.Euler(fixedRotation);
    }
}
