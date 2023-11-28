﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp_MVVM.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SearchCommand(WeatherVM vm) => VM = vm;

        public bool CanExecute(object? parameter)
        {
            string? query = parameter as string;

            if (string.IsNullOrWhiteSpace(query))
            {
                return false;
            } 
            else
            {
                return true;
            }
        }

        public void Execute(object? parameter)
        {
            //throw new NotImplementedException();
            VM.MakeQuery();
        }
    }
}