using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Following Tutorial by Jimmy Vegas https://www.youtube.com/watch?v=DNMdu3kylec
public class LightningFlash : MonoBehaviour
{

    private bool _isFlashing = false;

    private float _delay;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isFlashing)
        {
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash()
    {
        _isFlashing = true;
        this.gameObject.GetComponent<Light>().enabled = true;
        _delay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(_delay);
        this.gameObject.GetComponent<Light>().enabled = false;
        _delay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(_delay);
        this.gameObject.GetComponent<Light>().enabled = true;
        _delay = Random.Range(0.01f, 0.1f);
        yield return new WaitForSeconds(_delay);
        this.gameObject.GetComponent<Light>().enabled = false;
        _delay = Random.Range(1f, 5f);
        yield return new WaitForSeconds(_delay);
        _isFlashing = false;
    }
}
