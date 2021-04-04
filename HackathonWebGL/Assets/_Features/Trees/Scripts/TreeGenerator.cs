using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private float spaceBetweenRows = .5f;
    [SerializeField] private float delayBetweenSpawns = .1f;
    
    private readonly List<GameObject> _prefabsSpawned = new List<GameObject>();
    private Coroutine _coroutine;


    public void GenerateTrees(int metricTonsOfCo2)
    {
        if (_prefabsSpawned.Count > 0) ClearTrees();

        _coroutine = StartCoroutine(GenerateTreesCoroutine(metricTonsOfCo2));
    }

    private IEnumerator GenerateTreesCoroutine(int metricTonsOfCo2)
    {
        for (var treeIndex = 0; treeIndex < metricTonsOfCo2; treeIndex++)
        {
            var buffer = spaceBetweenRows * treeIndex;
            var spawnPosition = spawnTransform.position + (-spawnTransform.forward * buffer);
            var prefabInstance = Instantiate(treePrefab, spawnPosition, spawnTransform.rotation);
            prefabInstance.SetActive(true);
            
            _prefabsSpawned.Add(prefabInstance);

            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }
    
    public void ClearTrees()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = null;

        foreach (var prefabSpawned in _prefabsSpawned)
        {
            Destroy(prefabSpawned);
        }
        
        _prefabsSpawned.Clear();
    }
    
    [ContextMenu("Test()")]
    public void Test()
    {
        GenerateTrees(425);
    }
}
