using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;



namespace P_Passion_Lecture
{
    public partial class MainPage : ContentPage
    {
        public string FictionFantastique {  get; set; } 
        public string Romance {  get; set; }
        public string MystereSuspence {  get; set; }
        public string Horreur {  get; set; }
        public string ScienceTechnologie {  get; set; }
        public string Aventure {  get; set; }
        public string DeveloppementPersonnel {  get; set; }

        public MainPage()
        {
            InitializeComponent();

            FictionFantastique = "Fiction Fantastique";
            Romance = "Romance";
            MystereSuspence = "Mystère & Suspence";
            Horreur = "Horreur";
            ScienceTechnologie = "Science & Technologie";
            Aventure = "Aventure";
            DeveloppementPersonnel = "Développement Personnel";

            BindingContext = this;
        }
    }

}


