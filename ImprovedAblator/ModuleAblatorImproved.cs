using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace ImprovedAblator
{
	public class ModuleAblatorImproved : ModuleAblator
	{
		/// <summary>
		/// Called when the part is started by Unity.
		/// </summary>
		public override void OnStart(StartState state)
		{
			// Add stuff to the log
			print("Engage Ablators!");
			base.OnStart (state);
		}

		public override void OnFixedUpdate ()
		{
			print ("tick");
			Console.WriteLine ("{0} ablator remaining", this.ablativeAmount);
			base.OnFixedUpdate ();
		}
	}
}