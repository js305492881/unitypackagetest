using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class x_GroundClick : MonoBehaviour, IPointerClickHandler
{
    public x_NavPlayer m_np;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogError(eventData.pointerCurrentRaycast.worldPosition);
        m_np.SetTargetPosition(eventData.pointerCurrentRaycast.worldPosition);
        //throw new System.NotImplementedException();
    }
}
