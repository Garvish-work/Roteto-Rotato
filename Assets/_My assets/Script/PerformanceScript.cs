using UnityEngine;

public class PerformanceScript : MonoBehaviour
{
    [Header("Frame Pacing")]
    [Range(30, 120)]
    public int targetFPS = 60;

    void Awake()
    {
        // ---------- FRAME PACING ----------
        QualitySettings.vSyncCount = 0; // Disable VSync (mobile handles it)
        Application.targetFrameRate = 60;

        //// Prevent large delta spikes (critical for smooth feel)
        //Time.maximumDeltaTime = 1f / 30f;
        //
        //// ---------- PHYSICS TIMING ----------
        //Time.fixedDeltaTime = 1f / 60f;
        //Time.maximumParticleDeltaTime = 1f / 30f;
        //
        //// ---------- RENDERING ----------
        QualitySettings.antiAliasing = 0;   // Try 0 or 2 on mobile
        QualitySettings.shadows = ShadowQuality.Disable;
        QualitySettings.shadowResolution = ShadowResolution.Low;
        QualitySettings.realtimeReflectionProbes = false;
        QualitySettings.billboardsFaceCameraPosition = true;
        QualitySettings.lodBias = 1f;
        QualitySettings.maximumLODLevel = 0;
        //
        //// ---------- QUALITY / GPU ----------
        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        QualitySettings.softParticles = false;
        QualitySettings.particleRaycastBudget = 16;
        //
        //// ---------- MOBILE STABILITY ----------
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //
        //// Disable multithreaded rendering on older devices (optional)
        //// PlayerSettings.MTRendering = false; // editor-only

        Debug.Log("Mobile Performance Settings Applied");
    }
}
