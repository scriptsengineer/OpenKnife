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

        public void Setting(int shoots)
        {
            this.shoots = shoots;
            this.actualShoots = shoots;
            for (int i = 0; i < shoots; i++)
            {
                images.Add(Instantiate(shootUIPrefab,transform.parent));
            }
        }

        public void Shoot()
        {
            actualShoots--;
            images[actualShoots].color = Color.black;
        }

        public void Clear()
        {
            //TODO Use a pool system
        }
    }    
}
