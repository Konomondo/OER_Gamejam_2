using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] GameObject ingredientPrefab;
    [SerializeField] Recipe recipe;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && recipe != null)
        {
            SpawnRecipeIngredients();
        }
    }

    public void SpawnRecipeIngredients()
    {
        foreach (IngredientAmount ingredientAmount in recipe.GetIngredients)
        {
            
            if (ingredientAmount.ingredient is BasicIngredient)
                SpawnObject(ingredientAmount.ingredient as BasicIngredient, null);
        }
    }

    public void SpawnObject(BasicIngredient ingredient, Transform transform)
    {
        GameObject newInstance = Instantiate(ingredientPrefab);
        newInstance.name = ingredient.Name;
        
        //newInstance.transform.position = Vector3.zero;
        newInstance.transform.position = transform != null ? transform.position : Vector3.zero;

        SpriteRenderer spriteRenderer = newInstance.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ingredient.IngredienContainerSprite;

        BoxCollider2D boxCollider = newInstance.GetComponent<BoxCollider2D>();
        boxCollider.size = spriteRenderer.sprite.bounds.size;

        IngredientDataHolder dataHolder = newInstance.GetComponent<IngredientDataHolder>();
        dataHolder.ingredient = ingredient;

        Debug.Log($"{ingredient.Name} spawned.");

    }

  
}