using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class HpBars : MonoBehaviour
{
    [SerializeField] private GameObject barPreFab;
    [SerializeField] private float offset;
    protected Image bar;
    protected Image bar_Filled;
    BaseClass baseClass;


    // Use this for initialization
    void Start()
    {
        bar = Instantiate(barPreFab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        bar.transform.SetSiblingIndex(0);
        bar.transform.position = transform.position + (Vector3.up * offset);
        bar_Filled = new List<Image>(bar.GetComponentsInChildren<Image>()).Find(img => img != bar);
        bar.gameObject.name = gameObject.name + " Bar";
    }

    private void OnRenderObject()
    {
        bar.transform.position = transform.position + (Vector3.up * offset);
    }
    private void OnDestroy()
    {
        Destroy(bar.gameObject);
    }
    private void Update()
    {
        if (Time.frameCount % 3 == 0)
        {
            if (GetComponent<Character>() != null)
            {
                baseClass = GetComponent<Character>().Stacs;
            }
            else
            if (GetComponent<Buildings>() != null)
            {
                baseClass = GetComponent<Buildings>().Stacs;
            }
            else
            if (GetComponent<Enemy>() != null)
            {
                baseClass = GetComponent<Enemy>().Stacs;
            }
            bar_Filled.fillAmount = BaseClassExtension.HpAmount(baseClass);
        }
    }
    private void OnDisable()
    {
        if (bar != null)
            bar.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        if (bar != null)
            bar.gameObject.SetActive(true);
    }
}
