using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;
using Instrumentos.App.Models;

namespace Instrumentos.App.Controllers.Adapters
{
    public class InstrumentAdapter : BaseAdapter<Instrument>
    {
        private readonly List<Instrument> _itemsList;
        private readonly Context _context;

        public override int Count
        {
            get { return _itemsList.Count; }
        }

        public override Instrument this[int position]
        {
            get { return _itemsList[position]; }
        }

        public InstrumentAdapter(Context context, List<Instrument> itemsList)
        {
            _context = context;
            _itemsList = itemsList;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.listview_instrument, null, false);
            }

            row.FindViewById<TextView>(Resource.Id.txtInstrumentName).Text = _itemsList[position].Name;
            row.FindViewById<TextView>(Resource.Id.txtInstrumentCategory).Text = _itemsList[position].Category;
            row.FindViewById<TextView>(Resource.Id.txtCount).Text = _itemsList[position].Count.ToString();

            if (!string.IsNullOrEmpty(_itemsList[position].Image))
            {
                var resourceId = (int) typeof (Resource.Drawable).GetField(_itemsList[position].Image).GetValue(null);
                var imageView = row.FindViewById<ImageView>(Resource.Id.image);
                imageView.SetImageResource(resourceId);
            }

            return row;
        }

        public void Refresh(List<Instrument> itemsList)
        {
            _itemsList.Clear();
            _itemsList.AddRange(itemsList);

            NotifyDataSetChanged();
        }
    }
}