using TMPro;
using UnityEngine;

public class Builder : MonoBehaviour
{

    [SerializeField] GameObject[] buildings;
    [SerializeField] Transform[] buildingsPos;
    Character player;
    [SerializeField] TMP_Text tmp;
    int i = 0;
    private bool once = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<Character>();
        }
    }
    private void Update()
    {
        if (player != null)
        {
            if (player.Interacting)
            {

                if (!player.Controller.Buttom_B)
                {
                    if (Input.GetButtonDown("Horizontal"))
                    {
                        i = i + 1 >= buildings.Length ? 0 : ++i;
                        Debug.Log(buildings[i].name);
                        tmp.text = string.Concat("> ", buildings[i].name);

                        once = true;
                    }
                    if (player.Controller.Buttom_A && once)
                    {
						float rnd = buildingsPos[Random.Range(0,buildingsPos.Length)].transform.position.x;
                        Instantiate(buildings[i],new Vector2(rnd,buildings[i].transform.position.y), Quaternion.identity);
                    }
                }
                else
                {
                    tmp.text = "";
                    once = false;
                    player.Interacting = false;
                    this.player = null;
                }
            }
        }

    }

}

