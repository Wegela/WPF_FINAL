using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DM_WPF_GIROUX
{
    public class MainViewModel : ViewModelBase
    {
        // ObservableCollection<> = List<> + Notification de l'IU à chaque modification.

        private readonly ObservableCollection<AlbumViewModel> _albums;
        private AlbumViewModel _nouveau;
        private AlbumViewModel? _selection;

        private readonly ObservableCollection<MusiqueViewModel> _pistes;
        private MusiqueViewModel _nouveauMu;
        private MusiqueViewModel? _selectionMu;

        private readonly IView _view;
        public MainViewModel(IView view)
        {
            _albums = new ObservableCollection<AlbumViewModel>();
            _nouveau = new AlbumViewModel();

            _pistes = new ObservableCollection<MusiqueViewModel>();
            _nouveauMu = new MusiqueViewModel();

            _selection = null;
            _selectionMu = null;
            _view = view;

        }

        // Encapsulation dans une collection en lecture seule.
        public ReadOnlyObservableCollection<AlbumViewModel> Albums
        {
            get { return new ReadOnlyObservableCollection<AlbumViewModel>(_albums); }
        }

        public ReadOnlyObservableCollection<MusiqueViewModel> Piste
        {
            get { return new ReadOnlyObservableCollection<MusiqueViewModel>(_pistes); }
        }

        public AlbumViewModel Nouveau
        {
            get { return _nouveau; }
        }

        public AlbumViewModel? Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                OnPropertyChanged(nameof(Selection));
            }
        }

        public MusiqueViewModel NouveauMu
        {
            get { return _nouveauMu; }
        }

        public MusiqueViewModel SelectionMu
        {
            get { return _selectionMu; }
            set
            {
                _selectionMu = value;
                OnPropertyChanged(nameof(SelectionMu));
            }
        }

        public ICommand AjoutCommand
        {
            get { return new RelayCommand(Ajout); }
        }

        public void Ajout()
        {
            _albums.Add(_nouveau);
            Selection = _nouveau;

            // Prépare le prochain ajout :
            _nouveau = new AlbumViewModel();
            OnPropertyChanged(nameof(Nouveau));
        }

        public ICommand SuppressionCommand
        {
            get { return new RelayCommand(Suppression); }
        }

        public void Suppression()
        {
            if (_selection != null)
            {
                _albums.Remove(_selection);
                Selection = null;
            }
        }


        public ICommand AjoutMuCommand
        {
            get { return new RelayCommand(AjoutMu); }
        }

        public void AjoutMu()
        {
            _pistes.Add(_nouveauMu);
            SelectionMu = _nouveauMu;

            // Prépare le prochain ajout :
            _nouveauMu = new MusiqueViewModel();
            OnPropertyChanged(nameof(NouveauMu));
        }

        public ICommand SuppressionMuCommand
        {
            get { return new RelayCommand(SuppressionMu); }
        }

        public void SuppressionMu()
        {
            if (_selectionMu != null)
            {
                _pistes.Remove(_selectionMu);
                SelectionMu = null;
            }
        }

        
       

        public ICommand NouvelleVueCommand
        {
            get { return new RelayCommand(NouvelleVue); }
        }
        public void NouvelleVue()
        {
            _view.Affiche(this);
        }
    }
}
