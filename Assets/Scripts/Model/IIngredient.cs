using UnityEngine;

public interface IIngredient
{
    string Name {get;}
    float Weight {get;}
    Sprite IngredientContainerSprite { get; }
    Sprite IngredientPortionSprite { get; }
}