using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class injectionTest : MonoBehaviour
{
    private IITest _test;

    [Inject]
    public void Init(IITest t)
    {
        _test = t;
    }
    // Start is called before the first frame update
    void Start()
    {
        _test.Echo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
