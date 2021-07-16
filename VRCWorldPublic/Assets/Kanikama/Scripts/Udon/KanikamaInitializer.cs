﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Kanikama.Udon
{
    public class KanikamaInitializer : UdonSharpBehaviour
    {
        [SerializeField] private Texture[] lightMaps;
        [SerializeField] private Renderer[] receivers;

        private void Start()
        {
            foreach (var renderer in receivers)
            {
                var index = renderer.lightmapIndex;
                var sharedMats = renderer.sharedMaterials;
                for (var i = 0; i < sharedMats.Length; i++)
                {
                    var mat = sharedMats[i];
                    if (mat.HasProperty("_KanikamaMap"))
                    {
                        var p = new MaterialPropertyBlock();
                        p.SetTexture("_KanikamaMap", lightMaps[index]);
                        renderer.SetPropertyBlock(p, i);
                    }
                }
            }
        }
    }
}