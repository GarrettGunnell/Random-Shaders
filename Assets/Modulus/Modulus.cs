using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modulus : MonoBehaviour {

    public Shader modulusShader;
    
    private int radius = 1;
    private float timer = 0;
    private Material modulusMaterial;

    void Update() {
        if (timer > 0.25) {
            radius++;
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if (modulusMaterial == null) {
            modulusMaterial = new Material(modulusShader);
            modulusMaterial.hideFlags = HideFlags.HideAndDontSave;
        }

        modulusMaterial.SetFloat("radius", radius);
        Graphics.Blit(source, destination, modulusMaterial);
    }
}
