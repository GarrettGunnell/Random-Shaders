using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modulus : MonoBehaviour {

    public Shader modulusShader;
    
    private int radius = 1;
    private float timer = 0;
    private int frameCount = 0;
    public bool capturing = true;
    private Material modulusMaterial;

    void Update() {
        if (timer > 0.1 && radius < 96) {
            radius++;
            timer = 0;
        }

        if (radius >= 94 && timer > 1) {
            capturing = false;
            Debug.Log("Finished");
        }

        timer += Time.deltaTime;
        frameCount++;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        if (modulusMaterial == null) {
            modulusMaterial = new Material(modulusShader);
            modulusMaterial.hideFlags = HideFlags.HideAndDontSave;
        }

        modulusMaterial.SetFloat("radius", radius);
        Graphics.Blit(source, destination, modulusMaterial, 2);
    }

    private void LateUpdate() {
        if (capturing) {
            RenderTexture rt = new RenderTexture(506, 506, 24);
            GetComponent<Camera>().targetTexture = rt;
            Texture2D screenshot = new Texture2D(506, 506, TextureFormat.RGB24, false);
            GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenshot.ReadPixels(new Rect(0, 0, 506, 506), 0, 0);
            GetComponent<Camera>().targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);
            string filename = string.Format("{0}/../Recordings/{1:000000}.png", Application.dataPath, frameCount);
            System.IO.File.WriteAllBytes(filename, screenshot.EncodeToPNG());
        }
    }
}
