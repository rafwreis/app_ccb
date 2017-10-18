using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Instrumentos.App
{
    public class CreateInstrumentEventArgs : EventArgs
    {
        public string Name { get; set; }

        public string Occupation { get; set; }

        public string Address { get; set; }

        public CreateInstrumentEventArgs(string name, string occupation, string address)
        {
            Name = name;
            Occupation = occupation;
            Address = address;
        }
    }

    public class CreateInstrumentDialog : DialogFragment
    {
        private Button _buttonCreate;
        private EditText _txtName;
        private EditText _txtOccupation;
        private EditText _txtAddress;

        public event EventHandler<CreateInstrumentEventArgs> OnCreateInstrument;
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.create_dialog, container, false);

            _txtName = view.FindViewById<EditText>(Resource.Id.txtName);
            _txtOccupation = view.FindViewById<EditText>(Resource.Id.txtOccupation);
            _txtAddress = view.FindViewById<EditText>(Resource.Id.txtAddress);
            _buttonCreate = view.FindViewById<Button>(Resource.Id.btnCreateContact);
            _buttonCreate.Click += ButtonCreateClick;

            return view;
        }

        void ButtonCreateClick(object sender, EventArgs e)
        {
            if (OnCreateInstrument != null)
            {
                OnCreateInstrument.Invoke(this, new CreateInstrumentEventArgs(_txtName.Text, _txtOccupation.Text, _txtAddress.Text));
            }

            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            //Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}