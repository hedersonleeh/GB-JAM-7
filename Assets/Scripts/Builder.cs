using TMPro;
using UnityEngine;
enum typeOfBuilder
{
    TowerBuilder,
    Creator
};
public class Builder : MonoBehaviour
{
    [SerializeField] typeOfBuilder type;
    [SerializeField] GameObject[] objects;
    [SerializeField] Transform[] objectsPos;
    Character player;
    [SerializeField] TMP_Text tmp;
    int i = 0;
    int ctr = 0;
    private bool once = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<Character>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.player = null;
        }
    }
    private void Update()
    {
        if (player != null)
        {
            switch (type)
            {
                case typeOfBuilder.TowerBuilder:
                    if (player.Interacting && !player.Controller.Buttom_B)
                    {
                        tmp.text = string.Concat(">", objects[i].name, " $", (i + 1) * 10);
                        if (Input.GetButtonDown("Horizontal"))
                        {
                            i = i + 1 >= objects.Length ? 0 : ++i;
                            once = true;
                        }
                        if (player.Controller.Buttom_A && once && Buildings.ctr < 6 && Money.SpendMoney((i + 1) * 10))
                        {
                            ctr = ctr + 1 >= objectsPos.Length ? 0 : ++ctr;
                            float rnd = objectsPos[ctr].transform.position.x;
                            Instantiate(objects[i], new Vector2(rnd, objects[i].transform.position.y), Quaternion.identity);
                        }
                    }
                    else
                    {
                        tmp.text = "";
                        once = false;
                        player.Interacting = false;
                        // this.player = null;
                    }
                    break;
                case typeOfBuilder.Creator:
                    if (player.Interacting && !player.Controller.Buttom_B)
                    {
                        tmp.text = string.Concat(">", objects[i].name, " $", (i + 1) * 10);
                        if (Input.GetButtonDown("Horizontal"))
                        {
                            i = i + 1 >= objects.Length ? 0 : ++i;
                            once = true;
                        }
                        if (player.Controller.Buttom_A && once && Money.SpendMoney((i + 1) * 10))
                        {
                            ctr = ctr + 1 >= objectsPos.Length ? 0 : ++ctr;
                            float rnd = objectsPos[ctr].transform.position.x;
                            Instantiate(objects[i], new Vector2(rnd, objects[i].transform.position.y), Quaternion.identity);
                        }
                    }
                    else
                    {
                        tmp.text = "";
                        once = false;
                        player.Interacting = false;
                        // this.player = null;
                    }
                    break;

            }

        }
    }

}

