using Android.App;
using Android.Views;
using Android.OS;
using Android.Support.V4.App;
using com.refractored;
using Android.Support.V4.View;
using Android.Util;
using static Android.Support.V4.View.ViewPager;
using Instrumentos.App.Models;
using Instrumentos.App.Views.Components.Cards.Interfaces;
using Instrumentos.App.Controllers.Adapters;

namespace Instrumentos.App.Views
{
    [Activity(Label = "Contador de Instrumentos", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity, IOnTabReselectedListener, IOnPageChangeListener
    {
        private PagerSlidingTabStrip _tabs;
        private MainPagerAdapter _adapter;
        private ViewPager _pager;
        private InstrumentRepository _instrumentRepository;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_main;
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _pager = FindViewById<ViewPager>(Resource.Id.pager);
            _adapter = new MainPagerAdapter(SupportFragmentManager);
            _pager.Adapter = _adapter;

            _tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);
            _tabs.SetViewPager(_pager);

            var pageMargin = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 0, Resources.DisplayMetrics);
            _pager.PageMargin = pageMargin;

            _tabs.OnTabReselectedListener = this;
            _tabs.OnPageChangeListener = this;

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);

            _instrumentRepository = new InstrumentRepository();
            if (_instrumentRepository.Get().Count <= 0)
            {
                _instrumentRepository.AddDefaultInstrument();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add:

                    CreateInstrumentDialog dialog = new CreateInstrumentDialog();
                    Android.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();

                    dialog.OnCreateInstrument += OnCreateInstrument;
                    dialog.Show(transaction, "createInstrument");
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        void OnCreateInstrument(object sender, CreateInstrumentEventArgs e)
        {
            var instrument = new Instrument()
            {
                Name = e.Name,
                Occupation = e.Occupation,
                Address = e.Address,
                Category = string.Format("{0}-{1}", e.Occupation, e.Address),
                Image = "pessoa",
                Default = false,
                Count = 1
            };

            _instrumentRepository.Add(instrument);
            OnPageSelected(1);
        }

        public void OnTabReselected(int position)
        {
            //Toast.MakeText(this, "Tab reselected: " + position, ToastLength.Short).Show();
        }

        public void OnPageScrollStateChanged(int state)
        {
            //throw new NotImplementedException();
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            //throw new NotImplementedException();
        }

        public void OnPageSelected(int position)
        {
            var fragment = _adapter.GetFragment(position);
            if (fragment != null)
            {
                ((IRefreshFragment)fragment).Refresh();
            }
        }
    }
}


