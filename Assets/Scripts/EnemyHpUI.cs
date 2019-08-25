using UnityEngine.UI;
using UnityEngine;

public class EnemyHpUI : MonoBehaviour
{

    // Use this for initialization
    [SerializeField] Enemy enemy;

    [Tooltip("Min value that Variable to have no fill on Image.")]
    private float Min = 0;

    [Tooltip("Max value that Variable can be to fill Image.")]
    private float Max;
    [SerializeField] private float hpPos = .16f;

    [Tooltip("Image to set the fill amount on.")]
    public Image Image;
    void Start()
    {
        if (enemy != null)
            Max = enemy.Stacs.Life;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            if (enemy.Stacs.Life > 0)
                Image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(Min, Max, enemy.Stacs.Life));
            else
            {
                Destroy(gameObject);
            }
        }
    }
    private void LateUpdate()
    {
        if (enemy != null)
        {
            if (!(hpPos < 0))
                transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y + hpPos);
            else
            {
                transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y + .16f);

            }
        }
    }
}
