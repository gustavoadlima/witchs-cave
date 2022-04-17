using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareRecipe : MonoBehaviour
{
    [SerializeField] string TagDoObjeto;
    List<string> ingredientesInside = new List<string>();
    [SerializeField] GameObject Receipe1;
    [SerializeField] GameObject Receipe2;
    [SerializeField] GameObject Receipe3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(TagDoObjeto))
        {
            ingredientesInside.Add(collision.gameObject.GetComponent<Item>().itemName);
            Destroy(collision.gameObject);
            if (ingredientesInside.Count >= 3)
            {
                prepareItem(ingredientesInside);
                ingredientesInside.Clear();
            }

        }
        else
        {
            Debug.Log("Aqui não pode");
        }
    }

    void prepareItem(List<string> ingredientes)
    {
        string recipe = "";
        foreach(var obj in ingredientes)
        {
            recipe += obj;
        }
        switch (recipe){
            case "PataPoLiquido":
                GameObject.Instantiate(Receipe1);
                break;
            case "PataLiquidoPo":
                GameObject.Instantiate(Receipe1);
                break;
            case "PoPataLiquido":
                GameObject.Instantiate(Receipe1);
                break;
            case "PoLiquidoPata":
                GameObject.Instantiate(Receipe1);
                break;
            case "LiquidoPoPata":
                GameObject.Instantiate(Receipe1);
                break;
            case "LiquidoPataPo":
                GameObject.Instantiate(Receipe1);
                break;
            default:
                Debug.Log("Dubious food");
                break;
        }
    }
}
