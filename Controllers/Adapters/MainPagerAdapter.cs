using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Android.Support.V4.App;
using Instrumentos.App.Views.Components.Cards;

namespace Instrumentos.App.Controllers.Adapters
{
    public class MainPagerAdapter : FragmentPagerAdapter
    {
        private string[] Titles = { "Configuração", "Instrumentos", "Resultado" };
        private FragmentManager _fragmentManager;
        private Dictionary<int, string> _fragmentTags;

        public MainPagerAdapter(FragmentManager fm) : base(fm)
        {
            _fragmentManager = fm;
            _fragmentTags = new Dictionary<int, string>();
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(Titles[position]);
        }

        public override int Count
        {
            get
            {
                return Titles.Length;
            }
        }

        public override Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0: return new ConfigurationFragment();
                case 1: return new InstrumentFragment();
                case 2: return new ResumeFragment();
            }

            return null;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            var obj = base.InstantiateItem(container, position);
            if (obj is Fragment)
            {
                var fragment = (Fragment)obj;

                if (!_fragmentTags.Any(d => d.Key == position))
                {
                    _fragmentTags.Add(position, fragment.Tag);
                }
            }

            return obj;
        }

        public Fragment GetFragment(int position)
        {
            Fragment fragment = null;

            if (_fragmentTags != null)
            {
                var tag = _fragmentTags.FirstOrDefault(d => d.Key == position);
                if (tag.Value != null)
                {
                    fragment = _fragmentManager.FindFragmentByTag(tag.Value);
                }
            }

            return fragment;
        }
    }
}