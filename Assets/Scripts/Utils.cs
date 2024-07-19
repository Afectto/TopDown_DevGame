using UnityEngine;

public static class Utils
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


    public static Vector2 GetRandomPointInArea()
    {
        return GetRandomPointInArea(MaxLimitsArena, MinLimitsArena);
    }

    public static Vector2 GetRandomPointInArea(Vector2 maxPoint, Vector2 minPoint)
    {
        float x = Random.Range(minPoint.x, maxPoint.x);
        float y = Random.Range(minPoint.y, maxPoint.y);
        
        return new Vector2(x, y);
    }
    
    public static Vector2 GetRandomPositionInCamera()
    {
        float cameraHeight = GetCameraHeight();
        float cameraWidth = GetCameraWight();
        
        Camera mainCamera = Camera.main;
        
        var positionCamera = mainCamera.transform.position;
        var topRightCameraPoint = positionCamera + new Vector3(cameraWidth,cameraHeight);
        var leftDownCameraPoint = positionCamera + new Vector3(-cameraWidth, -cameraHeight);
        return GetRandomPointInArea(topRightCameraPoint, leftDownCameraPoint);
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
