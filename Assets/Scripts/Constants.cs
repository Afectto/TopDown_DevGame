using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static Vector2 MaxLimitsArena = new Vector2(20, 15);
    public static  Vector2 MinLimitsArena = new Vector2( -20, -15);

    public static bool IsPositionInsideRectangle(Vector2 position)
    {
        return IsPositionInsideRectangle(position, MinLimitsArena, MaxLimitsArena);
    }

    public static bool IsPositionInsideRectangle(Vector2 position, Vector2 minArea, Vector2 maxArea)
    {        
        if(position.x >= minArea.x && position.x <= maxArea.x && position.y >= minArea.y && position.y <= maxArea.y)
        {
            return true;
        }
        return false;
    }

    public static Vector2 GetRandomPositionOutsideCameraButInArea()
    {
        Camera mainCamera = Camera.main;
        float offset = 0.5f;
        float cameraHeight = GetCameraHeight();
        float cameraWidth = GetCameraWight();

        var position = mainCamera.transform.position;
        var topRightCameraPoint = position + new Vector3(cameraWidth + offset,cameraHeight + offset);
        var leftDownCameraPoint = position + new Vector3(-cameraWidth - offset, -cameraHeight - offset);
        
        Vector2 point = GetRandomPointInArea();
        
        while (IsPositionInsideRectangle(point, leftDownCameraPoint,topRightCameraPoint))
        {
            point = GetRandomPointInArea();
        }

        return point;
    }

    public static Vector2 GetRandomPointInArea()
    {
        float x = Random.Range(MinLimitsArena.x, MaxLimitsArena.x);
        float y = Random.Range(MinLimitsArena.y, MaxLimitsArena.y);
        
        return new Vector2(x, y);
    }

    public static float GetCameraHeight()
    {
        Camera mainCamera = Camera.main;
        
        return mainCamera.orthographicSize;
    }

    public static float GetCameraWight()
    {
        return GetCameraHeight() * 16 / 9;
    }
}
