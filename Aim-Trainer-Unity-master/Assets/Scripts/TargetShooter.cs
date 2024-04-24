using UnityEngine;
using UnityEngine.Analytics;
using System;

public class TargetShooter : MonoBehaviour
{
    public static Action OnTargetMissed;

    [SerializeField] Camera cam;
    [SerializeField] UGS_Analytics analytics;

    void Update()
    {
        if (Timer.GameEnded)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();

                if (target != null)
                {
                    target.Hit();
                    // Track hit with Unity Analytics
                    if (analytics != null)
                    {
                        analytics.TrackHitEvent();
                        Debug.Log("Hit tracked");
                    }
                    else
                    {
                        Debug.LogError("UGS_Analytics component not assigned.");
                    }
                }
            }
            else
            {
                OnTargetMissed?.Invoke();
                // Track miss with Unity Analytics
                if (analytics != null)
                {
                    analytics.TrackMissEvent();
                    Debug.Log("Miss tracked");
                }
                else
                {
                    Debug.LogError("UGS_Analytics component not assigned.");
                }
            }
        }
    }
}
