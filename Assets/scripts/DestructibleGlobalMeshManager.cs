using UnityEngine;
using Meta.XR.MRUtilityKit;
using System.Collections.Generic;

public class DestructibleGlobalMeshManager : MonoBehaviour
{
    public DestructibleGlobalMeshSpawner meshSpawner;
    private List<GameObject> segments = new List<GameObject>();
    private DestructibleMeshComponent currentComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshSpawner.OnDestructibleMeshCreated.AddListener(SetupDestructibleComponents);
    }

    public void SetupDestructibleComponents(DestructibleMeshComponent component)
    {
        currentComponent = component;

        component.GetDestructibleMeshSegments(segments);

        foreach (var item in segments)
        {
            item.AddComponent<MeshCollider>();
        }
    }

    public void DestroyMeshSegment(GameObject segment)
    {
        if(segments.Contains(segment) && currentComponent.ReservedSegment != segment)
        {
            currentComponent.DestroySegment(segment);
        }
    }
}