using UnityEngine;
using UnityEngine.EventSystems;
public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private void Awake()
    {
        print("Click");

    }
    public void OnPointerDown(PointerEventData eventData)
    {
            print("Click");

    }

    public void OnPointerUp(PointerEventData eventData)
    {
                print("Click");
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
