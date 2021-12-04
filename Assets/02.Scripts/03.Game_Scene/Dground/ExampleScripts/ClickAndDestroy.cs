﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DTerrain
{
    /// <summary>
    /// Simple script that paints with Clear color the primary layer and paints using Black the secondary layer.
    /// Additionally, on right click paints primary layer with black.
    /// Use with SampleScene1.
    /// </summary>
    public class ClickAndDestroy : MonoBehaviour
    {
        [SerializeField]
        protected int circleSize = 16;
        [SerializeField]
        protected int outlineSize = 4;

        protected Shape destroyCircle;
        protected Shape outlineCircle;

        [SerializeField]
        protected BasicPaintableLayer primaryLayer;
        [SerializeField]
        protected BasicPaintableLayer secondaryLayer;

        public void Start()
        {
            destroyCircle = Shape.GenerateShapeCircle(circleSize);
            outlineCircle = Shape.GenerateShapeCircle(circleSize + outlineSize);
        }

        public void Update()
        {
            if (GameObject.Find("Boom(Clone)") == null) return;
            this.gameObject.transform.position = GameObject.Find("Boom(Clone)").transform.position;
            OnCollisionPoint();
        }

        protected virtual void OnCollisionPoint()
        {
            Vector3 p = this.gameObject.transform.position - primaryLayer.transform.position;
            primaryLayer?.Paint(new PaintingParameters() 
            { 
                Color = Color.clear, 
                Position = new Vector2Int((int)(p.x * primaryLayer.PPU) - circleSize, (int)(p.y * primaryLayer.PPU) - circleSize), 
                Shape = destroyCircle, 
                PaintingMode=PaintingMode.REPLACE_COLOR,
                DestructionMode = DestructionMode.DESTROY
            });

            secondaryLayer?.Paint(new PaintingParameters() 
            { 
                Color = new Color(0.0f,0.0f,0.0f,0.75f), 
                Position = new Vector2Int((int)(p.x * secondaryLayer.PPU) - circleSize-outlineSize, (int)(p.y * secondaryLayer.PPU) - circleSize-outlineSize), 
                Shape = outlineCircle, 
                PaintingMode=PaintingMode.REPLACE_COLOR,
                DestructionMode = DestructionMode.NONE
            });

        }
    }
}