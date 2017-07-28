using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    public class FaultSet :BaseModel
    {

        #region Members

        private Entity.App.ArizaSeti _model;
        private ObservableCollection<Entity.App.ArizaSeti> _faultSets;

        #endregion

        #region Properties

        public Entity.App.ArizaSeti Model
        {
            get { return _model; }
            set
            {
                _model = value;

                if (string.IsNullOrEmpty(_model.Aciklama))
                {
                    _model.TakipKodu = Bin.AppSetting.CreatCodeKey(FaultSets.Count);
                }
                else
                    ButtonEnable = false;
                OnPropertyChanged("Model");
            }
        }

        public ObservableCollection<Entity.App.ArizaSeti> FaultSets
        {
            get { return _faultSets; }
            set
            {
                _faultSets = value;
                OnPropertyChanged("FaltSets");
            }
        }


        #endregion

        #region Constructor

        public FaultSet()
        {
            FaultSets = new ObservableCollection<Entity.App.ArizaSeti>((Bin.ActionEvent.FaultSetActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.ArizaSeti>).ToList());
            Model = new Entity.App.ArizaSeti();
            ButtonEnable = false;
        }

        #endregion

        #region Helpers


        public override void dateFilter()
        {
            FaultSets = new ObservableCollection<Entity.App.ArizaSeti>((Bin.ActionEvent.FaultSetActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.ArizaSeti>).Where(model => model.EklenmeTarihi > SelectedDateTime_1 && model.EklenmeTarihi < SelectedDateTime_2).ToList());
        }

        public override void dataRowsCountFilter()
        {
            FaultSets = new ObservableCollection<Entity.App.ArizaSeti>((Bin.ActionEvent.FaultSetActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.ArizaSeti>).Skip((/*StartRowIndex > FaultSets.Count ? FaultSets.Count :*/ StartRowIndex)).Take((/*EndRowIndex > FaultSets.Count ? FaultSets.Count :*/ EndRowIndex)).ToList());
        }

        public override void dataRowsValuetFilter()
        {
            FaultSets = new ObservableCollection<Entity.App.ArizaSeti>((Bin.ActionEvent.FaultSetActionEvents.GetList(model => model.AppID == Bin.Model.AppSettingModel.AppID && model.Durum == true).Model as List<Entity.App.ArizaSeti>).Skip(0).Take((/*RowsValue > FaultSets.Count ? FaultSets.Count :*/ RowsValue)).ToList());

        }

        #endregion

    }
}
