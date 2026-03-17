using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideshowBehavior : MonoBehaviour
{
    [SerializeField] private Image slideshowImage;
    [SerializeField] private Sprite[] slideshowList;
    
    [SerializeField] private UnityEngine.Events.UnityEvent OnSlideShowEnd;

    private int slideshowNum = 0;

    public void NextSlide()
    {
        slideshowNum++;

        if(slideshowNum < slideshowList.Length)
        {
            slideshowImage.sprite = slideshowList[slideshowNum];
        }
        else if(slideshowNum >= slideshowList.Length)
        {
            OnSlideShowEnd.Invoke();
        }
    }

}
