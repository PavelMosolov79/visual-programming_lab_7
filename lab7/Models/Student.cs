using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using ReactiveUI;

namespace lab7.Models
{
    public class Student : ReactiveObject
    {
        public bool IsChecked
        {
            get; set;
        }
        public List<Grade> Grades
        {
            get;set;
        }

        string averageGrade;

        ISolidColorBrush color;
        public ISolidColorBrush Color
        {
            get => color;
            set => this.RaiseAndSetIfChanged(ref color, value);
        }
        public string AverageGrade
        {
            get => averageGrade;
            set => this.RaiseAndSetIfChanged(ref averageGrade, value);
        }
        void calculate()
        {
            float res = 0;
            try
            {
                foreach (var grade in Grades)
                {
                    res += int.Parse(grade.Val);
                }
            } catch(FormatException e)
            {
                AverageGrade = "#ERROR";
                Color = Brushes.White;
                return;
            }
            res /= Grades.Count;
            if (res < 1) Color = Brushes.Red;
            else if (res < 1.5) Color = Brushes.Yellow;
            else Color = Brushes.Green;
            AverageGrade = res.ToString("0.00");
        }
        public Student()
        {
            FIO = "";
            Grades = new List<Grade> { new Grade("Пред. 1"), new Grade("Пред. 2"), new Grade("Пред. 3"), new Grade("Пред. 4") };
            for (int i = 0; i < Grades.Count; i++)
                Grades[i].Changed.Subscribe((x) => calculate());
            calculate();
        }
        public Student(string fio):this()
        {
            FIO = fio;
        }
        string FIO;
        public string Fio
        {
            get => FIO;
            set => FIO = value;
        }
    }
}
