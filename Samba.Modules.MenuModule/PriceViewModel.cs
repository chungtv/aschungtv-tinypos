﻿using System;
using Samba.Domain.Models.Menus;
using Samba.Presentation.Common;

namespace Samba.Modules.MenuModule
{
    public class PriceViewModel : ObservableObject
    {
        public MenuItemPortion Model { get; set; }
        public string ItemName { get; set; }

        public string PortionName { get { return Model.Name; } }
        public decimal Price
        {
            get { return Model.Price.Amount; }
            set
            {
                if (value != Model.Price.Amount)
                {
                    Model.Price.Amount = value;
                    IsChanged = true;
                }
                RaisePropertyChanged("Price");
            }
        }

        private bool _isChanged;
        public bool IsChanged
        {
            get { return _isChanged; }
            set
            {
                _isChanged = value;
                RaisePropertyChanged("IsChanged");
            }
        }

        public PriceViewModel(MenuItemPortion model, string itemName)
        {
            Model = model;
            ItemName = itemName;
        }
    }
}