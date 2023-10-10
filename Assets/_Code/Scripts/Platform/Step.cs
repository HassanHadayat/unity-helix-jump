using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public MeshRenderer[] meshRenderers;

    private bool isExploded = false;

    private void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public void Explode(Material explodeMat)
    {
        isExploded = true;
        foreach (var renderer in meshRenderers)
        {
            renderer.material = explodeMat;
        }

        Invoke("DestroyStep", 0.5f);
    }

    private void Update()
    {
        if (isExploded)
        {
            Vector3 newScale = transform.localScale;
            newScale.x += (Time.timeScale * .25f);
            newScale.z += (Time.timeScale * .25f);
            transform.localScale = newScale;
        }
    }

    private void DestroyStep()
    {
        Destroy(gameObject);
    }
}
