using System.Collections;
using UnityEngine;

public class SpriteSheetAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetSprite(int index)
    { 
        if (index < 0 || index >= sprites.Length)
            return;
        
        spriteRenderer.sprite = sprites[index];
    }
}
