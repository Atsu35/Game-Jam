using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public LayerMask m_LayerMask;

    private string[][] recipe = new string[][] {
        new string[] { "Stick", "RoundRock"},
        new string[] { "Rock", "Rock"}
    };
    public GameObject[] craftables;

    private string[][] checkRecipe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.LeftShift))
        {
            craft();
        }
    }
    public void craft()
    {
        Debug.Log("Craft");
        checkRecipe = recipe;
        Collider[] colliderArray = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity, m_LayerMask);

        foreach (Collider col in colliderArray)
        {
            replace(col);
        }
        for (int i = 0; i < checkRecipe.Length; i++)
        {
            int checkNum = 0;
            for (int j = 0; j < checkRecipe[i].Length; j++)
            {
                if (checkRecipe[i][j] == "exist")
                {
                    checkNum++;
                }
            }
            if (checkNum == checkRecipe[i].Length)
            {
                Debug.Log(checkRecipe[0][0] + ", " + checkRecipe[0][1]);
                Debug.Log(checkRecipe[1][0] + ", " + checkRecipe[1][1]);
                Debug.Log(i);
                removeAndSpawn(i);
                break;
            }
        }
    }
    private void replace(Collider col)
    {
        for (int i = 0; i < checkRecipe.Length; i++)
        {
            for (int j = 0; j < checkRecipe[0].Length; j++)
            {
                if (col.gameObject.tag == checkRecipe[i][j])
                {
                    checkRecipe[i][j] = "exist";
                    return;
                }
            }
        }
    }
    private void removeAndSpawn(int i)
    {
        Collider[] colliderArray = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity, m_LayerMask);
        foreach (Collider col in colliderArray)
        {
            Destroy(col.gameObject);
        }
        Instantiate(craftables[i], this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
