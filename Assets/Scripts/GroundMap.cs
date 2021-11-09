using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMap : MonoBehaviour
{
    public Texture2D srcTexture; //미리 있는 스프라이트를 가져옴
    Texture2D newTexture;
    SpriteRenderer sr;

    float worldWidth, worldHeight;
    int pixelWidth, pixelHeight;

    void Start()
    {

        //원래 있는 스프라이트를 복사해서 맵 스프라이트를 생성하고 자동으로 collider를 달고 나오는 코드입니다


        sr = GetComponent<SpriteRenderer>(); 
        //2D 스프라이트 렌더    
        newTexture = new Texture2D(srcTexture.width, srcTexture.height);
        Color[] colors = srcTexture.GetPixels(); 
        //미리 가져왔던 스프라이트의 픽셀을 GetPixels로 복사
        newTexture.SetPixels(colors); 
        //newTexture에 픽셀 세팅

        newTexture.Apply(); //텍스처 적용
        sr.sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.one * 0.5f); 
        // (0, 0) 부터 텍스처 넓이*높이만큼의 사각형 생성 피봇은 0.5

        /*
        worldWidth = sr.bounds.size.x;
        worldHeight = sr.bounds.size.y;
        pixelWidth = sr.sprite.texture.width;
        pixelHeight = sr.sprite.texture.height;
        Debug.Log("World : " + worldWidth + ", " + worldHeight + " Pixel :" + pixelWidth + ", " + pixelHeight);
        */

        gameObject.AddComponent<PolygonCollider2D>();
        //2D 폴리곤 Collider 컴포넌트 추가
    }

    
    void Update()
    {
        
    }
}
