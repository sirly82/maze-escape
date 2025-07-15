using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    [Header("Camera Settings")]
    public float distance = 1.5f; // Jarak belakang player
    public float height = 2f; // Tinggi kamera dari ground
    public float lookAtHeight = 1f; // Titik fokus di player
    public LayerMask wallLayer;

    private List<Renderer> hiddenWalls = new List<Renderer>();

    void LateUpdate()
    {
        // 1. Hitung arah belakang player
        Vector3 backDirection = -target.forward;
        backDirection.y = 0;
        backDirection.Normalize();

        // 2. Hitung posisi kamera yang diinginkan
        Vector3 desiredPosition = target.position + backDirection * distance + Vector3.up * height;

        // 3. Smooth movement
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 4. Fokus ke player (dengan offset tinggi)
        Vector3 lookAtPosition = target.position + Vector3.up * lookAtHeight;
        transform.LookAt(lookAtPosition);

        // 5. Handle tembok penghalang
        HandleWallTransparency();
    }

    void HandleWallTransparency()
    {
        // Reset tembok sebelumnya
        foreach (var wall in hiddenWalls)
        {
            if (wall != null) wall.enabled = true;
        }
        hiddenWalls.Clear();

        // Deteksi tembok penghalang
        Vector3 rayStart = target.position + Vector3.up * lookAtHeight;
        Vector3 rayDirection = transform.position - rayStart;
        float rayDistance = rayDirection.magnitude;

        RaycastHit[] hits = Physics.RaycastAll(
            rayStart,
            rayDirection.normalized,
            rayDistance,
            wallLayer
        );

        // Sembunyikan tembok penghalang
        foreach (var hit in hits)
        {
            if (!hit.collider.CompareTag("Player"))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = false;
                    hiddenWalls.Add(renderer);
                }
            }
        }
    }

    void OnDestroy()
    {
        // Kembalikan visibilitas tembok
        foreach (var wall in hiddenWalls)
        {
            if (wall != null) wall.enabled = true;
        }
    }
}