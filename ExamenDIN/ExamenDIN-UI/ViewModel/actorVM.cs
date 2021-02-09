using ExamenDIN_BL.ListadosBL;
using ExamenDIN_Entities;
using ExamenDIN_UI.ViewModel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDIN_UI.ViewModel
{
    public class actorVM : INotifyPropertyChanged
    {
        //FRANCISCO JOSE MARQUEZ PULIDO

        #region Atributos

        private ObservableCollection<clsActor> listOpcionesActores;
        private clsActor actorCorrecto;
        private Uri imagenActorCorrecto;
        private clsActor actorSeleccionado;
        private int nPartidas;
        private int nAciertos;
        private int nErrores;
        private string feedback;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #endregion

        #region Propiedades Publicas



        public ObservableCollection<clsActor> ListOpcionesActores
        {
            get
            {
                return listOpcionesActores;
            }
            set
            {
                this.listOpcionesActores = value;
            }
        }

        public clsActor ActorCorrecto
        {
            get
            {
                return actorCorrecto;
            }
            set
            {
                this.actorCorrecto = value;
            }
        }

        public clsActor ActorSeleccionado
        {
            get
            {
                return actorSeleccionado;
            }
            set
            {
                this.actorSeleccionado = value;

                nPartidas = nPartidas + 1;

                if ( actorSeleccionado == actorCorrecto)
                {
                    nAciertos = nAciertos + 1;
                    feedback = "Tu anterior respuesta es correcta";
                }
                else
                {
                    nErrores = nErrores + 1;
                    feedback = "Tu anterior respuesta es incorrecta";
                }

                if(nPartidas == 10)
                {
                    feedback = "La partida ha finalizado";
                }
                else
                {
                    
                    Random ramdom = new Random();
                    int r = ramdom.Next(1, 20);

                    //Obtenemos un actor ramdom de la base de datos como opcion correcta y lo añadimos a la lista de opciones
                    this.imagenActorCorrecto = new Uri("ms-appx://ExamenDIN_UI/assets/Fotos/" + r + ".jpg");
                    this.actorCorrecto = new clsListadoActoresBL().getActorRamdom(r);

                    //this.listOpcionesActores = new List<clsActor>();
                    this.listOpcionesActores.Clear();
                    this.listOpcionesActores.Add(actorCorrecto);

                    //Terminamos de rellenar la lista de 4 opciones con actores diferentes al que obtuvimos como opcion correcta
                    while (listOpcionesActores.Count < 4)
                    {
                        clsActor tmpActor = new clsListadoActoresBL().getActorRamdom(ramdom.Next(1, 20));

                        if (!listOpcionesActores.Contains(tmpActor) && tmpActor != actorCorrecto)
                        {
                            listOpcionesActores.Add(tmpActor);
                        }
                    }
                    

                }
                NotifyPropertyChanged("ListOpcionesActores");
                NotifyPropertyChanged("ImagenActorCorrecto");
                NotifyPropertyChanged("NAciertos");
                NotifyPropertyChanged("NAciertos");
                NotifyPropertyChanged("NErrores");
                NotifyPropertyChanged("NPartidas");
            }
        }

        public int NAciertos
        {
            get
            {
                return nAciertos;
            }
            set
            {
                this.nAciertos = value;
            }
        }


        public int NErrores
        {
            get
            {
                return nErrores;
            }
            set
            {
                this.nErrores = value;
            }
        }

        public int NPartidas
        {
            get
            {
                return nPartidas;
            }
            set
            {
                this.nPartidas = value;
            }
        }


        public string FeedBack
        {
            get
            {
                return feedback;
            }

            set
            {
                this.feedback = value;
            }
        }

        public Uri ImagenActorCorrecto
        {
            get
            {
                return imagenActorCorrecto;
            }
            set
            {
                this.imagenActorCorrecto = value;
            }
        }




        #endregion

        #region Contructores

        public actorVM()
        {


            Random ramdom = new Random();
            int r = ramdom.Next(1, 20);

            //Obtenemos un actor ramdom de la base de datos como opcion correcta y lo añadimos a la lista de opciones
            this.imagenActorCorrecto = new Uri("ms-appx://ExamenDIN_UI/assets/Fotos/"+r+".jpg");
            this.actorCorrecto = new clsListadoActoresBL().getActorRamdom(r);

            this.listOpcionesActores = new ObservableCollection<clsActor>();
            this.listOpcionesActores.Add(actorCorrecto);

            //Terminamos de rellenar la lista de 4 opciones con actores diferentes al que obtuvimos como opcion correcta
            while(listOpcionesActores.Count < 4)
            {
                clsActor tmpActor = new clsListadoActoresBL().getActorRamdom(ramdom.Next(1, 20));

                if (!listOpcionesActores.Contains(tmpActor) && tmpActor != actorCorrecto)
                {
                    listOpcionesActores.Add(tmpActor);
                } 
            }
            
            

        }

        #endregion



    }
}
