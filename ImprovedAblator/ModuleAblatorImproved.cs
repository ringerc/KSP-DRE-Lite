using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace ImprovedAblator
{

	/* A simplified heat shield based on Deadly Reentry
	 * but for 1.4, using KSP's built-in thermal and G physics.
	 * 
	 * Most of the rest of the functionality is in ModuleManager
	 * patches, but we can't make heat shields behave differently
	 * enough when depleted without a code change. Their conductivity
	 * remains at magical insulating levels, and their max temp remains
	 * insanely high when depleted.
	 * 
	 * Based on https://github.com/Starwaster/DeadlyReentry/Source/DeadlyReentry.cs
	 * with credit to KSP forum users who have part authorship:
	 * 
	 * - ialdabaoth
	 * - r4m0n
	 * - NathanKell
	 * - Starwaster
	 * 
	 * This code was CC-BY-SA, and must remain so.
	 */
	class ModuleAblatorImproved : ModuleAblator
	{
		// Cache the part's ablator resource
		public PartResource _ablative = null;

		[KSPField()]
		protected double depletedMaxTemp = 1200.0;

		[KSPField]
		protected double depletedConductivity = 20.0;

		public new void Start()
		{
			if (!HighLogic.LoadedSceneIsFlight)
				return;

			base.Start();

			// Update cached ablator resource
			if((object)ablativeResource != null && ablativeResource != "")
			{
				if(part.Resources.Contains(ablativeResource))
				{
					_ablative = part.Resources[ablativeResource];
				}
			}
			else
				print("Heat shield missing ablativeResource! Probable cause: third party mod using outdated ModuleHeatShield configs.");
		}

		public new void FixedUpdate()
		{
			if (!HighLogic.LoadedSceneIsFlight || !FlightGlobals.ready)
				return;
			
			base.FixedUpdate ();

			/*
			 * If less than one gram of ablator is remaining the shield is depleted. It stops being
			 * such a good insulator and becomes prone to prompt failure - we presume it has cracked
			 * or otherwise become faulty.
			 */
			if (_ablative.amount * _ablative.info.density <= 0.000001)
			{
				part.skinMaxTemp = Math.Min(part.skinMaxTemp, depletedMaxTemp);
				part.heatConductivity = Math.Min(part.heatConductivity, depletedConductivity);
				part.skinSkinConductionMult = Math.Min(part.skinSkinConductionMult, depletedConductivity);
				part.skinInternalConductionMult = Math.Min(part.skinInternalConductionMult, depletedConductivity);
			}
		}
	}
}