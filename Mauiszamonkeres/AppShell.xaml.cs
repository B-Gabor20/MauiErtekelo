namespace Mauiszamonkeres
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute("ListPage", typeof(ListPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("ListPage", typeof(ListPage));

        }
    }
}
