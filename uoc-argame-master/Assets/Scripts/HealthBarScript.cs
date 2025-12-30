using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void UpdateHearts(int health)
    {
        heart1.sprite = health >= 1 ? fullHeart : emptyHeart;
        heart2.sprite = health >= 2 ? fullHeart : emptyHeart;
        heart3.sprite = health >= 3 ? fullHeart : emptyHeart;
    }
}