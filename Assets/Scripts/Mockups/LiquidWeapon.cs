using UnityEngine;

public class LiquidWeapon : MonoBehaviour
{
	public float FireRate;
	public float MaxRange;
	public int FireAmountML;
	public int MaxPressure;
	public int PressureLossPerTick;
	public int PressureGainedPerPump;
	public float MinDmgRadius;
	public float MaxDmgRadius;
	public float SplashRadius;
	public bool RequiresPumping;
	public bool AutoPump;
	public bool WaitForFillAnim;
	public bool UseFalloffCurve;
	public float PumpingBlockDuration;
	public float StartFillingBlockDuration;
	public float StopFillingBlockDuration;
	public float cooldownTime;
	public bool filling;
	public int pressure;
	public float PressureFraction;
	public float MinimumPressureFraction;
	public float CurrentRange;
	public bool hasLid;
	public float throwScale;
	public bool canDrinkFrom;
	public bool updateVMWater;
	public float minThrowFrac;
	public bool useThrowAnim;
	public float fillMlPerSec;
	public float timeSinceLastAttack;
	public bool wasFilling;
	public float nextFreeTime;
	public float deployDelay;
	public float repeatDelay;
	public float animationDelay;
	public float effectiveRange;
	public float npcDamageScale;
	public float attackLengthMin;
	public float attackLengthMax;
	public float attackSpacing;
	public float aiAimSwayOffset;
	public float aiAimCone;
	public bool aiOnlyInRange;
	public float CloseRangeAddition;
	public float MediumRangeAddition;
	public float LongRangeAddition;
	public bool CanUseAtMediumRange;
	public bool CanUseAtLongRange;
	public float recoilCompDelayOverride;
	public bool wantsRecoilComp;
	public float nextAttackTime;
	public float lastTickTime;
	public float nextTickTime;
	public float timeSinceDeploy;
	public float lastRecoilCompTime;
	public UnityEngine.Vector3 startAimingDirection;
	public bool wasDoingRecoilComp;
	public UnityEngine.Vector3 reductionSpeed;
	public bool UsingInfiniteAmmoCheat;
	public float NextAttackTime;
	public bool isDeployed;
	public float nextExamineTime;
	public bool isBuildingTool;
	public float hostileScore;
	public UnityEngine.Vector3 FirstPersonArmOffset;
	public UnityEngine.Vector3 FirstPersonArmRotation;
	public float FirstPersonRotationStrength;
	public UnityEngine.Vector3 punchAdded;
	public float lastPunchTime;
	public bool hostile;
	public UnityEngine.Bounds bounds;
	public bool enableSaving;
	public bool syncPosition;
	public uint parentBone;
	public ulong skinID;
	public bool HasBrain;
	public uint broadcastProtocol;
	public bool linkedToNeighbours;
	public bool isVisible;
	public bool isAnimatorVisible;
	public bool isShadowVisible;
	public float RealisticMass;
	public bool IsNpc;
	public bool HasDisabledRenderers;
	public uint prefabID;
	public bool globalBroadcast;
	public bool globalBuildingBlock;
	public bool canTriggerParent;
	public bool isServer;
	public bool isClient;

}