using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExperiencePage : ContentPage
	{
       
        public ExperiencePage ()
		{
			InitializeComponent ();
		}

        async void OnDeleteClicked(object sender, EventArgs e)
        {
           var answer = await DisplayAlert("Are you sure you want to delete?", 
               "Great post, you can forget it immediately now! ", "Delete", "Cancel");
            if(answer)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    var post = (Post)BindingContext;
                    conn.Delete(post);
                }
                Navigation.PushAsync(new HistoryPage());
            }
            
           
                
        }
    }
}