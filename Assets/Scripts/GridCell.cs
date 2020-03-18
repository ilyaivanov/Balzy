using UnityEngine;

[ExecuteInEditMode]
public class GridCell : MonoBehaviour
{
    public int rowPosition;
    public int columnPosition;

    private float coef;

    //In Pixels
    public int marginInPixels = 20;

    void Start()
    {
        coef = Screen.height / 10f;
        Vector3 pos = transform.position;
        Vector3 scale = transform.localScale;
        scale.x = PixelsToUnits((Screen.width - marginInPixels * 4) / 3);
        scale.y = scale.x;
        scale.z = scale.x;


        pos.x = GetItemPosition(Screen.width, scale.x, columnPosition);
        pos.y = GetItemPosition(Screen.height, scale.y, rowPosition);

        var transform1 = this.transform;
        transform1.position = pos;
        transform1.localScale = scale;
    }

    float GetItemPosition(float axisLength, float itemSize, int positionOrder)
    {
        float margin = PixelsToUnits(this.marginInPixels);
        float rowOffset = (positionOrder - 1) * itemSize + margin * positionOrder;
        return -PixelsToUnits(axisLength / 2) + itemSize / 2 + rowOffset;
    }
    
    float PixelsToUnits(float pixels)
    {
        return pixels / coef;
    }

    float UnitsToPixels(float units)
    {
        return units * coef;
    }
}