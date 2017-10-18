using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Instrumentos.App.Controllers.Adapters;
using Instrumentos.App.Views.Components.Cards.Interfaces;
using System.Linq;

namespace Instrumentos.App.Views.Components.Cards
{
    public class ResumeFragment : Fragment, IRefreshFragment
    {
        private TextView _textTotal;
        private ResumeAdapter _resumeAdapter;
        private InstrumentRepository _instrumentRepository;

        public ResumeFragment()
        {
            _instrumentRepository = new InstrumentRepository();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var viewResume = inflater.Inflate(Resource.Layout.fragment_card, container, false);

            _textTotal = viewResume.FindViewById<TextView>(Resource.Id.txtResumoTotal);
            var listViewResume = viewResume.FindViewById<ListView>(Resource.Id.listViewResumo);

            _resumeAdapter = new ResumeAdapter(container.Context, _instrumentRepository.Get().Where(w => w.Count > 0).ToList());
            listViewResume.Adapter = _resumeAdapter;

            Refresh();
            return viewResume;
        }

        public void Refresh()
        {
            var instrumets = _instrumentRepository.Get();

            _textTotal.Text = string.Format("Total: {0}", instrumets.Sum(c => c.Count).ToString());
            _resumeAdapter.Refresh(instrumets.Where(w => w.Count > 0).ToList());
        }
    }
}