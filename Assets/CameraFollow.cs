using UnityEngine;

public class SmashyRoadCamera : MonoBehaviour
{
    public Transform target; // Arabayý baðla
    public Vector3 offset = new Vector3(0f, 15f, -10f); // Sabit ofset (nereye baksýn)
    public float smoothSpeed = 5f; // Takip yumuþaklýðý
    public Vector3 fixedRotation = new Vector3(45f, 0f, 0f); // Sabit kamera açýsý

    void FixedUpdate()
    {
        if (target == null) return;

        // Arabanýn pozisyonuna sabit offset ekle (arabanýn yönü dikkate alýnmadan)
        Vector3 desiredPosition = target.position + offset;

        // Yumuþak geçiþ (kamera arabanýn peþinden düzgün gelsin)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Sabit açýda bak (asla dönmez)
        transform.rotation = Quaternion.Euler(fixedRotation);
    }
}
