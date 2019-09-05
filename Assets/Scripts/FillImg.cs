using UnityEngine.UI;
using UnityEngine;

public class FillImg : MonoBehaviour
{
    [Tooltip("Value to use as the current ")]
    [SerializeField] Character Variable;



    [Tooltip("Min value that Variable to have no fill on Image.")]
    private float Min = 0;

    [Tooltip("Max value that Variable can be to fill Image.")]
    private float Max;

    [Tooltip("Image to set the fill amount on.")]
    public Image Image;
    private void Start()
    {
        if (Variable != null)
            Max = Variable.Stacs.Life;
    }
    private void Update()
    {
        if (Variable != null)
        {
            if (Variable.Stacs.Life > 0)
                Image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(Min, Max, Variable.Stacs.Life));
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void LateUpdate()
    {
            transform.position = new Vector2(Variable.transform.position.x, Variable.transform.position.y + .16f);
    }
}
