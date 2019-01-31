using UnityEngine;
using UnityEngine.UI;

public class NodeScript : MonoBehaviour
{
    public Text     text;
    public LineRenderer lineRenderer;

    public  int     maxValue;
    private float   value = 10;
    private float   growthRate;


    // Use this for initialization
    void Start ()
    {
        lineRenderer.enabled = false;
        growthRate = 1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (value < maxValue)
            value += growthRate * Time.deltaTime;

        text.text = ((int)value).ToString();
	}

    void OnMouseDrag()
    {
        lineRenderer.enabled = true;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, mousePos);
    }

    private void OnMouseUp()
    {
        lineRenderer.enabled = false;
    }
}
