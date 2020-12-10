using UnityEngine;

namespace Render
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class RandomSprite : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        public Sprite[] sprites;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if(sprites.Length > 0)
            {
                spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];
            }
            
        }

    }
}

