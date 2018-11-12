using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCollision : MonoBehaviour {

    public Animator gameOverAnimator;
    public Animator lifePrewiewAnimator;
    public ScoreGameOver ScoreGameOver;
    public GoldenCubeScore goldenCubeScore;
    public Sounds sounds;
    public GameObject rayCastGameObject;
    public CameraShake cameraShake;

    private BoxCollider[] boxColliders;
    private SphereCollider[] sphereColliders;
    private PlayerMoveController playerMoveController;
    private BlockCreatorContoller blockCreatorContoller;
    private ResetHeroPos resetHeroPos;
    private BlockResetTransform blockResetTransform;
    private PogruzhikMoveController pogruzhikMoveController;
    private Animator playerAnimator;
    private bool isRotate;
    private bool isAngleRotate = true;
    private bool isTouched = true;
    private RaycastHit raycastHit;
    private float maxDistance = 0.2f;
    private int layerMask = 10;


    private void Start()
    {       
        boxColliders = GetComponents<BoxCollider>();
        sphereColliders = GetComponents<SphereCollider>();
        playerAnimator = GetComponent<Animator>();
        playerMoveController = GetComponent<PlayerMoveController>();
        blockCreatorContoller = GetComponent<BlockCreatorContoller>();
        resetHeroPos = GetComponent<ResetHeroPos>();
        blockResetTransform = FindObjectOfType<BlockResetTransform>();
        pogruzhikMoveController = FindObjectOfType<PogruzhikMoveController>();
    }

    private void Update()
    {
        Ray rightRay = new Ray(rayCastGameObject.transform.position, Vector3.down);

        if (Physics.Raycast(rightRay, out raycastHit, maxDistance))
        {
            if (raycastHit.collider.CompareTag("SingleBlock") && isTouched)
            {
                isTouched = false;
                goldenCubeScore.DeductGoldenCubeScore();
                playerMoveController.enabled = false;
                blockCreatorContoller.enabled = false;
                playerAnimator.SetBool("isMove", false);
                if (goldenCubeScore.goldenScore >= 1)
                {
                    lifePrewiewAnimator.SetBool("isShow", true);
                }
                Time.timeScale = 0;
                print("Get HIt");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {          
            foreach(var e in boxColliders)
            {
                e.enabled = false;
                foreach (var f in sphereColliders)
                {
                    f.enabled = false;
                }
            }
            isTouched = false;          
            sounds.CollisionWithPlatformPlay();
            goldenCubeScore.DeductGoldenCubeScore();
            playerMoveController.enabled = false;
            blockCreatorContoller.enabled = false;           
            playerAnimator.SetBool("isMove", false);
            if (goldenCubeScore.goldenScore >= 1)
            {
                lifePrewiewAnimator.SetBool("isShow", true);
            }           
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("SingleBlock"))
    //    {          
    //        goldenCubeScore.DeductGoldenCubeScore();
    //        playerMoveController.enabled = false;
    //        blockCreatorContoller.enabled = false;
    //        playerAnimator.SetBool("isMove", false);
    //        if (goldenCubeScore.goldenScore >= 1)
    //        {
    //            lifePrewiewAnimator.SetBool("isShow", true);
    //        }
    //        Time.timeScale = 0;
    //    }
    //}

    public void ResetBoolVars()
    {
        foreach (var e in boxColliders)
        {
            e.enabled = true;
            foreach (var f in sphereColliders)
            {
                f.enabled = true;
            }
        }
        playerMoveController.enabled = true;
        blockCreatorContoller.enabled = true;
        playerMoveController.isCanMovetoEdgePosition = false;        
        blockResetTransform.isResetTransform = true;
        pogruzhikMoveController.isMoveToPosRight = true;
        blockCreatorContoller.isTapUPFirst = false;
        blockCreatorContoller.isCanChangeBlockScale = true;
        resetHeroPos.ResetHeroPosition();
        ScoreGameOver.ReloadScore();
        isTouched = true;       
        Time.timeScale = 1;
    }

    public void AnimBackLifePrewiew()
    {
        lifePrewiewAnimator.SetBool("isShow", false);
        Time.timeScale = 1;
    }

    public void AnimaBaclGameOver()
    {
        gameOverAnimator.SetBool("showAnim", false);
        Time.timeScale = 1;
    }
}
