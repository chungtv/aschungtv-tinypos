﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samba.Localization.Properties;
using Samba.Presentation.Common;
using Samba.Presentation.Common.ModelBase;

namespace Samba.Modules.SettingsModule
{
    class BrowserViewModel : VisibleViewModelBase
    {
        public BrowserViewModel()
        {
            ActiveUrl = new Uri("about:Blank");
            EventServiceFactory.EventService.GetEvent<GenericEvent<Uri>>().Subscribe(OnBrowseUri);
        }

        private void OnBrowseUri(EventParameters<Uri> obj)
        {
            if (obj.Topic == EventTopicNames.BrowseUrl)
                ActiveUrl = obj.Value;
        }

        private Uri _activeUrl;
        public Uri ActiveUrl
        {
            get { return _activeUrl; }
            set
            {
                _activeUrl = value;
                RaisePropertyChanged("ActiveUrl");
            }
        }
        
        protected override string GetHeaderInfo()
        {
            return Resources.InternetBrowser;
        }

        public override Type GetViewType()
        {
            return typeof(BrowserView);
        }
    }
}
