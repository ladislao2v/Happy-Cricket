using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpuInstanving : MonoBehaviour
{
   private void Awake()
   {
      MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
      MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
      meshRenderer.SetPropertyBlock(materialPropertyBlock);
   }
}
