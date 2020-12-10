using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OpenKnife.UI
{
    public class ShootsPanel : MonoBehaviour
    {
        public Image shootUIPrefab;

        private List<Image> images = new List<Image>();

        private int shoots;
        private int actualShoots;

        private RectTransform rect;

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
        }

        public void SetNewShoots(int shoots)
        {
            Clear();
            Setting(shoots);
        }

        private void Setting(int shoots)
        {
            this.shoots = shoots;
            this.actualShoots = shoots;
            for (int i = 0; i < shoots; i++)
            {
                images.Add(Instantiate(shootUIPrefab,rect));
            }
        }

        public void Shoot()
        {
            actualShoots--;
            if(actualShoots <= 0) return;
            images[shoots-actualShoots-1].color = Color.black;
        }

        private void Clear()
        {
            // REVIEW Use a pool system
            foreach (Transform child in transform)
                Destroy(child.gameObject);
            images.Clear();
        }
    }    
}
