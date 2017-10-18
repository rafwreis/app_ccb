using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Instrumentos.App.Controllers.Adapters;
using Instrumentos.App.Views.Components.Cards.Interfaces;
using System.Linq;

namespace Instrumentos.App.Views.Components.Cards
{
    public class InstrumentFragment : Fragment, IRefreshFragment
    {
        private InstrumentAdapter _instrumentAdpter;
        private InstrumentRepository _instrumentRepository;

        public InstrumentFragment()
        {
            _instrumentRepository = new InstrumentRepository();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var viewListInstrument = inflater.Inflate(Resource.Layout.fragment_instrument, container, false);
            var listView = viewListInstrument.FindViewById<ListView>(Resource.Id.listViewInstrument);
            
            _instrumentAdpter = new InstrumentAdapter(viewListInstrument.Context, _instrumentRepository.Get());
            listView.Adapter = _instrumentAdpter;

            listView.ItemClick += ListView_ItemClick;
            listView.ItemLongClick += ListView_ItemLongClick;
            return viewListInstrument;
        }

        private void ListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var item = _instrumentRepository.Get().ElementAt(e.Position);

            if (item.Count > 0)
            {
                item.Count--;
                e.View.FindViewById<TextView>(Resource.Id.txtCount).Text = item.Count.ToString();
                _instrumentRepository.Update(item);
            }

            Refresh();
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = _instrumentRepository.Get().ElementAt(e.Position);
            item.Count++;
            e.View.FindViewById<TextView>(Resource.Id.txtCount).Text = item.Count.ToString();
            _instrumentRepository.Update(item);

            Refresh();
        }

        public void Refresh()
        {
            var instrumets = _instrumentRepository.Get();
            _instrumentAdpter.Refresh(instrumets);
        }
    }
}