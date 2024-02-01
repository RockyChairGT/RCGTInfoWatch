﻿using GorillaInfoWatch.Interfaces;
using GorillaInfoWatch.Models;
using GorillaNetworking;
using System;
using UnityEngine;

namespace GorillaInfoWatch.QuickActions
{
    public class SetParticles : IQuickAction
    {
        public string Name => "Set Particles";
        public ActionType Type => ActionType.Toggle;

        public bool InitialState => PlayerPrefs.GetString("disableParticles", "FALSE") == "FALSE";

        public Action<bool> OnActivate => (bool active) =>
        {
            GorillaComputer.instance.disableParticles = !active;
            PlayerPrefs.SetString("disableParticles", GorillaComputer.instance.disableParticles.ToString().ToUpper());
            GorillaTagger.Instance.ShowCosmeticParticles(!GorillaComputer.instance.disableParticles);
        };
    }
}