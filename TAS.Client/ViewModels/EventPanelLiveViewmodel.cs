﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAS.Server.Interfaces;

namespace TAS.Client.ViewModels
{
    public class EventPanelLiveViewmodel: EventPanelRundownElementViewmodelBase
    {
        public EventPanelLiveViewmodel(IEventClient ev, EventPanelViewmodelBase parent) : base(ev, parent) { }
        protected override void OnDispose()
        {
            if (IsSelected)
            {
                var p = Prior;
                if (p != null)
                    p.IsSelected = true;
            }
            base.OnDispose();
        }
    }
}
