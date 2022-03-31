using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using ReactiveUI;

namespace lab7.Models
{
    public class Grade : ReactiveObject
    {
        public Grade(string FIO)
        {
            Val = "0";
            Fio = FIO;
        }
        ISolidColorBrush color;
        public ISolidColorBrush Color
        {
            get => color;
            set => this.RaiseAndSetIfChanged(ref color, value);
        }

        public string Fio
        {
            get; set;
        }


        string val;
        public string Val
        {
            get => val;
            set
            {
                try
                {
                    float val = float.Parse(value);
                    if (val < 1 ) Color = Brushes.Red;
                    else if (val <1.5) Color = Brushes.Yellow;
                    else Color = Brushes.Green;
                    if (val < 0 || val > 2)
                    {
                        value = "#ERROR";
                        Color = Brushes.White;
                    }
                    value = $"{val:0.##}";
                } catch(FormatException e)
                {
                    value = "#ERROR";
                }
                this.RaiseAndSetIfChanged(ref val, value);
            }
        }
    }
}
