using UnityEngine.UI;
using UnityEngine;

public class BuildingHpUI : MonoBehaviour
{

    // Use this for initialization
    Buildings buildings;


    [Tooltip("Min value that Variable to have no fill on Image.")]
    private float Min = 0;

    [Tooltip("Max value that Variable can be to fill Image.")]
    private float Max;

    [Tooltip("Image to set the fill amount on.")]
    public Image Image;
    public float offsetInY = .15f;

private void Awake() {
	buildings =GetComponentInParent<Buildings>();
}
    void Start()
    {
        if (buildings != null)
            Max = buildings.Stacs.Life;
    }

    // Update is called once per frame
    void Update()
    {
        if (buildings != null)
        {
            if (buildings.Stacs.Life > 0)
                Image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(Min, Max, buildings.Stacs.Life));
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void LateUpdate()
    {
        if (buildings != null)
            transform.position = new Vector2(buildings.transform.position.x, buildings.transform.position.y + offsetInY);
    }
}

