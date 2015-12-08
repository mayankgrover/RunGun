using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class CharacterAI : MonoBehaviour {
    [SerializeField]
    private float dirChangeGracePeriodSec = 2.5f;
    [SerializeField]
    private int dirChangeChance = 33;
    [SerializeField]
    private float edgeDetectionDist = 1f;
    [SerializeField]
    private int edgeJumpChance = 25;
    [SerializeField]
    private int rndJumpChance = 5;


    private PlatformerCharacter2D m_Character;
    private int moveDir = 0;
    private float lastRndChange = 0;

    // Use this for initialization
    void Start () {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }
	
	void FixedUpdate() {
        if(m_Character.m_Grounded)
        {
            bool jump = false;
            Vector3 pos = m_Character.transform.position;
            if (Mathf.Abs(pos.x - m_Character.m_GroundMaxX) <= edgeDetectionDist)
            {
                moveDir = -1;
                jump = Mathf.RoundToInt(Random.value * 100) <= edgeJumpChance;
            }
            else if (Mathf.Abs(pos.x - m_Character.m_GroundMinX) <= edgeDetectionDist)
            {
                moveDir = 1;
                jump = Mathf.RoundToInt(Random.value * 100) <= edgeJumpChance;
            }
            else
            {
                if (lastRndChange < Time.fixedTime && Mathf.RoundToInt(Random.value * 100) <= dirChangeChance)
                {
                    lastRndChange = Time.fixedTime + dirChangeGracePeriodSec;
                    if (Mathf.RoundToInt(Random.value) == 1)
                    {
                        moveDir = 1;
                    }
                    else
                    {
                        moveDir = -1;
                    }
                }
                jump = Mathf.RoundToInt(Random.value * 100) <= rndJumpChance;
            }
            m_Character.Move(moveDir, false, jump);
        }
    }
}
