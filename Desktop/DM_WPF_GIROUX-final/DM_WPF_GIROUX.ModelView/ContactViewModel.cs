using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DM_WPF_GIROUX
{

    //GESTIONNAIRE DES ALBUMS
    public class AlbumViewModel : ViewModelBase{
        private string _compositeur = "Compositeur";
        private string _titre = "Titre";

       
        public string Compositeur
        {
            get { return _compositeur; }
            set
            {
               
                _compositeur = value;
                OnPropertyChanged(nameof(Compositeur));
                OnPropertyChanged(nameof(PrenomNom));
            }
        }

        public string Titre
        {
            get { return _titre; }
            set
            {
                _titre = value;
                OnPropertyChanged(nameof(Titre));
                OnPropertyChanged(nameof(PrenomNom));
            }
        }

        public string PrenomNom
        {
            get { return $"{Compositeur} {Titre}"; }
        }

        public override string ToString()
        {
            return PrenomNom;
        }
    }

    //GESTIONNAIRE DES TITRES D UN ALBUM
    public class MusiqueViewModel : ViewModelBase
    {
        private string _titrePiste = "";

     

        public string TitrePiste
        {
            get { return _titrePiste; }
            set
            {
                _titrePiste = value;
                OnPropertyChanged(nameof(_titrePiste));
                OnPropertyChanged(nameof(TitrePiste));
            }
        }

    }
}
