using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private float radius = 100;
    [SerializeField] private int numPrefabsToSpawn;

    private readonly List<GameObject> _prefabsSpawned = new List<GameObject>();
    

    [ContextMenu("GenerateTrees()")]
    public void GenerateTrees()
    {
        if (_prefabsSpawned.Count > 0) DestroyPrefabs();
        
        for (var treeIndex = 0; treeIndex < numPrefabsToSpawn; treeIndex++)
        {
            var xPosition = Random.Range(-radius, radius);
            var zPosition = Random.Range(-radius, radius);

            var spawnPosition = spawnTransform.position + new Vector3(xPosition, 0, zPosition);
            var prefabInstance = Instantiate(treePrefab, spawnPosition, spawnTransform.rotation);
            prefabInstance.SetActive(true);
            
            _prefabsSpawned.Add(prefabInstance);
        }
    }

    private void DestroyPrefabs()
    {
        foreach (var prefabSpawned in _prefabsSpawned)
        {
            Destroy(prefabSpawned);
        }
        
        _prefabsSpawned.Clear();
    }
}
