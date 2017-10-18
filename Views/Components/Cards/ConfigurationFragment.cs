using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Instrumentos.App.Views.Components.Cards.Interfaces;

namespace Instrumentos.App.Views.Components.Cards
{
    public class ConfigurationFragment : Fragment, IRefreshFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var viewConfig = inflater.Inflate(Resource.Layout.fragment_configuration, container, false);
            var btnClearCount = viewConfig.FindViewById<Button>(Resource.Id.btnClearCount);
            btnClearCount.Click += BtnClearCount_Click;

            return viewConfig;
        }
        
        private void BtnClearCount_Click(object sender, System.EventArgs e)
        {
            var instrumentRepository = new InstrumentRepository();
            var instruments = instrumentRepository.Get();

            foreach (var instrument in instruments)
            {
                instrumentRepository.Delete(instrument);
            }

            instrumentRepository.AddDefaultInstrument();
        }

        public void Refresh()
        {

        }
    }
}