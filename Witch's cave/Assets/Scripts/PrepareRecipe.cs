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
    [SerializeField] GameObject Receipe4;
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
    }

    void prepareItem(List<string> ingredientes)
    {
        string recipe = "";
        foreach(var obj in ingredientes)
        {
            recipe += obj;
        }
        GameObject objToInstantiate;
        switch (recipe){
            case "PataPoLiquido":
                objToInstantiate = GameObject.Instantiate(Receipe1);
                break;
            case "PataLiquidoPo":
                objToInstantiate = GameObject.Instantiate(Receipe1);
                break;
            case "PoPataLiquido":
                objToInstantiate = GameObject.Instantiate(Receipe1);
                break;
            case "PoLiquidoPata":
                objToInstantiate = GameObject.Instantiate(Receipe1);
                break;
            case "LiquidoPoPata":
                objToInstantiate = GameObject.Instantiate(Receipe1);
                break;
            case "LiquidoPataPo":
                objToInstantiate = GameObject.Instantiate(Receipe1);
                break;

            case "AsaCogumeloLiquido":
                objToInstantiate = GameObject.Instantiate(Receipe2);
                break;
            case "AsaLiquidoCogumelo":
                objToInstantiate = GameObject.Instantiate(Receipe2);
                break;
            case "CogumeloAsaLiquido":
                objToInstantiate = GameObject.Instantiate(Receipe2);
                break;
            case "CogumeloLiquidoAsa":
                objToInstantiate = GameObject.Instantiate(Receipe2);
                break;
            case "LiquidoAsaCogumelo":
                objToInstantiate = GameObject.Instantiate(Receipe2);
                break;
            case "LiquidoCogumeloAsa":
                objToInstantiate = GameObject.Instantiate(Receipe2);
                break;

            case "SafiraCogumeloLiquido":
                objToInstantiate = GameObject.Instantiate(Receipe3);
                break;
            case "SafiraLiquidoCogumelo":
                objToInstantiate = GameObject.Instantiate(Receipe3);
                break;
            case "CogumeloSafiraLiquido":
                objToInstantiate = GameObject.Instantiate(Receipe3);
                break;
            case "CogumeloLiquidoSafira":
                objToInstantiate = GameObject.Instantiate(Receipe3);
                break;
            case "LiquidoSafiraCogumelo":
                objToInstantiate = GameObject.Instantiate(Receipe3);
                break;
            case "LiquidoCogumeloSafira":
                objToInstantiate = GameObject.Instantiate(Receipe3);
                break;

            default:
                objToInstantiate = GameObject.Instantiate(Receipe4);
                break;
        }
        objToInstantiate.transform.position = transform.position;
    }
}
