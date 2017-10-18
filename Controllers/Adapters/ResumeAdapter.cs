using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;
using Instrumentos.App.Models;

namespace Instrumentos.App.Controllers.Adapters
{
    public class ResumeAdapter : BaseAdapter<Instrument>
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

        public ResumeAdapter(Context context, List<Instrument> itemsList)
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
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.listview_resume, null, false);
            }

            var description = _itemsList[position].Name;

            if (!_itemsList[position].Default && !string.IsNullOrEmpty(_itemsList[position].Category))
            {
                description += string.Concat(" (", _itemsList[position].Category, ")");
            }
                
            row.FindViewById<TextView>(Resource.Id.txtResumoInstrument).Text = description;
            row.FindViewById<TextView>(Resource.Id.txtResumoCount).Text = _itemsList[position].Count.ToString();
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