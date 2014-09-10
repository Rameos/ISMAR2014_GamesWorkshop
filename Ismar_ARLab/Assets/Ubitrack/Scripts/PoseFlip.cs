﻿using UnityEngine;
using System;
using System.Collections;
using Ubitrack;

public class PoseFlip : UbiTrackComponent {
	public UbitrackEventType ubitrackEvent = UbitrackEventType.Push;
	public UbitrackRelativeToUnity relative = UbitrackRelativeToUnity.World;
	public UbitrackApplyParts applyData = UbitrackApplyParts.Pose;
	
	protected SimpleApplicationPullSinkPose m_posePull = null;
	protected SimplePose m_simplePose = null;	
	
	protected UnityPoseReceiver m_poseReceiver = null;	
	protected Measurement<Pose> m_pose;
	
	public Measurement<Pose> lastPose;
	// Use this for initialization    
	public override void utInit(Ubitrack.SimpleFacade simpleFacade)
	{
		base.utInit(simpleFacade);
		
		switch(ubitrackEvent)
		{
		case UbitrackEventType.Pull:{
			m_posePull = simpleFacade.getSimplePullSinkPose(patternID);
			m_simplePose = new SimplePose();	
			if (m_posePull == null)
			{
				throw new Exception("SimpleApplicationPullSinkPose not found for poseID:" + patternID);
			}
			break;
		}
		case UbitrackEventType.Push:{
			m_poseReceiver = new UnityPoseReceiver();
			
			if (!simpleFacade.setPoseCallback(patternID, m_poseReceiver))
			{
				throw new Exception("SimplePoseReceiver could not be set for poseID:" + patternID);
			}
			
			break;
		}
		default:
			break;
		}    		
	}
	
	void FixedUpdate()
	{
		m_pose = null;
		
		switch(ubitrackEvent)
		{
		case UbitrackEventType.Pull:{				
			ulong lastTimestamp =  UbiMeasurementUtils.getUbitrackTimeStamp();
			if(m_posePull.getPose(m_simplePose, lastTimestamp))
			{					
				m_pose = UbiMeasurementUtils.ubitrackToUnity(m_simplePose);    
			}	
			break;
		}
		case UbitrackEventType.Push:{
			m_pose = m_poseReceiver.getData();
			break;
		}
		default:
			break;
		}
		
		if (m_pose != null)
		{
			m_pose.data().pos.x = -m_pose.data().pos.x;
			UbiUnityUtils.setGameObjectPose(relative, gameObject, m_pose.data(), applyData);
		}
		lastPose = m_pose;
	}   
}
