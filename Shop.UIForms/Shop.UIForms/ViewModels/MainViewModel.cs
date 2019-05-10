﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance;

        public LoginViewModel Login { get; set; }

         public ProductsViewModel Products { get; set; }


        public MainViewModel()
        {
            instance = this;
            //Login = new LoginViewModel();
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}

#region Attributes

#endregion


#region Properties

#endregion


#region Constructors

#endregion


#region Methods	

#endregion

#region Commands

#endregion
