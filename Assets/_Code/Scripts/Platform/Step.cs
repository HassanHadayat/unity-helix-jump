using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    public MeshRenderer[] meshRenderers;
    public float fallForce = 10f;
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
            // Change Parent 
            renderer.transform.parent = null;

            // Change the material
            renderer.material = explodeMat;

            // Appy Falling Effect
            Rigidbody rb = renderer.gameObject.GetComponent<Rigidbody>();
            rb.GetComponent<Collider>().isTrigger = true;
            rb.isKinematic = false;
            Vector3 forceDir = rb.transform.TransformDirection(new Vector3(-1f, -0.05f, 0f) * fallForce);

            // Force
            rb.AddForce(forceDir, ForceMode.Impulse);
            // Rotation
            renderer.transform.RotateAroundLocal(renderer.transform.forward, -0.8f);
            //rb.AddTorque(new Vector3(-0.5f, 0f, -0.5f));
        }

        Invoke("DestroyStep", 0.5f);
    }

    //private void Update()
    //{
    //    if (isExploded)
    //    {
    //        Vector3 newScale = transform.localScale;
    //        newScale.x += (Time.timeScale * .25f);
    //        newScale.z += (Time.timeScale * .25f);
    //        transform.localScale = newScale;
    //    }
    //}

    private void DestroyStep()
    {
        Destroy(gameObject);
    }
}
