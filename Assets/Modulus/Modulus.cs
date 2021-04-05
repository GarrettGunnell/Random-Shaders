using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modulus : MonoBehaviour {

    public Shader modulusShader;
    private Material modulusMaterial;

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if (modulusMaterial == null) {
            modulusMaterial = new Material(modulusShader);
            modulusMaterial.hideFlags = HideFlags.HideAndDontSave;
        }

        modulusMaterial.SetFloat("radius", 3);
        Graphics.Blit(source, destination, modulusMaterial);
    }
}
