﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Logic.DataProcess;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UI_TestConsole.Models;

namespace Logic.UI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class StartWindowModel : ViewModelBase
    {
        List<string> _source = new List<string> { "2", "3", "4"};
        public List<string> Source
        {
            get { return _source; }
        }
        string _theSelectedItem = null;
        public string TheSelectedItem
        {
            get { return _theSelectedItem; }
            set {
                if(value.ToString() == "2")
                {
                    Active3 = "False";
                    Active4 = "False";
                }
                if (value.ToString() == "3")
                {
                    Active3 = "True";
                    Active4 = "False";
                }
                if(value.ToString() == "4")
                {
                    Active3 = "True";
                    Active4 = "True";
                }
                _theSelectedItem = value; } // NotifyPropertyChanged
        }
        public string Active3 { get; set; } = "False";
        public string Active4 { get; set; } = "False";

        public StartWindowModel()
        {
            LaunchMain = new RelayCommand(() => 
            {
                Messenger.Default.Send(new NotificationMessage("StartMain"));
            });
            
           
        }
        public RelayCommand LaunchMain { get; set; }
        public RelayCommand OpenTextBoxes { get; private set; }
    }
}