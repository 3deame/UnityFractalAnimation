using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{

    [SerializeField, Range(1, 8)]
    public int depth = 4;
    [SerializeField, Range(0.1f, 50)]
    public float rotationSpeed = 22.5f;
    [SerializeField, Range(0, 1)]
    public float distance = 0.75f;
    // Start is called before the first frame update

    void Start()
    {
        name = "Fractal " + depth;

        if (depth <= 1)
        {
            return;
        }

        Fractal childA = CreateChild(Vector3.up, Quaternion.identity);
        Fractal childB = CreateChild(Vector3.right, Quaternion.Euler(0f, 0f, -90f));
        Fractal childC = CreateChild(Vector3.left, Quaternion.Euler(0f, 0f, 90f));
        Fractal childD = CreateChild(Vector3.forward, Quaternion.Euler(90f, 0f, 0f));
        Fractal childE = CreateChild(Vector3.back, Quaternion.Euler(-90f, 0f, 0f));

        childA.transform.SetParent(transform, false);
        childB.transform.SetParent(transform, false);
        childC.transform.SetParent(transform, false);
        childD.transform.SetParent(transform, false);
        childE.transform.SetParent(transform, false);

    }

    Fractal CreateChild(Vector3 direction, Quaternion rotation)
    {
        Fractal child = Instantiate(this);
        child.depth = depth - 1;
        child.transform.localPosition = distance * direction;
        child.transform.localRotation = rotation;
        child.transform.localScale = 0.5f * Vector3.one;
        return child;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);       
    }


}
