using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour {
    private CinemachineImpulseSource impulseSource;

    void Awake() {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shake(float intensity = 1.0f) {
        impulseSource.GenerateImpulse(intensity);
    }
}