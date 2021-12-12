using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawController : MonoBehaviour
{
  
    [SerializeField] private Player _player;
    
    [SerializeField] private GameObject _brush;

    private GameObject drawingBrush;
    private List<Vector2> touchPoints = new List<Vector2>();

    [SerializeField] float _brushThickness = 0.3f;

    //RenderTexture
    [SerializeField] private Camera _camera;

    void Update()
    {
        //Touch Controls
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;

            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    //Get touchPosition and start drawing on screen
                    Vector2 touchPosition = _camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, _camera.transform.position.z * -1));
                    StartDraw(touchPosition);

                    //Get properties from Brush Class
                    var brushRigidbody = drawingBrush.GetComponent<Brush>();
                    brushRigidbody.BrushRigidbody.gravityScale = 0;
                }

            }

            if (touch.phase == TouchPhase.Moved)
            {
                //Update draw every touch move
                Vector2 touchPosition = _camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, _camera.transform.position.z * -1));
                UpdateDraw(touchPosition);
            }

            
            if (touch.phase == TouchPhase.Ended)
            {
                //Get properties from Brush Class
                var brushRigidbody = drawingBrush.GetComponent<Brush>();
                brushRigidbody.BrushRigidbody.gravityScale = 1;

                //Destroy last draw prefab
                GameObject.Destroy(_player.RightSpawn.GetChild(0).gameObject); 
               
                //Instantiate brush prefab and set Transform settings
                var brush = Instantiate(drawingBrush, Vector3.zero, Quaternion.identity);
                
                Transform spawnPosition = new GameObject("RightSpawn").transform;
                spawnPosition.position = touchPoints[0];
                brush.transform.SetParent(spawnPosition);

                //Set spawn position,angle,scale and parent;
                spawnPosition.SetParent(_player.RightSpawn);
                spawnPosition.localPosition = Vector3.zero;
                spawnPosition.localEulerAngles = Vector3.zero;
                spawnPosition.localScale *= _brushThickness;

                GameObject.Destroy(drawingBrush);
            }
        }
    }

    public void StartDraw(Vector2 touchPosition)
    {
        touchPoints.Clear();
        touchPoints.Add(touchPosition);
        touchPoints.Add(touchPosition);

        drawingBrush = Instantiate(_brush);
        var brushObject = drawingBrush.GetComponent<Brush>();

        //Drawing on screen with line renderer
        brushObject.LineRenderer.SetPosition(0, touchPoints[0]);
        brushObject.LineRenderer.SetPosition(1, touchPoints[1]);

        //Create brush collider 
        brushObject.EdgeCollider.points = touchPoints.ToArray();
    }

    public void UpdateDraw(Vector2 touchPosition)
    {
        if (Vector2.Distance(touchPosition, touchPoints[touchPoints.Count - 1]) > .2f)
        {
            touchPoints.Add(touchPosition);

            var brushObject = drawingBrush.GetComponent<Brush>();
            
            brushObject.LineRenderer.positionCount += 1;
            brushObject.LineRenderer.SetPosition(brushObject.LineRenderer.positionCount - 1, touchPoints[touchPoints.Count - 1]);

            brushObject.EdgeCollider.points = touchPoints.ToArray();
        }
    }
}

    



