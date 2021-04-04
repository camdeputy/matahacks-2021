using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialReplacer : MonoBehaviour
{
    [SerializeField] private Material replacementMaterial;

    private bool _hasReplaced;

    private void Update()
    {
        if (_hasReplaced) return;
        
        var meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        if (!meshRenderer) return;
        
        meshRenderer.material = replacementMaterial;
        _hasReplaced = true;
    }
}
